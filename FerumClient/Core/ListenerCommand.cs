using FerumClient.Core.Entity.Client;
using FerumClient.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FerumClient.Core
{
    public class ListenerCommand
    {
        private static TcpListener _tcpListenerRequest;
        private static int _portRequest = 2001;

        public ListenerCommand()
        {
            _tcpListenerRequest = new TcpListener(IPAddress.Any, _portRequest);
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
