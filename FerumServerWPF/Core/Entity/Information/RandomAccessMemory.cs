using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumServerWPF.Entity
{
    public class RandomAccessMemory
    {
        public string Model { get; set; }
        public double MemoryMB { get; set; }
        public string MemoryGB { get { 
                return Math.Ceiling(MemoryMB / 1024).ToString() + " ГБ"; 
            } }

        public RandomAccessMemory(string model, double memoryMB)
        {
            Model = model;
            MemoryMB = memoryMB;
        }
    }
}
