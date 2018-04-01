using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Devices.Geolocation;

namespace Tracker_UWP.Model
{
    public class BackgroundTaskHandler
    {
        private IBackgroundTaskRegistration register;
        
        public async Task isRegisteredAsync()
        {
            var taskRegistered = false;
            var taskName = "Run"; 

            foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                if(task.Value.Name == taskName)
                {
                    taskRegistered = true;
                    break;
                }
                else
                {
                    //If backroundtask is not registered then register it
                    var builder = new BackgroundTaskBuilder();
                    var appTrigger = new ApplicationTrigger();
                    builder.Name = taskName;
                    builder.TaskEntryPoint = "LocationBackgroundTask";
                    builder.SetTrigger(appTrigger);
                    var result = await appTrigger.RequestAsync();
                     task = builder.Register();
                }
            }

            
        }
        
        /*
        public async Task<Geoposition> GetPosition()
        {
            try
            {
                await BackgroundExecutionManager.RequestAccessAsync();
            }
        }
        */
    }
}
