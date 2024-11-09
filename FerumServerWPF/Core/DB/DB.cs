using System;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Shapes;

namespace FerumServerWPF.Core.DB
{
    public class DB
    {
        string host = "localhost"; // Имя хоста
        string database = "tasker"; // Имя базы данных
        string user = "admin"; // Имя пользователя
        string password = "Qwerty12$"; // Пароль пользователя

        SQLiteConnection connection; // Data Source=PK-NIKITA\\SQLEXPRESS; Initial Catalog = Ferum;Integrated Security=True;

        public void openConnection()
        {
            try
            {
                string pathDB = $"{Environment.CurrentDirectory}" + "\\" + "FerumDB.db";
                if (File.Exists(pathDB))
                {
                    connection = new SQLiteConnection($"Data Source={pathDB}");
                    connection.Open();
                }
                else
                {
                    createDB();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void createDB()
        {
            string baseName = "FerumDB.db";
            SQLiteConnection.CreateFile(baseName);
            SQLiteFactory factory = (SQLiteFactory)DbProviderFactories.GetFactory("System.Data.SQLite");

            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {

                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))

                {

                    command.CommandText = @"CREATE TABLE [Clients] (

                    [ID_Client] integer PRIMARY KEY AUTOINCREMENT NOT NULL,

                    [Hostname] char(100) NOT NULL,

                    [Information] TEXT NOT NULL,

                    [DateUpdate] DATETIME NOT NULL,

                    [CurrentProcess] TEXT NOT NULL,

                    [Version] char(10) NOT NULL

                    );


                    CREATE TABLE [ListGames] (

                    [ID_ListGame] integer PRIMARY KEY AUTOINCREMENT NOT NULL,

                    [NameGame] TEXT NOT NULL

                    );";

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
            openConnection();
        }

        public void closeConnection()
        {
            connection.Close();
        }
        public SQLiteConnection getConnection()
        {
            return connection;
        }

    }
}
