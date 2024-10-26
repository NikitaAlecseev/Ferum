using FerumClient.Core.Entity.Information;
using FerumClient.Core;
using Newtonsoft.Json;
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
using FerumClient.Entity;
using FerumClient.Core.ComputerInformation;

namespace FerumClient
{
    public partial class Service1 : ServiceBase
    {
        private static Timer _timer;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Task.Run(() => startClient());
        }

        protected override void OnStop()
        {
        }
    }
}
