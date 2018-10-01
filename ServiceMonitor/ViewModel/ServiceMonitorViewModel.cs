using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ServiceMonitor.Model;
using System.ServiceProcess;
using System.Diagnostics;

namespace ServiceMonitor.ViewModel
{
    class ServiceMonitorViewModel: ReactiveObject
    {
        private Model.ServiceMonitor _service;

        public ServiceMonitorViewModel ()
        {
            _service = new Model.ServiceMonitor("W32Time");
        }

        public Model.ServiceMonitor Service
        {
            get { return _service; }
        }
    }
}
