using FerumServerWPF.Core.DB;
using FerumServerWPF.Core.Server;
using FerumServerWPF.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static FerumServerWPF.Core.EventSystem;

namespace FerumServerWPF.Core.ViewModels
{
    internal class MainWindowVM: INotifyPropertyChanged
    {
        private ObservableCollection<ClientEntity> clientEntity = new ObservableCollection<ClientEntity>();
        public ObservableCollection<ClientEntity> ClientEntity
        {
            get { return clientEntity; }
            set
            {
                clientEntity = value;
                OnPropertyChanged("ClientEntity");
            }
        }

        private ServerListener serverListener = new ServerListener();

        public MainWindowVM()
        {
            loadClients();
            EventSystem.EventSendClientToVM += getClient;
        }

        private void loadClients()
        {
            CommandDB command = new CommandDB();
            command.LoadData("Select * From Clients");
            for(int i = 0; i < command.MainTable.Rows.Count; i++)
            {
                MainInformationEntity clientInfo = JsonConvert.DeserializeObject<MainInformationEntity>(command.MainTable.Rows[i][2].ToString());
                ClientEntity.Add(new ClientEntity(clientInfo.HostName, false, false, DateTime.Parse(command.MainTable.Rows[i][3].ToString()), clientInfo.VersionAgent));
            }
        }

        private void getClient(MainInformationEntity clientInfo)
        {
            App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
            {
                if(!isExistsClient(clientInfo))
                    ClientEntity.Add(new ClientEntity(clientInfo.HostName, false, false, DateTime.Now,clientInfo.VersionAgent));
            });
        }

        private bool isExistsClient(MainInformationEntity clientInfo)
        {
            for(int i = 0; i < ClientEntity.Count; i++)
            {
                if (ClientEntity[i].HostName == clientInfo.HostName)
                {
                    updateClient(clientInfo);
                    return true;
                }
            }
            return false;
        }
        private void updateClient(MainInformationEntity clientInfo)
        {
            for (int i = 0; i < ClientEntity.Count; i++)
            {
                //ClientEntity.RemoveAt(i);
                if (ClientEntity[i].HostName == clientInfo.HostName)
                {
                    ClientEntity[i].VersionAgent = clientInfo.VersionAgent;
                    ClientEntity[i].LastUpdateInformation = DateTime.Now;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
