using FerumServerWPF.Pages.PageInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FerumServerWPF.Core
{
    public class PageNavigationController
    {
        private Frame mainPageView;

        public PageNavigationController(Frame _pageView) {
            mainPageView = _pageView;
        }

        public void Navigate(string _name, string _host)
        {
            // Создание объекта Page с передачей имени страницы
            var page = CreatePage(_name,_host);

            // Проверка, что объект Page создан успешно
            if (page != null)
            {
                // Навигация на созданную страницу
                mainPageView.Navigate(page);
            }
        }

        // Метод для создания объекта Page по имени страницы
        private Page CreatePage(string _name, string _host)
        {
            switch (_name)
            {
                case "Основная":
                    return new PageMainInformation(_host);
                case "Мониторы":
                    return new PageMonitor();
                case "Диски":
                    return new PageDisk(_host);
                case "Сеть":
                    return new PageNetwork(_host);
                case "Программы":
                    return new PagePrograms(_host);
                case "Дисп.задач":
                    return new PageTasks();
                case "Сценарии":
                    return new PagePowershell();
                default:
                    return null; // Возвращение null, если страница не найдена
            }
        }
    }
}
