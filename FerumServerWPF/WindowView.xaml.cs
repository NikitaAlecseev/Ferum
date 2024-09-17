using FerumServerWPF.Core;
using FerumServerWPF.Entity;
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
    /// Логика взаимодействия для WindowView.xaml
    /// </summary>
    public partial class WindowView : Window
    {
        private bool IsMaximized = false;
        private string hostName;
        public WindowView(string _hostName)
        {
            InitializeComponent();
            hostName = _hostName;
        }
        private void WindowView_Loaded(object sender, RoutedEventArgs e)
        {
            loadMenu();
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

        private void loadMenu()
        {
            List<MenuItemInfo> menuItems = new List<MenuItemInfo>();
            menuItems.Add(new MenuItemInfo("Основная", "pack://application:,,,/Assets/Icons/InfoMenu/icon_pc.png"));
            menuItems.Add(new MenuItemInfo("Мониторы", "pack://application:,,,/Assets/Icons/InfoMenu/icon_monitor.png"));
            menuItems.Add(new MenuItemInfo("Диски", "pack://application:,,,/Assets/Icons/InfoMenu/icon_disk.png"));
            menuItems.Add(new MenuItemInfo("Сеть", "pack://application:,,,/Assets/Icons/InfoMenu/icon_wifi.png"));
            menuItems.Add(new MenuItemInfo("Программы", "pack://application:,,,/Assets/Icons/InfoMenu/icon_programm_folder.png"));
            menuItems.Add(new MenuItemInfo("Дисп.задач", "pack://application:,,,/Assets/Icons/InfoMenu/icon_task.png"));
            menuItems.Add(new MenuItemInfo("Power shell", "pack://application:,,,/Assets/Icons/InfoMenu/icon_powershell.png"));

            listMenu.ItemsSource = menuItems;
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
            this.Close();
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


        private void listMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MenuItemInfo itemMenu = listMenu.SelectedItem as MenuItemInfo;
            loadPage(itemMenu.Name);
        }

        private void loadPage(string _name)
        {
            switch (_name)
            {
                case "Основная":
                    fContainer.Navigate(new System.Uri("Pages/PageInformation/PageMainInformation.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case "Мониторы":
                    fContainer.Navigate(new System.Uri("Pages/PageInformation/PageMonitor.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case "Диски":
                    fContainer.Navigate(new System.Uri("Pages/PageInformation/PageDisk.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case "Сеть":
                    fContainer.Navigate(new System.Uri("Pages/PageInformation/PageNetwork.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case "Программы":
                    fContainer.Navigate(new System.Uri("Pages/PageInformation/PagePrograms.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case "Дисп.задач":
                    fContainer.Navigate(new System.Uri("Pages/PageInformation/PageTasks.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case "Power shell":
                    fContainer.Navigate(new System.Uri("Pages/PageInformation/PagePowershell.xaml", UriKind.RelativeOrAbsolute));
                    break;
            }
        }
    }
}
