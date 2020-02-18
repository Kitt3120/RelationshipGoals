using MySql.Data.MySqlClient;
using RelationshipGoals.Properties;
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
        public static bool Check(string Address, string Schema, string Login, string Password)
        {
            if (
                   string.IsNullOrWhiteSpace(Settings.Default.SQL_Server_Address)
                || string.IsNullOrWhiteSpace(Settings.Default.SQL_Server_Login)
                || string.IsNullOrWhiteSpace(Settings.Default.SQL_Server_Password)
                || string.IsNullOrWhiteSpace(Settings.Default.SQL_Server_Schema)
               )
                return false;

            try
            {
                using (MySqlConnection connection = new MySqlConnection($"SERVER={Address};DATABASE={Schema};USER={Login};PASSWORD={Password}"))
                {
                    connection.Open();
                }

                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        public static async Task<bool> CheckAsync(string Address, string Schema, string Login, string Password)
        {
            if (
                   string.IsNullOrWhiteSpace(Settings.Default.SQL_Server_Address)
                || string.IsNullOrWhiteSpace(Settings.Default.SQL_Server_Login)
                || string.IsNullOrWhiteSpace(Settings.Default.SQL_Server_Password)
                || string.IsNullOrWhiteSpace(Settings.Default.SQL_Server_Schema)
               )
                return false;

            try
            {
                using (MySqlConnection connection = new MySqlConnection($"SERVER={Address};DATABASE={Schema};USER={Login};PASSWORD={Password}"))
                {
                    await connection.OpenAsync();
                }

                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        public string Address { get; }
        public string Schema { get; }
        public string Login { get; }
        public string Password { get; }

        public SQLHandler(string address, string schema, string login, string password)
        {
            Address = address;
            Schema = schema;
            Login = login;
            Password = password;
        }

        public DataTable ReadQuery(string query, List<KeyValuePair<string, string>> values = null)
        {
            using (MySqlConnection connection = new MySqlConnection($"SERVER={Address};DATABASE={Schema};USER={Login};PASSWORD={Password}"))
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
            using (MySqlConnection connection = new MySqlConnection($"SERVER={Address};DATABASE={Schema};USER={Login};PASSWORD={Password}"))
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
            using (MySqlConnection connection = new MySqlConnection($"SERVER={Address};DATABASE={Schema};USER={Login};PASSWORD={Password}"))
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
            using (MySqlConnection connection = new MySqlConnection($"SERVER={Address};DATABASE={Schema};USER={Login};PASSWORD={Password}"))
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