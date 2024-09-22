﻿using FerumClient.Core.Entity.Information;
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
        public TimeSpan LastRestartComputer { get; set; } // последняя перезагрузка
        public string ModelMotherboard { get; set; } // модель материнки
        public string ModelProcessor { get; set; } // модель процессора
        public List<VideoCardEntity> ModelsVideoCard { get; set; } // модель видеокарты
        public List<UsersEntity> Users { get; set; } // пользователи на компьютере
        public List<RandomAccessMemory> RandomMemory { get; set; } // оперативная память
        public List<HardInfo> HardDisks { get; set; } // жесткие диски
        public string CurrentProcess { get; set; } // текущий запущенный процесс
        public string VersionAgent { get; set; } // версия агента


        public MainInformationEntity(string hostName, TimeSpan lastRestartComputer, string modelMotherboard, string modelProcessor, List<VideoCardEntity> modelsVideoCard, List<UsersEntity> users, List<RandomAccessMemory> randomMemory, List<HardInfo> hardDisk, string currentProcess, string versionAgent)
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
            VersionAgent = versionAgent;
        }
    }
}
