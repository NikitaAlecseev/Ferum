using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumClient.Core
{
    public class GlobalVar
    {
        public static string HostName;
        public static string IPServer;
        public static string MainPort;
        public static string RequestPort;
        public static RDPClient RdpClient = new RDPClient();
    }
}
