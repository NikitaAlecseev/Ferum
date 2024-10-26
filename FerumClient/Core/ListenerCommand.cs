using FerumClient.Core.Helper;
using FerumEntities.Client;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FerumClient.Core
{
    public class ListenerCommand
    {
        private static TcpListener _tcpListenerRequest;

        public ListenerCommand()
        {
            _tcpListenerRequest = new TcpListener(IPAddress.Any, Convert.ToInt32(GlobalVar.RequestPort));
            _tcpListenerRequest.Start();

            var thread = new Thread(TCPAcceptClient);
            thread.Start();
        }
        private void TCPAcceptClient()
        {
            while (true)
            {
                var client = _tcpListenerRequest.AcceptTcpClient();
                var thread = new Thread(HandleClientRequest);
                thread.Start(client);
            }
        }

        private static void HandleClientRequest(object clientObject)
        {
            var client = (TcpClient)clientObject;

            using (var stream = client.GetStream())
            using (var reader = new StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();

                if (string.IsNullOrEmpty(jsonString))
                {
                    return;
                }

                try
                {
                    
                    Command hostInfoObj = JsonConvert.DeserializeObject<Command>(jsonString);
                    ErrorLog.ScreenError("Получил команду: " + hostInfoObj.command);
                    Commands.Send(hostInfoObj.command,hostInfoObj.parametr);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка обработки информации о хосте: {ex.Message}");
                    Console.Read();
                }
            }
        }
    }
}
