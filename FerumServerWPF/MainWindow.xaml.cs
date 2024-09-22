using FerumServerWPF.Core;
using FerumServerWPF.Core.Adapter;
using FerumServerWPF.Core.DB;
using FerumServerWPF.Core.Server;
using FerumServerWPF.Core.ViewModels;
using FerumServerWPF.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = true;
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
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuItem_Open(object sender, RoutedEventArgs e)
        {
            ClientAdapter adapter = listClients.SelectedItem as ClientAdapter;
            GlobalVar.SelectHostName = adapter.HostName;

            WindowView windView = new WindowView("k1-333-10"); // TODO: сделать по нормальному
            windView.Show();
        }

        private void MenuItem_GetCurrentProcess(object sender, RoutedEventArgs e)
        {
            ClientAdapter adapter = listClients.SelectedItem as ClientAdapter;
            MessageBox.Show(adapter.CurrentProcess, "Текущий процесс", MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void MenuItem_Disconect(object sender, RoutedEventArgs e)
        {
            ClientAdapter adapter = listClients.SelectedItem as ClientAdapter;
            ServerSendCommand.Send(adapter.HostName, "Disconect");
        }
    }
}
