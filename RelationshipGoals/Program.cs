using Microsoft.Extensions.DependencyInjection;
using RelationshipGoals.Goals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            BuildServiceProvider();

            Application.Run(new FormRelationshipGoals());
        }

        private static void BuildServiceProvider()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton(new GoalManager());

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}