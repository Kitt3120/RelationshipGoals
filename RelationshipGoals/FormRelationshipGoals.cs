using Microsoft.Extensions.DependencyInjection;
using RelationshipGoals.Goal;
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
        }

        private void FormRelationshipGoals_Load(object sender, EventArgs e)
        {
            FadeIn();
            Activate();
            RefreshDataGridView();
        }

        private void FadeIn() => new Task(async () =>
        {
            try
            {
                double opacity = 0.0;
                MethodInvoker setOpacityInvoker = new MethodInvoker(() => Opacity = opacity);
                for (opacity = 0.01; opacity <= 1.0; opacity += 0.01)
                {
                    Invoke(setOpacityInvoker);
                    await Task.Delay(1);
                }

                //Needed cause loop ends with 0,990000000000001 on some machines
                opacity = 1.0;
                Invoke(setOpacityInvoker);
            }
            catch (InvalidOperationException) //Should only happen when closing the program while animation is running
            { }
        }).Start();

        private void RefreshDataGridView() => Program.ServiceProvider.GetService<GoalManager>().FillGrid(dataGridView);
    }
}