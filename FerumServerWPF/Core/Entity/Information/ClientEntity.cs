﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FerumServerWPF.Entity
{
    public interface ClientEntity
    {
         string HostName { get; set; }
         string VersionAgent { get; set; }
         string CurrentProcess { get; set; }
         DateTime LastUpdateInformation { get; set; } // последнее обновление информации
    }
}
