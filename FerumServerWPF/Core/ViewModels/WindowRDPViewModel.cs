using System;
using System.ComponentModel;
using System.Windows;
using FerumServerWPF.Core.Entity;
using FerumServerWPF.Core.RDP;
using FerumServerWPF.Core.Server;
using Newtonsoft.Json;
using Rdp.Terminal.Core.Client.Models;
using Rdp.Terminal.Core.Server;
using Rdp.Terminal.Core.WinApi;

using RDPCOMAPILib;

namespace FerumServerWPF.Core.ViewModels
{
    public class WindowRDPViewModel: INotifyPropertyChanged
    {
        private string _serverConnectionText;

        private string _teminalEventText;

        private bool _actionChoosen = false;

        public Visibility VisibleLoadIdentificator
        {
            get
            {
                if (ServerConnectionText == null || ServerConnectionText == "") return Visibility.Visible;
                else return Visibility.Collapsed;
            }
        }
        public Visibility VisibleRDPControl
        {
            get
            {
                if (ServerConnectionText != null && ServerConnectionText != "") return Visibility.Visible;
                else return Visibility.Hidden;
            }
        }

        private string Host { get; set; }

        /// <summary>
        /// Constructor <see cref="WindowRDPViewModel"/>.
        /// </summary>
        public WindowRDPViewModel(string _host)
        {
            Host = _host;

            RdpManager = new RdpManager() { SmartSizing = true };

            RdpManager.OnConnectionTerminated += (reason, info) => SessionTerminated();
            RdpManager.OnGraphicsStreamPaused += (sender, args) => SessionTerminated();
            RdpManager.OnAttendeeDisconnected += info => SessionTerminated();

            ConnectCommand = new DelegateCommand(Connect);
            ServerStartCommand = new DelegateCommand(ServerStart, o => !_actionChoosen);

            EventSystem.EventGetAnswerClient += getConnectionString;
        }

        private void getConnectionString(string json)
        {
            RDPConnectEntity rdpConnect = JsonConvert.DeserializeObject<RDPConnectEntity>(json);
            ServerConnectionText = rdpConnect.ServerConnectionText;
            ConnectionText = rdpConnect.ServerConnectionText;

            Connect(null);
        }

        /// <summary>
        /// Remote connection string.
        /// </summary>
        public string ConnectionText { get; set; }

        /// <summary>
        /// Server connection string.
        /// </summary>
        /// <remarks>For client in use.</remarks>
        public string ServerConnectionText
        {
            get
            {
                return _serverConnectionText;
            }

            set
            {
                _serverConnectionText = value;
                OnPropertyChanged("VisibleLoadIdentificator");
                OnPropertyChanged("VisibleRDPControl");
            }
        }

        /// <summary>
        /// RDP session manager.
        /// </summary>
        public RdpManager RdpManager { get; set; }

        /// <summary>
        /// Server start command.
        /// </summary>
        public DelegateCommand ServerStartCommand { get; private set; }

        /// <summary>
        /// Connect command.
        /// </summary>
        public DelegateCommand ConnectCommand { get; private set; }


        private string GroupName
        {
            get
            {
                return Environment.UserName;
            }
        }

        private string Password
        {
            get
            {
                return "Pa$$w0rrrd";
            }
        }

        private RdpSessionServer rdpSessia { get; set; }


        private void UnsupportingVersion()
        {
            MessageBox.Show("Поддержка только с Windows Vista","Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void SessionTerminated()
        {
            MessageBox.Show("Сеанс завершен","Информация",MessageBoxButton.OK,MessageBoxImage.Information);
        }


        private void ServerStart(object obj)
        {
            if (!SupportUtils.CheckOperationSytem())
            {
                UnsupportingVersion();
                return;
            }

            rdpSessia = new RdpSessionServer();
            rdpSessia.Open();

            ServerConnectionText = rdpSessia.CreateInvitation(GroupName, Password);
            ServerStarted();
        }

        private void ServerStarted()
        {
            _actionChoosen = true;
            ServerStartCommand.RaiseCanExecuteChanged();
        }

        public void Disconnect()
        {
            ServerSendCommand.Send(Host, "RDPDisconnect");
            ServerStartCommand.RaiseCanExecuteChanged();
            EventSystem.EventGetAnswerClient -= getConnectionString;
            RdpManager.Disconnect();
            RdpManager = null;
        }

        private void Connect(object obj)
        {
            RdpManager.Connect(ConnectionText, GroupName, Password);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
