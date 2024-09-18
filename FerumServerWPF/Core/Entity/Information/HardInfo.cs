using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumServerWPF.Core.Entity.Information
{
    public class HardInfo
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double TotalFree { get; set; }
        public double TotalSize { get; set; }

        public string GetFullName
        {
            get
            {
                return $"{Name} ({Symbol})"; 
            }
        }
        public int TotalValueProgressBar
        {
            get { return Convert.ToInt32((TotalSize - TotalFree)); }
        }
        public string GetStringSize
        {
            get
            {
                return $"{TotalFree} ГБ свободно из {TotalSize} ГБ";
            }
        }

        public string ColorBar { get
            {
                double Percent = (TotalFree / 100) * TotalSize;
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
