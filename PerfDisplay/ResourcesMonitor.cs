using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Unity.SelfHostWebApiOwin;

namespace PerfDisplay
{
    public partial class ResourcesMonitor : ServiceBase
    {
        public ResourcesMonitor()
        {
            InitializeComponent();
            eventLog1 = new EventLog(); // create event object
            if (!EventLog.SourceExists("ResourcesMonitor"))
            {
                EventLog.CreateEventSource("ResourcesMonitor", "");
            }
            eventLog1.Source = "ResourcesMonitor";
            eventLog1.Log = "";
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("Client Balance Service Started at " + DateTime.Now);
            Startup.StartServer(); // starts Web API
            
        }
        private int eventId = 1; // counter for events in log


        protected override void OnStop()
        {
            // Write in logs
            eventLog1.WriteEntry("Updating dictionary from database. Started at " + DateTime.Now,
                EventLogEntryType.Information,
                eventId++);

     
        }
    }
}
