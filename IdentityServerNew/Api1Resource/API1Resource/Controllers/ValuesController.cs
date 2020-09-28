using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API1Resource.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _iLogger;

        public ValuesController(ILogger<ValuesController> iLogger)
        {
            _iLogger = iLogger;
        }
        
        [Authorize]
        //public IActionResult Get()
        //{
        //    return new JsonResult("success");
        //}
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
