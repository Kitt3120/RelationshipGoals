using Microsoft.Extensions.DependencyInjection;
using RelationshipGoals.Boot;
using RelationshipGoals.Goal;
using RelationshipGoals.Properties;
using RelationshipGoals.Services.AssetService;
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

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!SQLHandler.Check(Settings.Default.SQL_Server_Address, Settings.Default.SQL_Server_Schema, Settings.Default.SQL_Server_Login, Settings.Default.SQL_Server_Password))
            {
                MessageBox.Show("Your SQL settings are invalid! Please provide valid SQL settings in the following window.", "Invalid SQL settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                new FormSettings().ShowDialog(); //Blocks thread until finished
            }
            SQLHandler.Use(new SQLHandler(Settings.Default.SQL_Server_Address, Settings.Default.SQL_Server_Schema, Settings.Default.SQL_Server_Login, Settings.Default.SQL_Server_Password));

            BuildServiceProvider();

            BootAnimation.Play();
            Application.Run(new FormRelationshipGoals());
        }

        private static void BuildServiceProvider()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton(new AssetService());
            serviceCollection.AddSingleton(new GoalManager());

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}