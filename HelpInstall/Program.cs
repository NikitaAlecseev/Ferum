using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HelpInstall
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string mode = args[0];
                switch (mode)
                {
                    case "Inst":
                        string path = args[1].Replace("\"", "");
                        SetAutoUpload(path);
                        CheckPermission.checkAndSetPermission(path);
                        Console.Read();
                        break;
                    case "Uninst":
                        if (IsAdministrator())
                        {
                            Console.WriteLine("Запущено от имени админа!");
                        }
                        else
                        {
                            Console.WriteLine("Нет прав администратора!");
                        }

                        DeleteRegistryKey("FerumClient");
                        CheckPermission.DeleteFirewallRule();


                        // Создание файла в папке установки 
                        string filePath = Path.Combine("C:/Debug/", "test.txt");
                        File.WriteAllText(filePath, "Удалено!");

                        Console.Read();
                        break;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
                Console.Read();
            }
        }
        /// <summary>
        /// Добавление себя в автозагрузку
        /// </summary>
        public static void SetAutoUpload(string _path)
        {
            // Путь к ключу реестра
            string registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            string keyName = "FerumClient";
            string value = _path + "\\FerumClient.exe";

            // Проверка, существует ли ключ
            if (!KeyExists(registryPath, keyName))
            {
                // Создание ключа
                CreateRegistryKey(registryPath, keyName, value);
                Console.WriteLine($"Ключ '{keyName}' создан в реестре.");
            }
            else
            {
                Console.WriteLine($"Ключ '{keyName}' уже существует.");
            }
        }
        // Проверка существования ключа
        static bool KeyExists(string path, string keyName)
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(path))
            {
                return key != null && key.GetValue(keyName) != null;
            }
        }

        // Создание ключа реестра
        static void CreateRegistryKey(string path, string keyName, string value)
        {
            using (RegistryKey key = Registry.LocalMachine.CreateSubKey(path))
            {
                if (key != null)
                {
                    key.SetValue(keyName, value);
                }
            }
        }

        public static void DeleteRegistryKey(string keyName)
        {
            try
            {
                string pathKey = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Run";

                RegistryKey key = Registry.LocalMachine.OpenSubKey(pathKey, true);

                if (key != null)
                {
                    key.DeleteValue(keyName, false);
                    Console.WriteLine($"Ключ \"{keyName}\" успешно удален.");
                }
                else
                {
                    Console.WriteLine($"Ключ \"{keyName}\" не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении ключа: {ex.Message}");
            }
        }

        public static bool IsAdministrator()
        {
            if (Environment.UserInteractive && !Process.GetCurrentProcess().HasExited)
            {
                using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
                {
                    WindowsPrincipal principal = new WindowsPrincipal(identity);
                    return principal.IsInRole(WindowsBuiltInRole.Administrator);
                }
            }

            return false;
        }
    }
}
