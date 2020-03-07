using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorHandlingMiddleware.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlingMiddleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorTestController : ControllerBase
    {
        public ErrorTestController(IErrorMiddlewareTestService service)
        {
            this.Service = service;
        }

        private IErrorMiddlewareTestService Service { get; }

        [HttpGet("app")]
        public async Task<IActionResult> ApplicationErrorTest()
        {
            await this.Service.ApplicationErrorTest();
            return this.Ok();
        }

        [HttpGet("system")]
        public async Task<IActionResult> SystemErrorTest()
        {
            await this.Service.SystemErrorTest();
            return this.Ok();
        }
    }
}