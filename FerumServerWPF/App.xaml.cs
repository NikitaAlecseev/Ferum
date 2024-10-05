using FerumServerWPF.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FerumServerWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            LoadDataFromReg();
        }


        /// <summary>
        /// Загрузка информации о сервере SQL из реестра (+порты для клиента)
        /// </summary>
        private void LoadDataFromReg()
        {
            const string PathReg = @"SOFTWARE\PineDeveloper\FerumServer\";
            // Попытка открыть ключ реестра
            using (RegistryKey
                hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64),
                key = hklm.OpenSubKey(PathReg, RegistryKeyPermissionCheck.ReadSubTree))
            {
                if (key != null)
                {
                    GlobalVar.SQLServer = key.GetValue("SqlServer") as string;
                    GlobalVar.LoginSQL = key.GetValue("LoginSql") as string;
                    GlobalVar.PasswordSQL = key.GetValue("PasswordSql") as string;
                    GlobalVar.MainPort = key.GetValue("MainPort") as string;
                    GlobalVar.RequestPort = key.GetValue("RequestPort") as string;
                }
            }
        }
    }
}
