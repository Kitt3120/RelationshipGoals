using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipGoals.SQL
{
    public class SQLHandler
    {
        public string Address { get; }
        public string Schema { get; }
        public string User { get; }
        public string Password { get; }

        public SQLHandler(string address, string schema, string user, string password)
        {
            Address = address;
            Schema = schema;
            User = user;
            Password = password;
        }

        public DataTable ReadQuery(string query, List<KeyValuePair<string, string>> values = null)
        {
            using (MySqlConnection connection = new MySqlConnection($"SERVER={Address};DATABASE={Schema};USER={User};PASSWORD={Password}"))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand($"{query}", connection);

                if (values != null)
                    foreach (var keyValuePair in values)
                        command.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = command;
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public async Task<DataTable> ReadQueryAsync(string query, List<KeyValuePair<string, string>> values = null)
        {
            using (MySqlConnection connection = new MySqlConnection($"SERVER={Address};DATABASE={Schema};USER={User};PASSWORD={Password}"))
            {
                await connection.OpenAsync();

                MySqlCommand command = new MySqlCommand($"{query}", connection);

                if (values != null)
                    foreach (var keyValuePair in values)
                        command.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = command;
                DataTable dataTable = new DataTable();
                await dataAdapter.FillAsync(dataTable);
                return dataTable;
            }
        }

        public int SendQuery(string query, Dictionary<string, string> values = null)
        {
            using (MySqlConnection connection = new MySqlConnection($"SERVER={Address};DATABASE={Schema};USER={User};PASSWORD={Password}"))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand($"{query}", connection);
                command.Prepare();

                if (values != null)
                    foreach (var keyValuePair in values)
                        command.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);

                return command.ExecuteNonQuery();
            }
        }

        public async Task<int> SendQueryAsync(string query, Dictionary<string, string> values = null)
        {
            using (MySqlConnection connection = new MySqlConnection($"SERVER={Address};DATABASE={Schema};USER={User};PASSWORD={Password}"))
            {
                await connection.OpenAsync();

                MySqlCommand command = new MySqlCommand($"{query}", connection);
                command.Prepare();

                if (values != null)
                    foreach (var keyValuePair in values)
                        command.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);

                return await command.ExecuteNonQueryAsync();
            }
        }
    }
}