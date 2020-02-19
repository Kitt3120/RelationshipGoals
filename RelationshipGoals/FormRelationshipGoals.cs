using Microsoft.Extensions.DependencyInjection;
using RelationshipGoals.Goals;
using System.Collections.Generic;
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

                foreach (KeyValuePair<int, Goal> pair in goalTree.Ordered())
                {
                    while (dataGridView.Rows.Count <= pair.Key)
                        dataGridView.Rows.Add();

                    DataGridViewRow row = dataGridView.Rows[pair.Key];
                    if (row == null)
                        row = dataGridView.Rows[dataGridView.Rows.Add()];
                    row.Cells[columnId] = new DataGridViewTextBoxCell() { Value = pair.Value.Title };
                }
            }
        }
    }
}