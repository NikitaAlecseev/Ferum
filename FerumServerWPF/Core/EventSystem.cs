using FerumEntities.Information;

namespace FerumServerWPF.Core
{
    public class EventSystem
    {
        public delegate void ClientInfo(string json);
        public static event ClientInfo EventGetInfoClient;

        public delegate void GetClientInfoToVM(MainInformationEntity json);
        public static event GetClientInfoToVM EventSendClientToVM;

        public delegate void ClientAnswer(string json);
        public static event ClientAnswer EventGetAnswerClient;


        public static void InvokeEventGetClient(string json)
        {
            EventGetInfoClient?.Invoke(json);
        }

        public static void InvokeEventGetClientAnswer(string json)
        {
            EventGetAnswerClient?.Invoke(json);
        }

        public static void InvokeSendClientToVM(MainInformationEntity client)
        {
            EventSendClientToVM?.Invoke(client);
        }
    }
}
