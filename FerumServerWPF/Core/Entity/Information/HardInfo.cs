using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FerumServerWPF.Core.Entity.Information
{
    public class HardInfo
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double TotalFreeMB { get; set; }
        public double TotalSizeMB { get; set; }

        public string GetFullName
        {
            get
            {
                if (Name == "") Name = "Локальный диск";
                return $"{Name} ({Symbol})"; 
            }
        }
        public int TotalValueProgressBar
        {
            get { return Convert.ToInt32(100 - ((TotalFreeMB * 100) / TotalSizeMB)); }
        }
        public string GetStringSize
        {
            get
            {
                return $"{(TotalFreeMB / 1024)} ГБ свободно из {(TotalSizeMB / 1024)} ГБ";
            }
        }

        public string ColorBar { get
            {
                double Percent = 100 - (TotalFreeMB * 100) / TotalSizeMB;
                if(Percent < 90)
                {
                    return "#296688";
                }
                else
                {
                    return "#882929";
                }
            } 
        }
    }
}
