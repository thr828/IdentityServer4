using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API1Resource.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(policy: "TestPolicy")]
    public class TestController : ControllerBase
    {
        public string Get()
        {
            return "Test";
        }
    }
}
