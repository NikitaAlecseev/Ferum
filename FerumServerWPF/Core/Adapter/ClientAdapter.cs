using FerumServerWPF.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using static Mysqlx.Crud.UpdateOperation.Types;

namespace FerumServerWPF.Core.Adapter
{
    public class ClientAdapter : ClientEntity, INotifyPropertyChanged
    {
        public string HostName { get; set; }
        public string VersionAgent { get; set; }
        public bool GameMode { get; set; }
        public bool Warning { get; set; }

        private DateTime lastUpdateInformation { get; set; }
        public DateTime LastUpdateInformation {
            get 
            {
                return lastUpdateInformation; 
            } set
            {
                lastUpdateInformation = value;
                OnPropertyChanged("ColorIndicator");
            }
        }

        public Visibility GameModeVisibleUI
        {
            get
            {
                if (GameMode)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }

        public Visibility WarningVisibleUI
        {
            get
            {
                if (Warning)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }

        private string colorIndicator = "#d7b919";
        public string ColorIndicator
        {
            set
            {
                colorIndicator = value;
                OnPropertyChanged("ColorIndicator");
            }
            get
            {
                return colorIndicator;
            }
        }

        DispatcherTimer updateIndicator = new DispatcherTimer();

        public ClientAdapter(string hostName, bool gameMode, bool warning, DateTime lastUpdateInformation, string versionAgent)
        {
            HostName = hostName;
            GameMode = gameMode;
            Warning = warning;
            LastUpdateInformation = lastUpdateInformation;
            VersionAgent = versionAgent;

            startUpdateIndicator();
        }

        private void startUpdateIndicator()
        {
            updateIndicator.Tick += new EventHandler(UpdateIndicatorColor);
            updateIndicator.Interval = new TimeSpan(0, 1, 10);
            updateIndicator.Start();
        }

        public void UpdateIndicatorColor(object sender, EventArgs e)
        {
            TimeSpan result = DateTime.Now - LastUpdateInformation;
            if (result.Minutes < 2)
            {
                ColorIndicator = "#4AD719"; // зеленный
            }
            else
            {
                ColorIndicator = "#d71919"; // красный
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
