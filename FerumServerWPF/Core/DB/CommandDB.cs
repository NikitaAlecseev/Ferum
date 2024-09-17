using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                SqlCommand newCommand = new SqlCommand(_command, getConnection()); // объявляем команду

                dataSet = new DataSet();

                sqlDataAdapter = new SqlDataAdapter();

                sqlDataAdapter.SelectCommand = newCommand; // присваиваем адаптеру команду
                sqlDataAdapter.Fill(dataSet, "Load"); // заполняем dataSet данными из БД

                MainTable = dataSet.Tables["Load"]; // присваиваем таблице данные из dataSet

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
                SqlCommand Scommand = new SqlCommand(_command, getConnection()); // объявляем команду
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
