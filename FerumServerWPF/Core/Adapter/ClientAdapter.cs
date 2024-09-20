using FerumServerWPF.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumServerWPF.Core.Adapter
{
    public class ClientAdapter : ClientEntity
    {
        public ClientAdapter(string hostName, bool gameMode, bool warning, DateTime lastUpdateInformation, string versionAgent) : base(hostName, gameMode, warning, lastUpdateInformation, versionAgent)
        {
            HostName = hostName;
        }
    }
}
