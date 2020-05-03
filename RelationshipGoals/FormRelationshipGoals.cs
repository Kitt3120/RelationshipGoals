using Microsoft.Extensions.DependencyInjection;
using RelationshipGoals.Goals;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelationshipGoals
{
    public partial class FormRelationshipGoals : Form
    {
        public FormRelationshipGoals()
        {
            InitializeComponent();

            Program.Ready += OnReady;
        }

        private void OnReady()
        {
            new Task(async () =>
            {
                try
                {
                    double opacity;
                    for (opacity = 0.01; opacity <= 1.0; opacity += 0.01)
                    {
                        Invoke(new MethodInvoker(() => Opacity = opacity));
                        await Task.Delay(1);
                    }

                    //Needed cause loop ends with 0,990000000000001 on some machines
                    opacity = 1.0;
                    Invoke(new MethodInvoker(() => Opacity = opacity));
                }
                catch (InvalidOperationException)
                { }
            }).Start();

            Activate();
            RefreshDataGridView();
        }

        private void RefreshDataGridView() => Program.ServiceProvider.GetService<GoalManager>().FillGrid(dataGridView);
    }
}