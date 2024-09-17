using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FerumServerWPF.Entity
{
    public class UsersEntity
    {
        public string Login { get; set; }
        public bool IsActive { get; set; }
        public Visibility VisibleActiveUserText {
            get {
                if (IsActive)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }


        public UsersEntity(string login, bool isActive)
        {
            Login = login;
            IsActive = isActive;
        }
    }
}
