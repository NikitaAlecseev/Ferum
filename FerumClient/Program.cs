using FerumClient.Core;
using FerumClient.Core.ComputerInformation;
using FerumEntities.Information;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;

namespace FerumClient
{
    internal static class Program
    {
        private static Timer _timer;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main(string[] args)
        {
            LoadValueServer();
            startClient();
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
                MainInformationEntity hostObj = new MainInformationEntity(hostInfo, lastTimeRestart, modelMotherboard, modelProcessorModel, videoCards, usersInfo, randomAccessMemories, hardDisks, currentProcess, networkEntities, "v1.5");

                // Сериализация информации о хосте в формат JSON
                string jsonString = JsonConvert.SerializeObject(hostObj);

                // Отправка информации о хосте на сервер
                SendHostInfo.SendHost(jsonString);

                // Ожидание 1 минут перед следующей записью
                Thread.Sleep(60000);
            }
        }
        

        /// <summary>
        /// Загрузка информации о сервере из реестра
        /// </summary>
        private static void LoadValueServer()
        {
            const string PathReg = @"SOFTWARE\WOW6432Node\PineDeveloper\FerumClient\";

            // Попытка открыть ключ реестра
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(PathReg))
            {
                if (key != null)
                {
                    GlobalVar.IPServer = key.GetValue("IPServer") as string;
                    GlobalVar.MainPort = key.GetValue("MainPort") as string;
                    GlobalVar.RequestPort = key.GetValue("RequestPort") as string;
                }
            }

            GlobalVar.HostName = Computer.GetHostInfo();
        }

        private static void MainInstall(string[] args)
        {
            if (Environment.UserInteractive)
            {
                if (args != null && args.Length > 0)
                {
                    switch (args[0])
                    {
                        case "--install":
                            try
                            {
                                InstallService();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.ToString());
                            }
                            break;
                        case "--uninstall":
                            try
                            {
                                UninstallService();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.ToString());
                            }
                            break;
                    }
                }
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new Service1()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
       
        public static void InstallService()
        {
            var appPath = Assembly.GetExecutingAssembly().Location;
            System.Configuration.Install.ManagedInstallerClass.InstallHelper(new string[] { appPath });

            string serviceName = "FerumService";
            // Получение объекта ServiceController для заданной службы
            ServiceController service = new ServiceController(serviceName);

            // Проверка, запущена ли служба
            if (service.Status == ServiceControllerStatus.Stopped ||
                service.Status == ServiceControllerStatus.Paused)
            {
                // Запуск службы
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running);

                Console.WriteLine($"Служба '{serviceName}' успешно запущена.");
            }
            else
            {
                Console.WriteLine($"Служба '{serviceName}' уже запущена.");
            }
        }

        public static void UninstallService()
        {
            var appPath = Assembly.GetExecutingAssembly().Location;
            System.Configuration.Install.ManagedInstallerClass.InstallHelper(new string[] { "/u", appPath });

            // Запускаем команду sc.exe для удаления службы
            ProcessStartInfo startInfo = new ProcessStartInfo("sc", $"delete FerumService");
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;

            Process process = Process.Start(startInfo);
            string output = process.StandardOutput.ReadToEnd();

            // Выводим результат команды
            Console.WriteLine(output);

            // Проверяем, успешно ли удалена служба
            if (output.Contains("Удаление службы успешно завершено"))
            {
                Console.WriteLine($"Служба FerumService успешно удалена.");
            }
            else
            {
                Console.WriteLine($"Ошибка при удалении службы: {output}");
            }

            KillClient();
        }

        public static void KillClient()
        {
            // Получаем все запущенные процессы
            Process[] processes = Process.GetProcessesByName("FerumClient");

            // Проверяем, найден ли процесс
            if (processes.Length > 0)
            {
                // Завершаем первый найденный процесс
                processes[0].Kill();
                Console.WriteLine($"Процесс 'FerumClient' успешно завершен.");
            }
            else
            {
                Console.WriteLine($"Процесс 'FerumClient' не найден.");
            }
        }

    }
}
