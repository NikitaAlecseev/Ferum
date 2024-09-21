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
        private static int _portListener = 2000;

        private static TcpListener _tcpListenerAnswer; // слушатель ответов от запросов со стороны сервера к клиенту
        private static int _portAnswer = 2002;

        private DBServer dbServer = new DBServer();

        public ServerListener()
        {
            _tcpListener = new TcpListener(IPAddress.Any, _portListener);
            _tcpListener.Start();

            _tcpListenerAnswer = new TcpListener(IPAddress.Any, _portAnswer);
            _tcpListenerAnswer.Start();

            var thread = new Thread(TCPAcceptClient);
            thread.Start();

            var threadAnswer = new Thread(TCPAcceptClientAnswer);
            threadAnswer.Start();
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
        private void TCPAcceptClientAnswer()
        {
            while (true)
            {
                 var clientAnswer = _tcpListenerAnswer.AcceptTcpClient();
                 var threadAnswer = new Thread(HandleClientAnswer);
                 threadAnswer.Start(clientAnswer);
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

        private static void HandleClientAnswer(object clientObject)
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
                    EventSystem.InvokeEventGetClientAnswer(jsonString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка обработки ответа с хоста: {ex.Message}");
                }
            }
        }
    }
}
