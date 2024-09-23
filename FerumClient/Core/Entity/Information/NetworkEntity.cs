using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumClient.Core.Entity.Information
{
    public class NetworkEntity
    {
        public NetworkEntity(string adapterName, string adapterModel, string adapterDescription, string mACAddress, List<string> iPv4Mask, List<string> gatewayAddressInfo, List<string> iPAddress)
        {
            AdapterName = adapterName;
            AdapterModel = adapterModel;
            AdapterDescription = adapterDescription;
            MACAddress = mACAddress;
            IPv4Mask = iPv4Mask;
            GatewayAddressInfo = gatewayAddressInfo;
            IPAddress = iPAddress;
        }

        public string AdapterName { get; set; }
        public string AdapterModel { get; set; }
        public string AdapterDescription { get; set; }
        public string MACAddress { get; set; }
        public List<string> IPv4Mask { get; set; }
        public List<string> GatewayAddressInfo { get; set; } // шлюз
        public List<string> IPAddress { get; set; }
    }
}
