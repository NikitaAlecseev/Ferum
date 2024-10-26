using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumServerWPF.Core.Entity.Client
{
    public class AnswerEntity
    {
        public string HostName { get; set; }
        public string Json { get; set; }
        public TypeAnswers AnswerType { get; set; }
        public enum TypeAnswers
        {
            None,
            Programs,
            RDP
        }
    }
}
