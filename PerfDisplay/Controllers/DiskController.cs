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
   
    [RoutePrefix("disk")]
    [EnableCors("https://localhost:44345", "*", "*")]
    public class DiskController : ApiController
    {
        [Route("{id}")]
        [HttpGet]
        public JsonResult<string> Get()
        {


            return Json($"Free space: {GetDiskValue()}");

        }

        public static string GetDiskValue()
        {

            PerformanceCounter diskCounter = new PerformanceCounter("LogicalDisk", "% Free Space", "_Total", true);
            float value = diskCounter.NextValue();
            //Note: In most cases you need to call .NextValue() twice to be able to get the real value
            var val = string.Format("{0:0}%", value);
            Thread.Sleep(1000);
            return val;
        }
    }
}
