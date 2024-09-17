using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FerumClient.Core
{
    public class SendHostInfo
    {
        private static string _serverAddress = "172.16.2.93";
        private static int _serverPort = 2000;
        public static void SendHost(object state)
        {
            var jsonString = state as string;

            if (string.IsNullOrEmpty(jsonString))
            {
                return;
            }

            try
            {
                using (var client = new TcpClient(_serverAddress, _serverPort))
                {
                    using (var stream = client.GetStream())
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.Write(jsonString);
                        writer.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка отправки информации на сервер: {ex.Message}");
            }
        }
    }
}
