﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Docker.DotNet.Models;
using ProITM.Server.Data;

namespace ProITM.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContainerController : ControllerBase
    {
        private Docker.DotNet.DockerClient c;
        private readonly ApplicationDbContext dbContext;

        public ContainerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        // TODO 143 Inject Docker.DotNet.DockerClient

        // TODO 144 Implement ContainerController endpoint methods

        [HttpGet("containers")]
        public async Task<IActionResult> ListContainers(string userId)
        {
            throw new NotImplementedException("Implement me");
        }

        [HttpPost("start/{containerId}")]
        public async Task<IActionResult> StartContainer(string containerId)
        {
            throw new NotImplementedException("Implement me");
        }

        [HttpPost("stop/{containerId}")]
        public async Task<IActionResult> StopContainer(string containerId)
        {
            throw new NotImplementedException("Implement me");
        }

        [HttpGet("containers/stats/{containerId}")]
        public async Task<IActionResult> GetContainerStats(string containerId)
        {
            throw new NotImplementedException("Implement me");
        }

        [HttpPost("containers/create")]
        public async Task<IActionResult> CreateContainer()
        {
            throw new NotImplementedException("Implement me");
        }

        [HttpDelete("containers/{containerId}")]
        public async Task<IActionResult> DeleteContainer(string containerId)
        {
            throw new NotImplementedException("Implement me");
        }

        [HttpGet("containers/logs/{containerId}")]
        public async Task<IActionResult> GetContainerLogs(string containerId)
        {
            throw new NotImplementedException("Implement me");
        }
    }
}