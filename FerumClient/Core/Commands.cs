using FerumClient.Core.ComputerInformation;
using FerumClient.Core.Entity.RequestInformation;
using FerumClient.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FerumClient.Core
{
    public class Commands
    {
        public static void Send(string _command, string _param = "")
        {
            switch (_command)
            {
                case "Open":
                    System.Diagnostics.Process.Start("calc.exe");
                    break;
                case "Lock":
                    LockWorkStation();
                    break;
                case "Cmd":
                    System.Diagnostics.Process.Start("CMD.exe", _param);
                    break;
                case "Disconect":
                    Process.GetCurrentProcess().Kill();
                    break;
                case "Kill Process":
                    foreach (var process in Process.GetProcessesByName(_param))
                    {
                        process.Kill();
                    }
                    break;
                case "Get Process":
                    //List<ProcessEntity> listProcess = ComputerInformation.GetAllProcessEntityList();
                    //string jsonString = JsonConvert.SerializeObject(listProcess);
                    //SendHostInfo.SendHost(jsonString);
                    break;
                case "Get Programs":
                    List<InstalledProgram> installed = Computer.GetInstalledProgramsFromRegistry();
                    string json = JsonConvert.SerializeObject(installed);
                    SendHostInfo.SendHostRequest(json);
                    break;
            }
        }



        [DllImport("user32.dll")]
        public static extern void LockWorkStation();
    }
}
