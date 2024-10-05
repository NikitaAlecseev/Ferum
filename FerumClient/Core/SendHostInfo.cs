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
        public static void SendHost(object state)
        {
            var jsonString = state as string;

            if (string.IsNullOrEmpty(jsonString))
            {
                return;
            }

            try
            {
                using (var client = new TcpClient(GlobalVar.IPServer, Convert.ToInt32(GlobalVar.MainPort)))
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


        /// <summary>
        /// Отправка ответа по запросу
        /// </summary>
        /// <param name="state"></param>
        public static void SendHostRequest(object state)
        {
            var jsonString = state as string;

            if (string.IsNullOrEmpty(jsonString))
            {
                return;
            }

            try
            {
                using (var client = new TcpClient(GlobalVar.IPServer, Convert.ToInt32(GlobalVar.RequestPort)))
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
