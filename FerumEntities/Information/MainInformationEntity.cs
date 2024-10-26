using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumEntities.Information
{
    public class MainInformationEntity
    {
        public string HostName { get; set; } // имя хоста
        public TimeSpan LastRestartComputer { get; set; } // последняя перезагрузка
        public string ModelMotherboard { get; set; } // модель материнки
        public string ModelProcessor { get; set; } // модель процессора
        public List<VideoCardEntity> ModelsVideoCard { get; set; } // модель видеокарты
        public List<UsersEntity> Users { get; set; } // пользователи на компьютере
        public List<RandomAccessMemory> RandomMemory { get; set; } // оперативная память
        public List<HardInfo> HardDisks { get; set; } // жесткие диски
        public List<NetworkEntity> Networks { get; set; } // Сетевые настройки
        public string CurrentProcess { get; set; } // текущий запущенный процесс
        public string VersionAgent { get; set; } // версия агента

        public string GetLastRestartComputer { get { return $"{LastRestartComputer.Days} д. {LastRestartComputer.Hours} ч. {LastRestartComputer.Minutes} мин. {LastRestartComputer.Seconds} сек."; } }


        public MainInformationEntity(string hostName, TimeSpan lastRestartComputer, string modelMotherboard, string modelProcessor, List<VideoCardEntity> modelsVideoCard, List<UsersEntity> users, List<RandomAccessMemory> randomMemory, List<HardInfo> hardDisk, string currentProcess, List<NetworkEntity> networks, string versionAgent)
        {
            HostName = hostName;
            LastRestartComputer = lastRestartComputer;
            ModelMotherboard = modelMotherboard;
            ModelProcessor = modelProcessor;
            ModelsVideoCard = modelsVideoCard;
            Users = users;
            RandomMemory = randomMemory;
            HardDisks = hardDisk;
            CurrentProcess = currentProcess;
            Networks = networks;
            VersionAgent = versionAgent;
        }
    }
}
