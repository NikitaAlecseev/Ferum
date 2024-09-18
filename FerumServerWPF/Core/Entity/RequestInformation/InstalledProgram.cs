using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumServerWPF.Core.Entity.RequestInformation
{
    public class InstalledProgram
    {
        public string Name { get; set; }
        public string InstallLocation { get; set; }

        public InstalledProgram(string name, string installLocation)
        {
            Name = name;
            InstallLocation = installLocation;
        }
    }
}
