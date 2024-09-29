using FerumClient.Core.Entity.Information;
using FerumClient.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FerumClient.Core.ComputerInformation
{
    internal class NetworkInfo
    {
        public static List<NetworkEntity> GetNetworkEntities()
        {
            // Сетевой класс
            List<NetworkEntity> networkEntity = new List<NetworkEntity>();
            // Получаем список сетевых адаптеров
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();

            // Выводим информацию о каждом адаптере
            foreach (NetworkInterface adapter in adapters)
            {
                List<string> ipAddressList = new List<string>();
                List<string> maskList = new List<string>();
                List<string> gatewayAddressList = new List<string>();
                string macAddressString;

                // Получаем IP-адреса
                IPInterfaceProperties properties = adapter.GetIPProperties();
                UnicastIPAddressInformationCollection addresses = properties.UnicastAddresses;
                foreach (UnicastIPAddressInformation address in addresses)
                {
                    if (address.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        ipAddressList.Add(address.Address.ToString());
                    }
                }

                // Получаем MAC-адрес
                PhysicalAddress macAddress = adapter.GetPhysicalAddress();
                macAddressString = StringHelper.AddHyphensToText(macAddress.ToString());

                // Получаем маску подсети
                foreach (UnicastIPAddressInformation address in properties.UnicastAddresses)
                {
                    if (address.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        IPAddress subnetMask = address.IPv4Mask; // Получаем маску подсети
                        maskList.Add(subnetMask.ToString());
                        break; // Выводим только одну маску подсети
                    }
                }

                foreach (GatewayIPAddressInformation gatewayAddressInfo in properties.GatewayAddresses)
                {
                    // Получаем IP-адрес шлюза
                    IPAddress gatewayAddress = gatewayAddressInfo.Address;
                    gatewayAddressList.Add(gatewayAddress.ToString());
                }

                networkEntity.Add(new NetworkEntity(adapter.Name, adapter.NetworkInterfaceType.ToString(), adapter.Description, macAddressString, maskList, gatewayAddressList, ipAddressList));
            }
            return networkEntity;
        }
    }
}
