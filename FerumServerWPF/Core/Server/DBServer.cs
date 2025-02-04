﻿using FerumEntities.Information;
using FerumServerWPF.Core.DB;
using Newtonsoft.Json;
using System;

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
            command.LoadData($"Select * From Clients Where Hostname = '{clientAllInfo.HostName}'");


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
            MainInformationEntity mainInformationEntity = GetMainInfoClientFromJson(_json);
            DateTime dateTime = DateTime.Now;
            command.SendCommand($"INSERT INTO Clients (Hostname,Information,DateUpdate,CurrentProcess,Version) VALUES ('{_host}','{_json}',datetime('now'),'','{mainInformationEntity.VersionAgent}')");
        }

        private void updateClientToDB(string _host, string _json)
        {
            CommandDB command = new CommandDB();
            MainInformationEntity mainInformationEntity = GetMainInfoClientFromJson(_json);
            DateTime dateTime = DateTime.Now;
            command.SendCommand($"Update Clients Set Information = '{_json}',DateUpdate = datetime('now'), CurrentProcess = '{mainInformationEntity.CurrentProcess}', Version = '{mainInformationEntity.VersionAgent}' Where Hostname = '{_host}'");
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
