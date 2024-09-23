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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FerumServerWPF.Pages.PageInformation
{
    /// <summary>
    /// Логика взаимодействия для PageNetwork.xaml
    /// </summary>
    public partial class PageNetwork : Page
    {
        private MainInformationVM viewModel = new MainInformationVM();

        public PageNetwork()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            for(int i = 0;i<viewModel.InfoEntity.Networks.Count;i++)
            {
                // Создаем корневой узел
                TreeViewItem rootNode = CreateNode($"{viewModel.InfoEntity.Networks[i].AdapterName} ({viewModel.InfoEntity.Networks[i].AdapterDescription})", "Assets/Icons/Information/Network/ic_networkAdapter.png");
                treeView1.Items.Add(rootNode);

                // добавляем МАК адрес
                string networkAdapterModel = viewModel.InfoEntity.Networks[i].AdapterModel;
                TreeViewItem adapterModelNode = CreateNode($"Тип: {networkAdapterModel}", "Assets/Icons/Information/Network/ic_networkAdapter2.png");
                rootNode.Items.Add(adapterModelNode);

                // добавляем МАК адрес
                string macAddress = viewModel.InfoEntity.Networks[i].MACAddress;
                TreeViewItem macNode = CreateNode($"MAC-адрес: {macAddress}", "Assets/Icons/Information/Network/ic_ip.png");
                rootNode.Items.Add(macNode);

                // добавляем IP адреса
                for (int nIp = 0;nIp < viewModel.InfoEntity.Networks[i].IPAddress.Count;nIp++)
                {
                    string IP = viewModel.InfoEntity.Networks[i].IPAddress[nIp];
                    TreeViewItem childNode = CreateNode($"IP: {IP}", "Assets/Icons/Information/Network/ic_ip.png");
                    rootNode.Items.Add(childNode);
                }

                // добавляем маску
                for (int nMask = 0; nMask < viewModel.InfoEntity.Networks[i].IPv4Mask.Count; nMask++)
                {
                    string IPMask = viewModel.InfoEntity.Networks[i].IPv4Mask[nMask];
                    TreeViewItem childNode = CreateNode($"Маска: {IPMask}", "Assets/Icons/Information/Network/ic_mask.png");
                    rootNode.Items.Add(childNode);
                }

                // добавляем шлюз
                for (int nGat = 0; nGat < viewModel.InfoEntity.Networks[i].GatewayAddressInfo.Count; nGat++)
                {
                    string Gateway = viewModel.InfoEntity.Networks[i].GatewayAddressInfo[nGat];
                    TreeViewItem childNode = CreateNode($"Шлюз: {Gateway}", "Assets/Icons/Information/Network/ic_gateway.png");
                    rootNode.Items.Add(childNode);
                }
            }

            // Создаем корневой узел
            //TreeViewItem rootNode = CreateNode("Адаптер 1", "Assets/Icons/Information/Network/ic_networkAdapter.png");
            //treeView1.Items.Add(rootNode);

                // Создаем дочерний узел
                //TreeViewItem childNode = CreateNode("IP: 192.168.0.10", "Assets/Icons/Information/Network/ic_ip.png");
                //TreeViewItem childNode2 = CreateNode("Mask: 255.255.255.0", "Assets/Icons/Information/Network/ic_mask.png");
                //rootNode.Items.Add(childNode);
                //rootNode.Items.Add(childNode2);
        }

        // Метод для создания узла с изображением и текстом
        private TreeViewItem CreateNode(string _text, string _image)
        {
            TreeViewItem node = new TreeViewItem();
            node.Header = _text;

            // Создаем изображение
            Image image = new Image();
            image.Source = new BitmapImage(new Uri($"pack://application:,,,/{_image}"));
            image.Width = 30;
            image.Height = 30;

            // Создаем StackPanel для размещения изображения и текста
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.Margin = new Thickness(0, 10, 0, 0);
            stackPanel.Children.Add(image);

            // Создаем текст и добавляем его в StackPanel
            TextBlock textBlock = new TextBlock();
            textBlock.Text = _text;
            textBlock.Foreground = new SolidColorBrush(Colors.White);
            textBlock.FontSize = 18;
            textBlock.Margin = new Thickness(10, 0, 0, 0);
            stackPanel.Children.Add(textBlock);

            // Устанавливаем StackPanel как заголовок узла
            node.Header = stackPanel;

            return node;
        }
    }
}
