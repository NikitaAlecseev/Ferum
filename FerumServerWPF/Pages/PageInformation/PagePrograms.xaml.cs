using FerumServerWPF.Core;
using FerumServerWPF.Core.Entity.RequestInformation;
using FerumServerWPF.Core.Server;
using Newtonsoft.Json;
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
    /// Логика взаимодействия для PagePrograms.xaml
    /// </summary>
    public partial class PagePrograms : Page
    {
        private string hostName;
        public PagePrograms(string _hostName)
        {
            InitializeComponent();
            hostName = _hostName;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            var thread = new Thread(()=> ServerSendCommand.Send(hostName, "Get Programs", ""));
            thread.Start();
            
            EventSystem.EventGetAnswerClient += getAnswerClient; // TODO: сделать асинхронный метод с ожиданием ответа от клиента
        }



        private void getAnswerClient(string json)
        {
            try
            {
                List<InstalledProgram> programs = JsonConvert.DeserializeObject<List<InstalledProgram>>(json);
                List<string> result = new List<string>();
                for (int i = 0; i < programs.Count; i++)
                {
                    result.Add(programs[i].Name);
                }


                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    listViewPrograms.ItemsSource = result;

                    loaderAnimUI.Visibility = Visibility.Collapsed;
                    listViewPrograms.Visibility = Visibility.Visible;
                }));

            }
            catch (Exception ex)
            {

            }
           
        }
    }
}
