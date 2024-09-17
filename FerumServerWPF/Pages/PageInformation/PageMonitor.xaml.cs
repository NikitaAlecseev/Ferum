using System;
using System.Collections.Generic;
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

namespace FerumServerWPF.Pages.PageInformation
{
    /// <summary>
    /// Логика взаимодействия для PageMonitor.xaml
    /// </summary>
    public partial class PageMonitor : Page
    {
        public PageMonitor()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Thread loadThread = new Thread(loadData);
            loadThread.Start();
        }

        private void loadData()
        {
            Thread.Sleep(3500);

            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                loaderAnimUI.Visibility = Visibility.Collapsed;
                scrollViewerUI.Visibility = Visibility.Visible;
            }));
        }
    }
}
