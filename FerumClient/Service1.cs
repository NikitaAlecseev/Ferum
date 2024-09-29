using FerumClient.Core.Entity.Information;
using FerumClient.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FerumClient.Entity;
using FerumClient.Core.ComputerInformation;

namespace FerumClient
{
    public partial class Service1 : ServiceBase
    {
        private static Timer _timer;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Task.Run(() => startClient());
        }

        protected override void OnStop()
        {
        }

        public static void startClient()
        {
            _timer = new Timer(SendHostInfo.SendHost, null, TimeSpan.Zero, TimeSpan.FromMinutes(1.5));
            ListenerCommand listenerCommand = new ListenerCommand();

            while (true)
            {
                // Получение информации о хосте
                var hostInfo = Computer.GetHostInfo();

                // Получение информации о последней перезагрузки
                var lastTimeRestart = Computer.GetLastRestartPC();

                // Получение информации о последнем пользователе
                var usersInfo = Computer.GetUsersInfo();

                // Получение информации о оперативной памяти ПК
                var getRAM = Computer.GetRandomAccessMemory();

                // Получить модель видеокарты
                string modelGPU = Computer.GetGPUModel();

                // Получить модель материнки
                string modelMotherboard = Computer.GetMotherboardModel();

                // Получить модель процессор
                string modelProcessorModel = Computer.GetProcessorModel();

                // Получаем сетевые адаптер
                List<NetworkEntity> networkEntities = NetworkInfo.GetNetworkEntities();

                // Получаем оперативную память
                List<RandomAccessMemory> randomAccessMemories = Computer.GetRandomAccessMemory();

                // Получаем модели видеокарт
                List<VideoCardEntity> videoCards = Computer.GetVideoCardEntity();

                // Получаем активное окно
                string currentProcess = Computer.GetActiveProcess();

                // Получение информации о списке установленных программ
                //List<string> installedProgramsInfo = ComputerInformation.GetInstalledProgramsInfo();

                // Получение информации о списке активных процессов
                //List<ProcessEntity> activeProcess = ComputerInformation.GetAllProcessEntityList();

                // Получение информации о дисках
                List<HardInfo> hardDisks = Computer.GetHardDisks();

                // Создание объекта с информацией о хосте
                MainInformationEntity hostObj = new MainInformationEntity(hostInfo, lastTimeRestart, modelMotherboard, modelProcessorModel, videoCards, usersInfo, randomAccessMemories, hardDisks, currentProcess, networkEntities, "v0.8.1");

                // Сериализация информации о хосте в формат JSON
                string jsonString = JsonConvert.SerializeObject(hostObj);

                // Отправка информации о хосте на сервер
                SendHostInfo.SendHost(jsonString);

                // Ожидание 1 минут перед следующей записью
                Thread.Sleep(60000);
            }
        }
    }
}
