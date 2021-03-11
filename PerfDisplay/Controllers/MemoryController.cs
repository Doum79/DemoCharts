using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace PerfDisplay.Controllers
{
  
    [RoutePrefix("mem")]
    [EnableCors("https://localhost:44345", "*", "get,post")]
    public class MemoryController : ApiController
    {
        [Route("{MemValue}")]
        [HttpGet]
        public JsonResult<string>  Get()
        {


        return Json(GetMemory());

        }

        public static string GetMemory()
        {

            PerformanceCounter meCounter = new PerformanceCounter("Memory", "% Committed Bytes in use");

            float value = meCounter.NextValue();
            //Note: In most cases you need to call .NextValue() twice to be able to get the real value
            var val = string.Format("{0:0}", value);
            Thread.Sleep(1000);
            return val;
        }
    }

    
}
