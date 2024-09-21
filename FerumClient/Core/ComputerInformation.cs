using FerumClient.Core.Entity.Information;
using FerumClient.Core.Entity.RequestInformation;
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

        public static TimeSpan GetLastRestartPC()
        {
            SelectQuery query = new SelectQuery(@"SELECT LastBootUpTime FROM Win32_OperatingSystem WHERE Primary='true'");

            // create a new management object searcher and pass it
            // the select query
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(query);

            // get the datetime value and set the local boot
            // time variable to contain that value
            DateTime dtBootTime;
            TimeSpan result = new TimeSpan();

            foreach (ManagementObject mo in searcher.Get())
            {
                dtBootTime =
                    ManagementDateTimeConverter.ToDateTime(
                        mo.Properties["LastBootUpTime"].Value.ToString());

                result = DateTime.Now - dtBootTime;
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
                    hardInfo.TotalFreeMB = drive.TotalFreeSpace / (1024 * 1024);
                    hardInfo.TotalSizeMB = drive.TotalSize / (1024 * 1024);
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


        public static List<InstalledProgram> GetInstalledProgramsFromRegistry()
        {
            List<InstalledProgram> programs = new List<InstalledProgram>();

            // Открываем ключ реестра с информацией о программах
            const string Uninstall = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\";
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64), uninstallKey = hklm.OpenSubKey(Uninstall, RegistryKeyPermissionCheck.ReadSubTree))
            {
                // Перебираем все подключа
                foreach (string subKeyName in uninstallKey.GetSubKeyNames())
                {
                    // Открываем подключ для чтения
                    using (RegistryKey subKey = uninstallKey.OpenSubKey(subKeyName))
                    {
                        if (subKey != null)
                        {
                            // Извлекаем информацию о программе
                            string name = subKey.GetValue("DisplayName") as string;
                            string installLocation = subKey.GetValue("InstallLocation") as string;

                            // Добавляем программу в список
                            if (!string.IsNullOrEmpty(name))
                            {
                                programs.Add(new InstalledProgram(name, installLocation));
                            }
                        }
                    }
                }
            }

            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64), uninstallKey = hklm.OpenSubKey(Uninstall, RegistryKeyPermissionCheck.ReadSubTree))
            {
                // Перебираем все подключа
                foreach (string subKeyName in uninstallKey.GetSubKeyNames())
                {
                    // Открываем подключ для чтения
                    using (RegistryKey subKey = uninstallKey.OpenSubKey(subKeyName))
                    {
                        if (subKey != null)
                        {
                            // Извлекаем информацию о программе
                            string name = subKey.GetValue("DisplayName") as string;
                            string installLocation = subKey.GetValue("InstallLocation") as string;

                            // Добавляем программу в список
                            if (!string.IsNullOrEmpty(name))
                            {
                                programs.Add(new InstalledProgram(name, installLocation));
                            }
                        }
                    }
                }
            }

            // Сортируем список по полю Name по алфавиту
            programs = programs.OrderBy(p => p.Name).ToList();

            return programs;
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
