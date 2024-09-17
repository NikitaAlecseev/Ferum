using FerumClient.Core.Entity.Information;
using FerumClient.Entity;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FerumClient.Core
{
    public class ComputerInformation
    {
        public static string GetHostInfo()
        {
            return Environment.MachineName;
        }

        public static string GetLastShutdownInfo()
        {
            string query = "SELECT * FROM Win32_OperatingSystem";
            string result = "";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    if (obj["LastBootUpTime"] != null)
                    {
                        DateTime lastBootUpTime = ManagementDateTimeConverter.ToDateTime(obj["LastBootUpTime"].ToString());
                        result = lastBootUpTime.AddDays(-1).ToString(); // Поскольку LastBootUpTime возвращает время последней загрузки
                    }
                }
            }
            return result;
        }

        public static string GetGPUModel()
        {
            string model = "";

            try
            {
                ManagementObjectSearcher searcher
                     = new ManagementObjectSearcher("SELECT * FROM Win32_DisplayConfiguration");

                foreach (ManagementObject mo in searcher.Get())
                {
                    foreach (PropertyData property in mo.Properties)
                    {
                        if (property.Name == "Description")
                        {
                            model = property.Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении модели видеокарты: {ex.Message}");
            }

            return model;
        }

        public static string GetUptimeInfo()
        {
            string result = "";

            string query = "SELECT LastBootUpTime FROM Win32_OperatingSystem";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    if (obj["LastBootUpTime"] != null)
                    {
                        result = ManagementDateTimeConverter.ToDateTime(obj["LastBootUpTime"].ToString()).ToString();
                        break; // Получаем только первое значение, так как оно должно быть единственным
                    }
                }
            }

            return result;
        }

        public static string GetMotherboardModel()
        {
            string model = "";

            try
            {
                string query = "SELECT Product FROM Win32_BaseBoard";
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        model = obj["Product"].ToString();
                        break; // Получаем только первое значение, так как оно должно быть единственным
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении модели материнской платы: {ex.Message}");
            }

            return model;
        }

        public static string GetProcessorModel()
        {
            string model = "";

            try
            {
                string query = "SELECT Name FROM Win32_Processor";
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        model = obj["Name"].ToString();
                        break; // Получаем только первое значение, так как оно должно быть единственным
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении модели процессора: {ex.Message}");
            }

            return model;
        }

        public static List<UsersEntity> GetUsersInfo()
        {
            List<UsersEntity> users = new List<UsersEntity>();

            var windowsIdentity = WindowsIdentity.GetCurrent();
            var windowsPrincipal = new WindowsPrincipal(windowsIdentity);
            var currrentUserName = windowsPrincipal.Identity.Name;
            users.Add(new UsersEntity(currrentUserName, true));



            const string Uninstall = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\SessionData\";
            using (RegistryKey
                hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64),
                key = hklm.OpenSubKey(Uninstall, RegistryKeyPermissionCheck.ReadSubTree))
            {
                if (key != null)
                {
                    foreach (string subKeyName in key.GetSubKeyNames())
                    {
                        using (RegistryKey subKey = key.OpenSubKey(subKeyName))
                        {
                            string login = subKey.GetValue("LoggedOnUser") as string;
                            if(login != currrentUserName)
                            {
                                users.Add(new UsersEntity(login, false));
                            }
                        }                 
                    }             
                }
            }
                return users;
        }

        public static List<RandomAccessMemory> GetRandomAccessMemory()
        {
            List<RandomAccessMemory> outResult = new List<RandomAccessMemory>();

            // Получаем объект ManagementObjectSearcher для запроса информации о системе
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");

            // Выполняем запрос
            ManagementObjectCollection results = searcher.Get();

            // Выводим информацию о системе
            foreach (ManagementObject result in results)
            {
                // Модель компьютера
                string model = result["Model"].ToString();

                // Объем оперативной памяти
                ulong totalPhysicalMemory = (ulong)result["TotalPhysicalMemory"];
                double memoryMB = (double)totalPhysicalMemory / (1024 * 1024);

                outResult.Add(new RandomAccessMemory(model, memoryMB));
            }

            return outResult;
        }

        public static List<string> GetInstalledProgramsInfo()
        {
            List<string> results = new List<string>();

            using (var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
            {
                var subKeys = key.GetSubKeyNames();

                foreach (var subKeyName in subKeys)
                {
                    using (var subKey = key.OpenSubKey(subKeyName))
                    {
                        var displayName = subKey.GetValue("DisplayName") as string;
                        if (!string.IsNullOrEmpty(displayName))
                        {
                            results.Add(displayName);
                        }
                    }
                }
            }

            return results;
        }

        public static List<HardInfo> GetHardDisks()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            List<HardInfo> hardDisks = new List<HardInfo>();

            // Вывод информации о каждом диске
            foreach (DriveInfo drive in drives)
            {
                // Проверка, доступен ли диск для чтения
                if (drive.IsReady)
                {
                    HardInfo hardInfo = new HardInfo();
                    hardInfo.Name = drive.VolumeLabel.ToString();
                    hardInfo.Symbol = drive.RootDirectory.Name;
                    hardInfo.TotalFree = drive.TotalFreeSpace.ToString();
                    hardInfo.TotalSize = drive.TotalSize.ToString();
                    hardDisks.Add(hardInfo);
                }
            }
            return hardDisks;
        }


        public static List<VideoCardEntity> GetVideoCardEntity()
        {
            List<VideoCardEntity> outVideoCards = new List<VideoCardEntity>();

            // Получаем объект ManagementObjectSearcher для запроса информации о видеокартах
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");

            // Выполняем запрос
            ManagementObjectCollection results = searcher.Get();

            // Выводим информацию о видеокартах
            Console.WriteLine("Информация о видеокартах:");
            foreach (ManagementObject result in results)
            {
                // Модель видеокарты
                string model = result["Name"].ToString();

                // Объем памяти видеокарты
                //ulong memorySize = (ulong)result["AdapterRAM"];
                //double memoryMB = (double)memorySize / (1024 * 1024);

                outVideoCards.Add(new VideoCardEntity(model,"0"));
            }


            return outVideoCards;
        }


        //public static List<ProcessEntity> GetActiveProcess()
        //{
        //    List<ProcessEntity> processEntityList = new List<ProcessEntity>();

        //    IntPtr handle = GetForegroundWindow();
        //    StringBuilder windowText = new StringBuilder(256);
        //    if (GetWindowText(handle, windowText, windowText.Capacity) > 0)
        //    {
        //        ProcessEntity processEntity = new ProcessEntity();
        //        processEntity.TitleProcess = windowText.ToString();
        //        processEntityList.Add(processEntity);
        //    }

        //    return processEntityList;
        //}
        //public static List<ProcessEntity> GetAllProcessEntityList()
        //{
        //    List<ProcessEntity> processEntityList = new List<ProcessEntity>();

        //    Process[] proceses = Process.GetProcesses();
        //    foreach (var process in proceses)
        //    {
        //        try
        //        {
        //            ProcessEntity processEntity = new ProcessEntity();
        //            processEntity.TitleProcess = process.ProcessName;
        //            processEntityList.Add(processEntity);
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }

        //    return processEntityList;
        //}


        #region libTitleWindowProcess
        // Импорт функции из user32.dll для получения активного окна
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        #endregion
    }
}
