using DemoCharts.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


namespace DemoCharts.Controllers
{
    public class HomeController : ApiController
    {

        public IEnumerable<string> Index()
        {

            return new string[] { "Index", "Home" };
        }

        public string Get(int id)
        {
            return "value";
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
                        cpuClockSpeed = Convert.ToInt64(obj.Properties["PercentUserTime"].Value.ToString());
                    }
                }
                //return the status
                return cpuClockSpeed + "%";
        }


        //public static string GetMem()
        //{

        //    //ManagementClass mgmt = new ManagementClass("SELECT Capacity from Win32_PhysicalMemory");
        //    ////create a ManagementObjectCollection to loop through
        //    //ManagementObjectCollection objCol = mgmt.GetInstances();
        //    ManagementScope oMs = new ManagementScope();
        //    ObjectQuery oQuery2 = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
        //    ManagementObjectSearcher oSearcher2 = new ManagementObjectSearcher(oMs, oQuery2);
        //    ManagementObjectCollection oCollection2 = oSearcher2.Get();
        //    int MemSlots = 0;
        //    foreach (ManagementObject obj in oCollection2)
        //    {
        //        if (MemSlots == 0)
        //        {
        //            MemSlots = 100 - Convert.ToInt32(obj["Capacity"]);

        //        }
        //    }

        //    return MemSlots.ToString() + "%";

        //}




        //public static string GetDisk()
        //{



           
        //    ManagementScope oMs = new ManagementScope();
        //    ObjectQuery oQuery2 = new ObjectQuery("SELECT MemoryDevices FROM Win32_PhysicalMemory");
        //    ManagementObjectSearcher oSearcher2 = new ManagementObjectSearcher(oMs, oQuery2);
        //    ManagementObjectCollection oCollection2 = oSearcher2.Get();
        //    int MemSlots = 0;
        //    foreach (ManagementObject obj in oCollection2)
        //    {
        //        MemSlots = 100 - Convert.ToInt32(obj["MemoryDevices"]);
        //    }



        //    return MemSlots.ToString() + "%";

        //}
    
 
        

    }
}