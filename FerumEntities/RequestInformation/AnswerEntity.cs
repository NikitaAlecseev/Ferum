using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumEntities.RequestInformation
{
    public class AnswerEntity
    {
        public AnswerEntity(string hostName, string json, TypeAnswers answerType)
        {
            HostName = hostName;
            Json = json;
            AnswerType = answerType;
        }

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
