using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace PerfDisplay.Controllers
{
  
    [RoutePrefix("cpu")]
    [EnableCorsAttribute("https://localhost:44345", "*", "*")]
    public class CPUController : ApiController
    {
        [Route("{id}")]
        [HttpGet]
        public JsonResult<string> GetCpu()
        {
            
            
            return Json($"CPU: {GetCPUusage()}"); 
            
        }



        public static string GetCPUusage()
        {
            long cpuClockSpeed = 0;
            ManagementClass mgmt = new ManagementClass("Win32_PerfFormattedData_PerfOS_Processor");
            //create a ManagementObjectCollection to loop through
            ManagementObjectCollection objCol = mgmt.GetInstances();
            //start our loop for all processors found
            foreach (ManagementObject obj in objCol)
            {
                if (cpuClockSpeed == 0)
                {
                    // only return cpuStatus from first CPU
                    cpuClockSpeed = Convert.ToInt64(obj.Properties["PercentUserTime"].Value.ToString());
                }
            }
            //return the status
            return cpuClockSpeed + "%";
        }
       
    }
}
