using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumServerWPF.Core.Entity.Information
{
    public class NetworkEntity
    {
         public string AdapterName { get; set; }
        public string AdapterModel { get; set; }
        public string AdapterDescription { get; set; }
        public string MACAddress { get; set; }
        public List<string> IPv4Mask { get; set; }
        public List<string> GatewayAddressInfo { get; set; } // шлюз
        public List<string> IPAddress { get; set; }
    }
}
