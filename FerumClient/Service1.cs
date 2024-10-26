using System.ServiceProcess;
using System.Threading;

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
