using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceService.Utils
{
    class AppService
    {

        private EventLog eventLog1; // system log for writing different events
        private static object @lock = new object(); // lock object to avoid access by any other threads
        private volatile static AppService instance = null;
       
      

        // Static Instance
        public static AppService Instance
        {
            get
            {
                lock (@lock)
                {
                    if (instance == null)
                    {
                        lock (@lock)
                        {
                            instance = new AppService();
                        }
                    }
                }
                return instance;
            }
        }

      
    }
}
