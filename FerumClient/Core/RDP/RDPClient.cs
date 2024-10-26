using FerumEntities;
using FerumEntities.RequestInformation;
using Newtonsoft.Json;
using Rdp.Terminal.Core.Server;
using Rdp.Terminal.Core.WinApi;
using System;

namespace FerumClient.Core
{
    public class RDPClient
    {
        private string _serverConnectionText;

        public string ServerConnectionText
        {
            get
            {
                return _serverConnectionText;
            }

            set
            {
                _serverConnectionText = value;
            }
        }
        private string GroupName
        {
            get
            {
                return Environment.UserName;
            }
        }

        private string Password
        {
            get
            {
                return "Pa$$w0rrrd";
            }
        }

        /// <summary>
        /// RDP session manager.
        /// </summary>
        public RdpSessionServer server { get; set; }

        public void ServerStart(object obj)
        {
            if (!SupportUtils.CheckOperationSytem())
            {
                UnsupportingVersion();
                return;
            }

            server = new RdpSessionServer();
            server.Open();

            ServerConnectionText = server.CreateInvitation(GroupName, Password);
            SendServerConnectToHost();
        }


        /// <summary>
        /// Отправка строки подключения на сервер
        /// </summary>
        private void SendServerConnectToHost()
        {
            RDPConnectEntity rdpConnectEntity = new RDPConnectEntity();
            rdpConnectEntity.ServerConnectionText = ServerConnectionText;
            string jsonConnect = JsonConvert.SerializeObject(rdpConnectEntity);

            AnswerEntity answer = new AnswerEntity(GlobalVar.HostName, jsonConnect, AnswerEntity.TypeAnswers.RDP);
            string json = JsonConvert.SerializeObject(answer);
            SendHostInfo.SendHostRequest(json);
        }

        public void Disconnect()
        {
            server.Close();
        }


        private void UnsupportingVersion()
        {
            throw new NotImplementedException();
        }
    }
}
