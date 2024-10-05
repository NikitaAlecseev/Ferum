using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FerumServerWPF.Core.DB
{
    public class DB
    {
        string host = "localhost"; // Имя хоста
        string database = "tasker"; // Имя базы данных
        string user = "admin"; // Имя пользователя
        string password = "Qwerty12$"; // Пароль пользователя

        SqlConnection connection; // Data Source=PK-NIKITA\\SQLEXPRESS; Initial Catalog = Ferum;Integrated Security=True;

        public void openConnection()
        {
            try
            {
                connection = new SqlConnection($"Data Source={GlobalVar.SQLServer};Initial Catalog = Ferum;User ID = {GlobalVar.LoginSQL};Password = {GlobalVar.PasswordSQL}");
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void closeConnection()
        {
            connection.Close();
        }
        public SqlConnection getConnection()
        {
            return connection;
        }

    }
}
