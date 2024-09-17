using FerumServer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumServer.Core
{
    public class HostInfoObject
    {
        public string HostName { get; set; }
        public string LastShutdown { get; set; }
        public string Uptime { get; set; }
        public string LastUser { get; set; }
        public string ModelGPU { get; set; }
        public PCInfo PCInfo { get; set; }
        public List<string> InstalledPrograms { get; set; }
        public List<HardInfo> HardDisk { get; set; }
        public List<ProcessEntity> ActiveProcess { get; set; }


        public string version { get; set; }
    }
}
