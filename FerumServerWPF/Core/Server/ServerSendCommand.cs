﻿using FerumEntities.Client;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace FerumServerWPF.Core.Server
{
    public class ServerSendCommand
    {
        public static void Send(string _host, string _command, string _param = "")
        {
            new Thread(() =>
            {
                Command command = new Command();
                command.command = _command;
                command.parametr = _param;

                // Сериализация информации о хосте в формат JSON
                string jsonString = JsonConvert.SerializeObject(command);

                if (string.IsNullOrEmpty(jsonString))
                {
                    return;
                }

                try
                {
                    using (var client = new TcpClient(_host, 2001))
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
            }).Start();
        }
    }
}
