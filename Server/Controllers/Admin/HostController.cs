﻿using Docker.DotNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProITM.Server.Data;
using ProITM.Server.Utilities;
using ProITM.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProITM.Server.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("[controller]")]
    public class HostController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public HostController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // TODO 176 Implement HostController endpoint methods

        [HttpPost("create")]
        public async Task<IActionResult> AddHost(HostModel host)
        {
            host.IP = "UNUSED";
            host.Port = -1111;
            dbContext.Hosts.Add(host);
            await dbContext.SaveChangesAsync();
            return Ok("Added host to databse");
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditHost(HostModel host)
        {
            var foundHost = await dbContext.Hosts
                .FirstAsync(h => h.Id == host.Id);

            if (foundHost == null) return BadRequest();

            foundHost.DisplayName = host.DisplayName;
            foundHost.IsWindows = host.IsWindows;
            foundHost.IP = "UNUSED";
            foundHost.Port = -1111;
            foundHost.URI = host.URI;

            if (await dbContext.SaveChangesAsync() == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{hostId}")]
        public async Task<IActionResult> DeleteHost(string hostId)
        {
            var host = dbContext.Hosts.First(h => h.Id == hostId);

            var containers = await dbContext.Containers
                .AsNoTracking()
                .Where(c => c.Machine.Id == host.Id)
                .ToListAsync();

            if (containers.Any())
                return BadRequest($"Host in use by {containers.Count} containers");

            dbContext.Hosts.Remove(host);
            await dbContext.SaveChangesAsync();

            return Ok("Deleted successfully");
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetHosts()
        {
            var host = dbContext.Hosts.ToList();

            return Ok(host);
        }

        [HttpGet("{hostId}")]
        public async Task<IActionResult> HostDetails(string hostId)
        {
            return Ok(await dbContext.Hosts
                .AsNoTracking()
                .SingleOrDefaultAsync(h => h.Id == hostId));
        }

        [HttpGet("logs/{hostId}")]
        public async Task<IActionResult> GetHostLogs(string hostId)
        {
            // TODO decide if necessary

            throw new NotImplementedException("Implement me");
        }

        [HttpGet("test/{hostUri}")]
        public async Task<IActionResult> TestConnection(string hostUri)
        {
            string addr = System.Net.WebUtility.UrlDecode(hostUri);
            DockerClient client;
            try
            {
                client = HostModelUtils.GetDockerClient(addr);
            }
            catch (Exception)
            {
                return Ok(false);
            }
            if(client == null)
            {
                return Ok(false);
            }
            else
            {
                try
                {
                    var response = await client.System.GetSystemInfoAsync();
                    if (response.Containers >= 0)
                        return Ok(true);
                    //await client.System.PingAsync();
                    return Ok(false);
                }
                catch (Exception)
                {
                    return Ok(false);
                }
            }
            
        }
    }
}
