using FerumServerWPF.Core.Adapter;
using FerumServerWPF.Core.Server;
using FerumServerWPF.Core.ViewModels;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace FerumServerWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsMaximized = false;
        private MainWindowVM viewModel = new MainWindowVM();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;
                    IsMaximized = false;
                    MainBorder.CornerRadius = new CornerRadius(15);
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = true;
                    MainBorder.CornerRadius = new CornerRadius(0);
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                MainBorder.CornerRadius = new CornerRadius(0);
            }
            else
            {
                WindowState = WindowState.Normal;
                MainBorder.CornerRadius = new CornerRadius(15);
            }

        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
            MainBorder.CornerRadius = new CornerRadius(15);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Open(object sender, RoutedEventArgs e)
        {
            ClientAdapter adapter = listClients.SelectedItem as ClientAdapter;

            WindowView windView = new WindowView(adapter.HostName);
            windView.Show();
        }

        private void MenuItem_GetCurrentProcess(object sender, RoutedEventArgs e)
        {
            ClientAdapter adapter = listClients.SelectedItem as ClientAdapter;
            MessageBox.Show(adapter.CurrentProcess, "Текущий процесс", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MenuItem_Disconect(object sender, RoutedEventArgs e)
        {
            ClientAdapter adapter = listClients.SelectedItem as ClientAdapter;
            ServerSendCommand.Send(adapter.HostName, "Disconect");
        }

        private void MenuItem_RDP(object sender, RoutedEventArgs e)
        {
            ClientAdapter adapter = listClients.SelectedItem as ClientAdapter;
            WindowRDP windowRDP = new WindowRDP(adapter.HostName);
            windowRDP.Show();
        }
        private void MenuItem_Shutdown(object sender, RoutedEventArgs e)
        {
            ClientAdapter adapter = listClients.SelectedItem as ClientAdapter;
            if(MessageBox.Show($"Вы уверены, что хотите выключить {adapter.HostName}?","Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                ServerSendCommand.Send(adapter.HostName, "Shutdown");
            }
        }
        private void MenuItem_Restart(object sender, RoutedEventArgs e)
        {
            ClientAdapter adapter = listClients.SelectedItem as ClientAdapter;
            if (MessageBox.Show($"Вы уверены, что хотите перезагрузить {adapter.HostName}?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                ServerSendCommand.Send(adapter.HostName, "Restart");
            }
        }
        private void MenuItem_Lock(object sender, RoutedEventArgs e)
        {
            ClientAdapter adapter = listClients.SelectedItem as ClientAdapter;
            if (MessageBox.Show($"Вы уверены, что хотите заблокировать {adapter.HostName}?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                ServerSendCommand.Send(adapter.HostName, "Lock");
            }
        }

        private void btnDeveloper_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://vk.com/nikitaalecseev");
            Process.Start(sInfo);
        }
    }
}
