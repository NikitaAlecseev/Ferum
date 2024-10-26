using FerumEntities.Information;
using FerumServerWPF.Core.DB;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Threading;

namespace FerumServerWPF.Core.Adapter
{
    public class ClientAdapter : ClientEntity, INotifyPropertyChanged
    {
        public string HostName { get; set; }
        public string VersionAgent { get; set; }
        public string CurrentProcess { get; set; }

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

        private Visibility gameModeVisibleUI { get; set; }
        public Visibility GameModeVisibleUI
        {
            set
            {
                gameModeVisibleUI = value;
                OnPropertyChanged("GameModeVisibleUI");
            }
            get
            {
                return gameModeVisibleUI;
            }
        }

        public Visibility WarningVisibleUI
        {
            get
            {
                return Visibility.Collapsed;
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

        public ClientAdapter(string hostName, DateTime lastUpdateInformation,string currentProcess, string versionAgent)
        {
            HostName = hostName;
            LastUpdateInformation = lastUpdateInformation;
            CurrentProcess = currentProcess;
            VersionAgent = versionAgent;

            startUpdateIndicator();
            UpdateGameStatus();
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
            if (result.Days <= 0 && result.Hours <= 0 && result.Minutes < 2)
            {
                ColorIndicator = "#4AD719"; // зеленный
            }
            else
            {
                ColorIndicator = "#D71919"; // красный
                GameModeVisibleUI = Visibility.Collapsed;
            }
        }
        public void UpdateGameStatus()
        {
            if (colorIndicator == "#d7b919") // если клиент пока не определен (в сети)
            {
                GameModeVisibleUI = Visibility.Collapsed;
                return;
            }

            CommandDB command = new CommandDB();
            string[] words = Regex.Split(CurrentProcess, @"[\s.,!?;:-]");

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == "") continue;
                if (words[i].Length < 4) continue;

                command.LoadData($"Select * From ListGames Where NameGame like '%{words[i]}%'");
                if(command.MainTable.Rows.Count > 0)
                {
                    GameModeVisibleUI = Visibility.Visible;
                    return;
                }
            }
            GameModeVisibleUI = Visibility.Collapsed;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
