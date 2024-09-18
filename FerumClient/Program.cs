using FerumClient.Core;
using FerumClient.Core.Entity.Information;
using FerumClient.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FerumClient
{
    internal static class Program
    {
        private static Timer _timer;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main()
        {
            startClient();
        }

        public static void startClient()
        {
            _timer = new Timer(SendHostInfo.SendHost, null, TimeSpan.Zero, TimeSpan.FromMinutes(1.5));
            ListenerCommand listenerCommand = new ListenerCommand();

            while (true)
            {
                // Получение информации о хосте
                var hostInfo = ComputerInformation.GetHostInfo();


                // Получение информации о последней перезагрузки
                var lastTimeRestart = ComputerInformation.GetLastRestartPC();

                // Получение информации о последнем пользователе
                var usersInfo = ComputerInformation.GetUsersInfo();

                // Получение информации о оперативной памяти ПК
                var getRAM = ComputerInformation.GetRandomAccessMemory();

                // Получить модель видеокарты
                string modelGPU = ComputerInformation.GetGPUModel();

                // Получить модель материнки
                string modelMotherboard = ComputerInformation.GetMotherboardModel();

                // Получить модель процессор
                string modelProcessorModel = ComputerInformation.GetProcessorModel();

                // Получаем оперативную память
                List<RandomAccessMemory> randomAccessMemories = ComputerInformation.GetRandomAccessMemory();

                // Получаем модели видеокарт
                List<VideoCardEntity> videoCards = ComputerInformation.GetVideoCardEntity();

                // Получение информации о списке установленных программ
                //List<string> installedProgramsInfo = ComputerInformation.GetInstalledProgramsInfo();

                // Получение информации о списке активных процессов
                //List<ProcessEntity> activeProcess = ComputerInformation.GetAllProcessEntityList();

                // Получение информации о дисках
                List<HardInfo> hardDisks = ComputerInformation.GetHardDisks();

                // Создание объекта с информацией о хосте
                MainInformationEntity hostObj = new MainInformationEntity(hostInfo, lastTimeRestart, modelMotherboard,modelProcessorModel, videoCards, usersInfo,randomAccessMemories, hardDisks, "v0.5");

                // Сериализация информации о хосте в формат JSON
                string jsonString = JsonConvert.SerializeObject(hostObj);

                // Отправка информации о хосте на сервер
                SendHostInfo.SendHost(jsonString);

                // Ожидание 1 минут перед следующей записью
                Thread.Sleep(60000);
            }
        }
        public static void startService()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
