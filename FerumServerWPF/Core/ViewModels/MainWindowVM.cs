using FerumServerWPF.Core.Server;
using FerumServerWPF.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

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
            EventSystem.EventSendClientToVM += getClient;
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
                if (ClientEntity[i].HostName == clientInfo.HostName)
                {
                    ClientEntity[i].VersionAgent = clientInfo.VersionAgent;
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
