using FerumServerWPF.Core.Adapter;
using FerumServerWPF.Core.DB;
using FerumServerWPF.Core.Server;
using FerumServerWPF.Entity;
using Microsoft.Win32;
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
        private ObservableCollection<ClientAdapter> clientEntity = new ObservableCollection<ClientAdapter>();
        public ObservableCollection<ClientAdapter> ClientEntity
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
                ClientEntity.Add(new ClientAdapter(command.MainTable.Rows[i][1].ToString(), DateTime.Parse(command.MainTable.Rows[i][3].ToString()), command.MainTable.Rows[i][4].ToString(), command.MainTable.Rows[i][5].ToString()));
            }
        }

        private void getClient(MainInformationEntity clientInfo)
        {
            App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
            {
                if (!isExistsClient(clientInfo))
                {
                    ClientAdapter newClient = new ClientAdapter(clientInfo.HostName, DateTime.Now, clientInfo.CurrentProcess, clientInfo.VersionAgent);
                    newClient.UpdateIndicatorColor(null, null);
                    ClientEntity.Add(newClient);
                }

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
                    ClientEntity[i].CurrentProcess = clientInfo.CurrentProcess;
                    ClientEntity[i].UpdateIndicatorColor(null,null);
                    ClientEntity[i].UpdateGameStatus();
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
