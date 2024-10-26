using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumClient.Core.Helper
{
    public class ErrorLog
    {
        public static void ScreenError(string _msg)
        {
            StreamWriter file = new StreamWriter($"{Environment.CurrentDirectory}\\logError.txt", true);
            file.WriteLine($"[{DateTime.Now}] - {_msg}");
            file.Close();
        }
    }
}
