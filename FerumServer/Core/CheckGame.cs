using FerumServer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumServer.Core
{
    public class CheckGame
    {
        public bool isPlaying(List<ProcessEntity> _process)
        {
            if (_process == null) return false;

            for(int i = 0;i< _process.Count;i++)
            {
                if (_process[i].TitleProcess.Contains("steam")) return true;
                else if (_process[i].TitleProcess.Contains("banana")) return true;
                else if (_process[i].TitleProcess.Contains("counter strike")) return true;
            }
            return false;
        }
    }
}
