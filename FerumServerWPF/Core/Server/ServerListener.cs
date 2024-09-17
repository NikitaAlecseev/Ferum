using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FerumServerWPF.Core.Server
{
    public class ServerListener
    {
        private static TcpListener _tcpListener;
        private static int _port = 2000;

        private DBServer dbServer = new DBServer();

        public ServerListener()
        {
            _tcpListener = new TcpListener(IPAddress.Any, _port);
            _tcpListener.Start();

            var thread = new Thread(TCPAcceptClient);
            thread.Start();
        }


        private void TCPAcceptClient()
        {
            while (true)
            {
                var client = _tcpListener.AcceptTcpClient();
                var thread = new Thread(HandleClient);
                thread.Start(client);
            }
        }

        private static void HandleClient(object clientObject)
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
                    EventSystem.InvokeEventGetClient(jsonString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка обработки информации о хосте: {ex.Message}");
                }
            }
        }
    }
}
