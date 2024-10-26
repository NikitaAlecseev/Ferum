using FerumServerWPF.Core.Server;
using FerumServerWPF.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FerumServerWPF
{
    /// <summary>
    /// Логика взаимодействия для WindowRDP.xaml
    /// </summary>
    public partial class WindowRDP : Window
    {
        private WindowRDPViewModel viewModel;
        public WindowRDP(string _host)
        {
            viewModel = new WindowRDPViewModel(_host);
            DataContext = viewModel;
            InitializeComponent();

            ServerSendCommand.Send(_host, "RDP");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            viewModel.Disconnect();
        }
    }
}
