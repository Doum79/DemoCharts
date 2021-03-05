using AppService.Util;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Unity.SelfHostWebApiOwin;

namespace AppService
{
    public partial class AppService : ServiceBase
    {

        
        public AppService()
        {
            InitializeComponent();
            eventLog1 = new EventLog(); // create event object
            if (!EventLog.SourceExists("AppServiceLogs"))
            {
                EventLog.CreateEventSource("AppServiceLogs", "");
            }
            eventLog1.Source = "AppServiceLogs";
            eventLog1.Log = "";
        }

        protected  async override void OnStart(string[] args)
        {
            eventLog1.WriteEntry(" Service Started at " + DateTime.Now);
            GetCPU();
            GetDiskValue();
            GetMemory();
            //Startup.StartServer(); // starts Web API
           

            await ServiceDictionary.Instance.UpdateClientsDictionary();// update dictionary before timer
            // Set up a timer that triggers every 5 minute.
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimer);
            timer.Interval = 300000; // 5mins
            timer.Start();

            await ServiceDictionary.Instance.UpdateClientsDictionary();
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
        private int eventId = 1; // counter for events in log
        public async void OnTimer(object sender, ElapsedEventArgs args)
        {

            // Write in logs
            eventLog1.WriteEntry("Updating dictionary from database. Started at " + DateTime.Now,
                EventLogEntryType.Information,
                eventId++);
          

            // update dictionary with data from the database
            await ServiceDictionary.Instance.UpdateClientsDictionary();
           
        }

        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {
            
        }
    }

}
