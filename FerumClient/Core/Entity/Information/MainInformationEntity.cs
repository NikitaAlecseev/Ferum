using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumClient.Entity
{
    public class MainInformationEntity
    {
        public string HostName { get; set; } // имя хоста
        public string LastShutdown { get; set; } // последнее выключение
        public string Uptime { get; set; } // последнее включение
        public string ModelMotherboard { get; set; } // модель материнки
        public string ModelProcessor { get; set; } // модель процессора
        public List<VideoCardEntity> ModelsVideoCard { get; set; } // модель видеокарты
        public List<UsersEntity> Users { get; set; } // пользователи на компьютере
        public List<RandomAccessMemory> RandomMemory { get; set; } // оперативная память
        public string VersionAgent { get; set; } // версия агента


        public MainInformationEntity(string hostName, string lastShutdown, string uptime, string modelMotherboard, string modelProcessor, List<VideoCardEntity> modelsVideoCard, List<UsersEntity> users, List<RandomAccessMemory> randomMemory, string versionAgent)
        {
            HostName = hostName;
            LastShutdown = lastShutdown;
            Uptime = uptime;
            ModelMotherboard = modelMotherboard;
            ModelProcessor = modelProcessor;
            ModelsVideoCard = modelsVideoCard;
            Users = users;
            RandomMemory = randomMemory;
            VersionAgent = versionAgent;        
        }
    }
}
