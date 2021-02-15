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
       // private static readonly object locker = new object();
       private static readonly PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true) ;
        private static readonly PerformanceCounter meCounter = new PerformanceCounter("Memory", "% Committed Bytes in use");
         private static readonly PerformanceCounter diskCounter = new PerformanceCounter("LogicalDisk", "% Free Space", "_Total", true);
        public ActionResult Index(Capacite c)
        {
            c.CPU = GetCpuValue();
            c.Memory = GetMemValue();
            c.Disk = GetDiskValue();
          


            return View(c) ;
        }

        private static string GetCpuValue()
        {

      var value =   (int)cpuCounter.NextValue();
            //Note: In most cases you need to call .NextValue() twice to be able to get the real value
            string val = value.ToString()+ "%";
            Thread.Sleep(1000);
            return val;
        }


        private static string GetMemValue()
        {

            var value = (int)meCounter.NextValue();
            //Note: In most cases you need to call .NextValue() twice to be able to get the real value
            string val = value.ToString() + "%";
            return val;
        }


        private static string GetDiskValue()
        {
            var value = (int)diskCounter.NextValue();
            //Note: In most cases you need to call .NextValue() twice to be able to get the real value
            string val = value.ToString() + "%";
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