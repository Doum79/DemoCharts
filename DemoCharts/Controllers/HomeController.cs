using DemoCharts.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

using System.Web.Mvc;

namespace DemoCharts.Controllers
{
    public class HomeController : Controller
    {
        //public static float SystemCPU { get; private set; }
         private static readonly object locker = new object();
       
        //private static readonly PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true) ;
        //private static readonly PerformanceCounter meCounter = new PerformanceCounter("Memory", "% Committed Bytes in use");
        // private static readonly PerformanceCounter diskCounter = new PerformanceCounter("LogicalDisk", "% Free Space", "_Total", true);
        public  ActionResult  Index(Capacite c)
        {
            //c.CPU = 0;
            //c.Memory = 0;
            //c.Disk = 0;
             //Task.Run(() =>
             //     {
             //         var meCounter = new PerformanceCounter("Memory", "% Committed Bytes in use");
             //         var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
             //         var diskCounter = new PerformanceCounter("LogicalDisk", "% Free Space", "_Total", true);
             //         while (true)
             //         {

             //             lock (locker)
             //             {
             //                 if (Math.Abs(c.CPU) <= 0.00)
             //                     c.CPU = cpuCounter.NextValue();
             //           //c.Memory = meCounter.NextValue();
             //           //c.Disk= diskCounter.NextValue();
             //       }
             //             Thread.Sleep(1000);
             //         }
             //     });
        


        c.CPU = GetCpuValue();
        c.Memory = GetMemValue();
        //    c.Disk = GetDiskValue();

            

            return View(c) ;
        }

        private static float GetCpuValue()
        {

            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
            var value = cpuCounter.NextValue();
            //Note: In most cases you need to call .NextValue() twice to be able to get the real value
            if (Math.Abs(value) <= 0.00)
                value = cpuCounter.NextValue();
            //    //PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
            //    // float value = cpuCounter.NextValue();
            //    // //Note: In most cases you need to call .NextValue() twice to be able to get the real value
            //    // var val = string.Format("{0:0}%",value);
            //    //Thread.Sleep(1000);

                return value;
            }


           private static float  GetMemValue()
            {

            var meCounter = new PerformanceCounter("Memory", "% Committed Bytes in use");
            var value = meCounter.NextValue();
            //    //float value = meCounter.NextValue();
            if (Math.Abs(value) <= 0.00)
                value = meCounter.NextValue();
            //    ////Note: In most cases you need to call .NextValue() twice to be able to get the real value
            //    //var val = string.Format("{0:0}%", value);
                return value;
            }


            private static string GetDiskValue()
        {
            PerformanceCounter diskCounter = new PerformanceCounter("LogicalDisk", "% Free Space", "_Total", true);
            float value = diskCounter.NextValue();
             //Note: In most cases you need to call .NextValue() twice to be able to get the real value
           var val = string.Format("{0:0}%",value);
            Thread.Sleep(1000);
            return val;
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