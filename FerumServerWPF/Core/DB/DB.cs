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

        SqlConnection connection = new SqlConnection($"Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\DB\\FerumDatabase.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        public void openConnection()
        {
            try
            {
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
