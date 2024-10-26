using FerumServerWPF.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Newtonsoft.Json;
using FerumServerWPF.Core.DB;

namespace FerumServerWPF.Core.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        private MainInformationEntity infoEntity;
        public MainInformationEntity InfoEntity
        {
            get { return infoEntity; }
            set
            {
                infoEntity = value;
                OnPropertyChanged("InfoEntity");
                OnPropertyChanged("VisibleLoadIdentificator");
                OnPropertyChanged("VisibleInformationPanel");
            }
        }

        public Visibility VisibleLoadIdentificator
        {
            get {
                if (infoEntity == null) return Visibility.Visible;
                else return Visibility.Collapsed;
            }
        }

       
        public Visibility VisibleInformationPanel
        {
            get
            {
                if (infoEntity == null) return Visibility.Collapsed;
                else return Visibility.Visible;
            }
        }


        public MainVM(string _host)
        {
            loadData(_host);    
        }

        private void loadData(string _host)
        {
            CommandDB command = new CommandDB();
            command.LoadData($"Select Information From Clients Where Hostname = '{_host}'");
            string jsonString = command.MainTable.Rows[0][0].ToString();
            InfoEntity = JsonConvert.DeserializeObject<MainInformationEntity>(jsonString);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
