using FerumServerWPF.Core.ViewModels;
using FerumServerWPF.Entity;
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
    /// Логика взаимодействия для PageMainInformation.xaml
    /// </summary>
    public partial class PageMainInformation : Page
    {
        private MainVM viewModel;
        public PageMainInformation(string _host)
        {
            InitializeComponent();
            viewModel = new MainVM(_host);
            DataContext = viewModel;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
