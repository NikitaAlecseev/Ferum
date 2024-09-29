using FerumClient.Core;
using FerumClient.Core.Entity.Information;
using FerumClient.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FerumClient
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                if(args != null && args.Length > 0)
                {
                    switch(args[0])
                    {
                        case "--install":
                            try
                            {
                                InstallService();
                            }
                            catch(Exception ex)
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
