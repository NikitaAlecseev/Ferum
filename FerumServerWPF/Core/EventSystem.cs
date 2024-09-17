using FerumServerWPF.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumServerWPF.Core
{
    public class EventSystem
    {
        public delegate void ClientInfo(string json);
        public static event ClientInfo EventGetInfoClient;

        public delegate void GetClientInfoToVM(MainInformationEntity json);
        public static event GetClientInfoToVM EventSendClientToVM;


        public static void InvokeEventGetClient(string json)
        {
            EventGetInfoClient?.Invoke(json);
        }

        public static void InvokeSendClientToVM(MainInformationEntity client)
        {
            EventSendClientToVM?.Invoke(client);
        }
    }
}
