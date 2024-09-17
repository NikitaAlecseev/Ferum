using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumServer.Core
{
    public class EventSystem
    {
        public delegate void HostInfo(string json);
        public static event HostInfo EventHostInfo;


        public static void InvokeEventHostInfo(string json)
        {
            EventHostInfo?.Invoke(json);
        }
    }
}
