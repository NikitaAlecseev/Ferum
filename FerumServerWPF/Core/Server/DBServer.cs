using FerumServerWPF.Core.DB;
using FerumServerWPF.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumServerWPF.Core.Server
{
    public class DBServer
    {
        public DBServer() {
            EventSystem.EventGetInfoClient += GetJson;
        }

        private void GetJson(string _json)
        {
            if (_json.Contains("HostName")) clientInformationJson(_json); // если пришел json клиента с характеристиками
        }


        private void clientInformationJson(string json)
        {
            CommandDB command = new CommandDB();
            MainInformationEntity clientAllInfo = GetMainInfoClientFromJson(json);

            // проверяем, есть ли клиент в БД
            command.LoadData($"Select * From clients Where Hostname = '{clientAllInfo.HostName}'");


            if (command.MainTable.Rows.Count == 0) // если клиента в БД нет, то регаем его
            {
                registerClientToDB(clientAllInfo.HostName, json);
            }
            else // если клиент в БД есть, то обновляем данные
            {
                updateClientToDB(clientAllInfo.HostName, json);
            }

            sendClientToViewModel(clientAllInfo); // отправляем в ViewModel
        }

        private void registerClientToDB(string _host,string _json)
        {
            CommandDB command = new CommandDB();
            command.SendCommand($"Insert clients (Hostname,Information,DateUpdate) VALUES ('{_host}','{_json}',GETDATE())");
        }

        private void updateClientToDB(string _host, string _json)
        {
            CommandDB command = new CommandDB();
            command.SendCommand($"Update clients Set Information = '{_json}',DateUpdate = GETDATE() Where Hostname = '{_host}'");
        }

        private MainInformationEntity GetMainInfoClientFromJson(string _json)
        {
            return JsonConvert.DeserializeObject<MainInformationEntity>(_json);
        }

        private void sendClientToViewModel(MainInformationEntity _client)
        {
            EventSystem.InvokeSendClientToVM(_client);
        }
    }
}
