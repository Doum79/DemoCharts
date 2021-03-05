using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppService.Util
{
    class Performance
    {

        public static string GetDiskValue()
        {

            PerformanceCounter diskCounter = new PerformanceCounter("LogicalDisk", "% Free Space", "_Total", true);
            float value = diskCounter.NextValue();
            //Note: In most cases you need to call .NextValue() twice to be able to get the real value
            var val = string.Format("{0:0}%", value);
            Thread.Sleep(1000);
            return val;
        }


        public static string GetCPU()
        {
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);

            float value = cpuCounter.NextValue();
            //Note: In most cases you need to call .NextValue() twice to be able to get the real value
            var val = string.Format("{0:0}%", value);
            Thread.Sleep(1000);
            return val;
        }
        public static string GetMemory()
        {

            PerformanceCounter meCounter = new PerformanceCounter("Memory", "% Committed Bytes in use");

            float value = meCounter.NextValue();
            //Note: In most cases you need to call .NextValue() twice to be able to get the real value
            var val = string.Format("{0:0}%", value);
            Thread.Sleep(1000);
            return val;
        }
    }
}
