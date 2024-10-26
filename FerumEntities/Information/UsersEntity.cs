using System.Windows;

namespace FerumEntities.Information
{
    public class UsersEntity
    {
        public string Login { get; set; }
        public bool IsActive { get; set; }
        public Visibility VisibleActiveUserText
        {
            get
            {
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
