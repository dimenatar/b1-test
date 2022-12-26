using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class FileToBDImporter
    {
        private MySqlConnection _connection;

        private string _server;
        private int _port;
        private string _userName;
        private string _password;
        private string _database;
        private string _tableName;

        public FileToBDImporter(string server, int port, string userName, string password, string database, string tableName)
        {
            _server = server;
            _port = port;
            _userName = userName;
            _password = password;
            _database = database;

            _connection = new MySqlConnection($"server={server};port={port};username={userName};password={password};database={database}");
            _tableName = tableName;
        }

        public void Import(string[] files, Action<int> valueUpdated = null, Action errorFired = null)
        {
            var data = FileDataManager.GetDataFromFiles(files);

            _connection.Open();

            try
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = _connection;

                command.Parameters.Add("RandInt", MySqlDbType.Int32).Value = 0;
                command.Parameters.Add("RandSingle", MySqlDbType.Float).Value = 0f;
                for (int i = 0; i < data.Count; i++)
                {
                    command.CommandText = $"INSERT INTO {_tableName} values (default, '{data[i].GetDate()}', '{data[i].EngBundle}', '{data[i].RusBundle}', '@RandInt', @'RandSingle');";
                    command.Parameters[0].Value = data[i].IntValue;
                    command.Parameters[1].Value = data[i].FloatValue;
                    command.ExecuteNonQuery();

                    valueUpdated?.Invoke(i+1);
                }
                
                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                errorFired?.Invoke();
                MessageBox.Show(ex.Message);

            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
