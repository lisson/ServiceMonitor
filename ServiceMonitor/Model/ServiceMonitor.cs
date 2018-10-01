using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.ServiceProcess;
using System.Threading;
using System.Diagnostics;


namespace ServiceMonitor.Model
{
    class ServiceMonitor: ReactiveObject
    {
        private ServiceController sc;
        private TimeSpan startTimeSpan = TimeSpan.Zero;
        private TimeSpan periodTimeSpan;
        private Timer timer;

        private ServiceControllerStatus LastStatus;

        public ServiceMonitor(string s, int refresh = 5)
        {
            sc = new ServiceController(s);
            LastStatus = sc.Status;
            periodTimeSpan = TimeSpan.FromSeconds(refresh);
            timer = new System.Threading.Timer((e) =>
            {
                UpdateStatus();
            }, null, startTimeSpan, periodTimeSpan);
        }

        public ServiceControllerStatus Status
        {
            get { return LastStatus;  }
            set { this.RaiseAndSetIfChanged(ref LastStatus, value);  }
        }

        private void UpdateStatus()
        {
            Debug.WriteLine("Last status: " + LastStatus);
            sc.Refresh();
            if(LastStatus != sc.Status)
            {
                Debug.WriteLine("Updating service status");
                Status = sc.Status;
            }
        }

    }
}
