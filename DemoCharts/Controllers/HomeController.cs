using DemoCharts.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

using System.Web.Mvc;

namespace DemoCharts.Controllers
{
    public class HomeController : Controller
    {
     
          public  ActionResult  Index(Capacite c)
           {
           


        c.CPU = GetCPUusage().ToString();
            c.Memory = GetMem().ToString();
            //    c.Disk = GetDiskValue();



            return View(c) ;
        }




        //private static string GetDiskValue()
        //{
        //// Win32Win32_ProcessorWin32_LogicalDisk
        //ManagementScope oMs = new ManagementScope();
        //SelectQuery queryCpuUsage = new SelectQuery("SELECT * FROM  Win32Win32_ProcessorWin32_LogicalDisk");

    //}

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
                        cpuClockSpeed = 100 - Convert.ToInt64(obj.Properties["PercentUserTime"].Value.ToString());
                    }
                }
                //return the status
                return cpuClockSpeed + "%";
            }
        

    public static string GetMem()
        {

        int MemSlots = 0;
        ManagementScope oMs = new ManagementScope();
        ObjectQuery oQuery2 = new ObjectQuery("SELECT MemoryDevices FROM Win32_PhysicalMemoryArray");
        ManagementObjectSearcher oSearcher2 = new ManagementObjectSearcher(oMs, oQuery2);
        ManagementObjectCollection oCollection2 = oSearcher2.Get();
        foreach (ManagementObject obj in oCollection2)
        {
            MemSlots = 100 - Convert.ToInt32(obj["MemoryDevices"]);
        }
        return MemSlots.ToString() + "%";

    }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
