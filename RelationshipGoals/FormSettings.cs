using MySql.Data.MySqlClient;
using RelationshipGoals.Properties;
using RelationshipGoals.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RelationshipGoals
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();

            LoadSettings();
        }

        private void LoadSettings()
        {
            textBoxSqlAddress.Text = Settings.Default.SQL_Server_Address;
            textBoxSqlPort.Text = Settings.Default.SQL_Server_Port.ToString();
            textBoxSqlLogin.Text = Settings.Default.SQL_Server_Login;
            textBoxSqlPassword.Text = Settings.Default.SQL_Server_Password;
            comboBoxSqlSchema.Items.Add(Settings.Default.SQL_Server_Schema);
        }

        private void buttonSqlCheck_Click(object sender, EventArgs e)
        {
            buttonSqlCheck.Enabled = false;
            bool wasValid = false;

            string address = textBoxSqlAddress.Text;
            int port;
            string portS = textBoxSqlPort.Text;
            string login = textBoxSqlLogin.Text;
            string password = textBoxSqlPassword.Text;

            if (string.IsNullOrWhiteSpace(address) || Uri.CheckHostName(address) == UriHostNameType.Unknown)
                MessageBox.Show("The given address is not valid!", "Invalid Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(portS) || !int.TryParse(portS, out port) || port < 0 || port > 65535)
                MessageBox.Show("The given port is not valid!", "Invalid Port", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(login))
                MessageBox.Show("You must provide a login!", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(password))
                MessageBox.Show("You must provide a password!", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    comboBoxSqlSchema.Items.Clear();

                    SQLHandler sqlHandler = new SQLHandler(address, "", login, password);
                    foreach (DataRow row in sqlHandler.ReadQuery("show databases;").Rows)
                    {
                        string database = row.ItemArray[0].ToString();
                        if (database != "information_schema")
                            comboBoxSqlSchema.Items.Add(database);
                    }

                    if (comboBoxSqlSchema.Items.Count > 0)
                    {
                        comboBoxSqlSchema.SelectedIndex = 0;
                        wasValid = true;
                    }
                    else
                        MessageBox.Show("The connection was successful, however there were no databases available to work with for this user!", "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (MySqlException)
                {
                    MessageBox.Show("An error occured while connecting to the SQL Server!\nMake sure your credentials are correct!", "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (wasValid)
            {
                labelSqlAddress.Enabled = false;
                textBoxSqlAddress.Enabled = false;
                labelSqlPort.Enabled = false;
                textBoxSqlPort.Enabled = false;
                labelSqlLogin.Enabled = false;
                textBoxSqlLogin.Enabled = false;
                labelSqlPassword.Enabled = false;
                textBoxSqlPassword.Enabled = false;

                labelSqlSchema.Enabled = true;
                comboBoxSqlSchema.Enabled = true;

                buttonSave.Enabled = true;
            }
            else
            {
                labelSqlAddress.Enabled = true;
                textBoxSqlAddress.Enabled = true;
                labelSqlPort.Enabled = true;
                textBoxSqlPort.Enabled = true;
                labelSqlLogin.Enabled = true;
                textBoxSqlLogin.Enabled = true;
                labelSqlPassword.Enabled = true;
                textBoxSqlPassword.Enabled = true;

                labelSqlSchema.Enabled = false;
                comboBoxSqlSchema.Enabled = false;

                buttonSqlCheck.Enabled = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Settings.Default.SQL_Server_Address = textBoxSqlAddress.Text;
            Settings.Default.SQL_Server_Port = int.Parse(textBoxSqlPort.Text);
            Settings.Default.SQL_Server_Login = textBoxSqlLogin.Text;
            Settings.Default.SQL_Server_Password = textBoxSqlPassword.Text;
            Settings.Default.SQL_Server_Schema = comboBoxSqlSchema.SelectedItem as string;
            Settings.Default.Save();
            Close();
        }
    }
}