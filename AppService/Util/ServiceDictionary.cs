using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AppService.Util.IServiceDictionnary;

namespace AppService.Util
{
    class ServiceDictionary : IServiceDictionnary
    {

        private EventLog eventLog1; // system log for writing different events
        private static object @lock = new object(); // lock object to avoid access by any other threads
        private volatile static ServiceDictionary instance = null;
        public static Dictionary<string, double> AppService; // Dictionary to save the db data 
        public static int eventId = 0; // counter for the events

        // Static Instance
        public static ServiceDictionary Instance
        {
            get
            {
                lock (@lock)
                {
                    if (instance == null)
                    {
                        lock (@lock)
                        {
                            instance = new ServiceDictionary();
                        }
                    }
                }
                return instance;
            }
        }

        public async Task UpdateClientsDictionary()
        {
            eventLog1 = new EventLog();
            if (!EventLog.SourceExists("ClientDictionaryLogs"))
            {
                EventLog.CreateEventSource("ClientDictionaryLogs", ""); // create event if it does not exist
            }
            eventLog1.Source = "ClientDictionaryLogs";
            eventLog1.Log = "";

            //try
            //{
            //    ClientBalances = await DatabaseExchange.GetBalance(); // update dictionary
            //}
            //catch (Exception ex)
            //{
            //    eventLog1.WriteEntry("The dictionary was not update. The error message is below: \n" + ex.Message,
            //        EventLogEntryType.Error, ++eventId);
            //}

            eventLog1.WriteEntry("Dictionary Updated Successfuly!",
                EventLogEntryType.Information, ++eventId); // write log
        }
    }
}
