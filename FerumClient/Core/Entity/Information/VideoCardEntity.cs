using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumClient.Entity
{
    public class VideoCardEntity
    {
        public string Model { get; set; }
        public string memoryMB { get; set; }

        public VideoCardEntity(string model, string memoryMB)
        {
            Model = model;
            this.memoryMB = memoryMB;
        }
    }
}
