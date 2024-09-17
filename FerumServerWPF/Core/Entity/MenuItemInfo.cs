using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumServerWPF.Entity
{
    public class MenuItemInfo
    {
        public string Name { get; set; }
        public string PathIcon { get; set; }

        public MenuItemInfo(string name, string pathIcon)
        {
            Name = name;
            PathIcon = pathIcon;
        }
    }
}
