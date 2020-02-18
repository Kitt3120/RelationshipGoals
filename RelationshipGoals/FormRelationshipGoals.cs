using Microsoft.Extensions.DependencyInjection;
using RelationshipGoals.Goals;
using System.Windows.Forms;

namespace RelationshipGoals
{
    public partial class FormRelationshipGoals : Form
    {
        public FormRelationshipGoals()
        {
            InitializeComponent();

            Program.Ready += Program_Ready;
        }

        private void Program_Ready()
        {
            GoalManager goalManager = Program.ServiceProvider.GetService<GoalManager>();

            foreach (GoalTree goalTree in goalManager.GoalTrees)
            {
                int columnId = dataGridView.Columns.Add(goalTree.ID.ToString(), goalTree.Title);

                foreach (Goal goal in goalTree.Goals.orde)
                {
                }
            }
        }
    }
}