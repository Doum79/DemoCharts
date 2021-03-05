using System;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;
using Unity.SelfHostWebApiOwin;
using PerformanceService.Utils;

namespace PerformanceService
{
    [RunInstaller(true)]
    public partial class Service1 : ServiceBase
    {
        

        public Service1()
        {
            InitializeComponent();
            
        }

        protected  override void OnStart(string[] args)
        {
            
            Startup.StartServer(); // starts Web API
            // Set up a timer that triggers every 5 minute.
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimer);
            timer.Interval = 300000; // 5mins
            timer.Start();
        }

        private int eventId = 1; // counter for events in log
        public  void OnTimer(object sender, ElapsedEventArgs args)
        {
            

        }




        protected override void OnStop()
        {
              
        }
      
    }
}
