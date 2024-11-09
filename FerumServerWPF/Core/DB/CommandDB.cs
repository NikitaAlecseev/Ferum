using FerumEntities.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FerumServerWPF.Core.DB
{
    public class CommandDB : DB
    {
        private SqlDataAdapter sqlDataAdapter = null;
        public DataTable MainTable = new DataTable();
        private DataSet dataSet = null;

        /// <summary>
        /// Метод для загрузки данных из БД в DataTable (MainTable)
        /// </summary>
        /// <param name="_command">Команда SQL</param>
        public void LoadData(string _command)
        {
            openConnection(); // открываем подключение

            try
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(_command, getConnection());
                adapter.Fill(MainTable);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод ошибки
            }
            closeConnection(); // закрываем подключение
        }

        public void SendCommand(string _command)
        {
            openConnection(); // открываем подключение
            try
            {
                SQLiteCommand Scommand = new SQLiteCommand(_command, getConnection()); // объявляем команду
                Scommand.CommandType = CommandType.Text;
                Scommand.ExecuteNonQuery(); // отправляем команду в БД
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод ошибки
            }

            closeConnection(); // закрываем подключение
        }
    }
}
