using Microsoft.Extensions.DependencyInjection;
using RelationshipGoals.Goals;
using RelationshipGoals.Properties;
using RelationshipGoals.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace RelationshipGoals
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public delegate void StartedHandler();

        public static event StartedHandler Ready;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        private static void Main()

        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormRelationshipGoals formRelationshipGoals = new FormRelationshipGoals();
            formRelationshipGoals.Show();
            if (!SQLHandler.Check(Settings.Default.SQL_Server_Address, Settings.Default.SQL_Server_Schema, Settings.Default.SQL_Server_Login, Settings.Default.SQL_Server_Password))
            {
                MessageBox.Show(formRelationshipGoals, "Your SQL settings are not valid! Please provide valid SQL settings in the following window.");
                FormSettings formSettings = new FormSettings();
                formSettings.ShowDialog(formRelationshipGoals);
                while (formSettings.Visible) //Wait until valid settings have been provided before building ServiceProvider
                    Thread.Sleep(1000);
            }
            SQLHandler.Use(new SQLHandler(Settings.Default.SQL_Server_Address, Settings.Default.SQL_Server_Schema, Settings.Default.SQL_Server_Login, Settings.Default.SQL_Server_Password));

            BuildServiceProvider();

            Ready.Invoke();
            Application.Run(formRelationshipGoals);
        }

        private static void BuildServiceProvider()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton(new GoalManager());

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}