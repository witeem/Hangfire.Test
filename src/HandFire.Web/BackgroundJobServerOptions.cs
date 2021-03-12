using Hangfire;
using Hangfire.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandFire.Web
{
    public class BackgroundJobServerOptions
    {
        public BackgroundJobServerOptions()
        { 
            
        }

        public string ServerName { get; set; }
        public int WorkerCount { get; set; }
        public string[] Queues { get; set; }
        public TimeSpan ShutdownTimeout { get; set; }
        public TimeSpan SchedulePollingInterval { get; set; }
        public TimeSpan HeartbeatInterval { get; set; }
        public TimeSpan ServerTimeout { get; set; }
        public TimeSpan ServerCheckInterval { get; set; }
        public IJobFilterProvider FilterProvider { get; set; }
        public JobActivator Activator { get; set; }
    }
}
