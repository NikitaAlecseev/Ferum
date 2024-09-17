using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FerumClient.Entity
{
    public class ClientEntity
    {
        public string HostName { get; set; }
        public string VersionAgent { get; set; }
        public bool GameMode { get; set; }
        public bool Warning { get; set; }
        public DateTime LastUpdateInformation { get; set; } // последнее обновление информации



        public ClientEntity(string hostName, bool gameMode, bool warning, DateTime lastUpdateInformation, string versionAgent)
        {
            HostName = hostName;
            GameMode = gameMode;
            Warning = warning;
            LastUpdateInformation = lastUpdateInformation;
            VersionAgent = versionAgent;
        }
    }
}
