﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProITM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProITM.Server.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("[controller]")]
    public class HostController
    {
        // TODO 138 Inject database Host context

        // TODO 140 Implement HostController endpoint methods

        [HttpPost("create")]
        public async Task<IActionResult> AddHost(HostModel host)
        {
            throw new NotImplementedException("Implement me");
        }

        [HttpDelete("{hostId}")]
        public async Task<IActionResult> DeleteHost(string hostId)
        {
            throw new NotImplementedException("Implement me");
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetHosts()
        {
            throw new NotImplementedException("Implement me");
        }

        [HttpGet("logs/{hostId}")]
        public async Task<IActionResult> GetHostLogs(string hostId)
        {
            throw new NotImplementedException("Implement me");
        }
    }
}
