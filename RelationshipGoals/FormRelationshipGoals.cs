using Microsoft.Extensions.DependencyInjection;
using RelationshipGoals.Goals;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RelationshipGoals
{
    public partial class FormRelationshipGoals : Form
    {
        public FormRelationshipGoals()
        {
            InitializeComponent();

            Program.Ready += RefreshDataGridView;
        }

        private void RefreshDataGridView()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            GoalManager goalManager = Program.ServiceProvider.GetService<GoalManager>();

            //Max amount of rows that need to be generated. X amount does not have to be calculated before creating the table.
            int y = goalManager.GoalTrees.Max(goalTree => goalTree.Keys.Max());

            //We can't create the rows before at least 1 column has been added, so we have to add on the first loop iteration after adding the first column.
            bool first = true;

            foreach (GoalTree goalTree in goalManager.GoalTrees)
            {
                int columnId = dataGridView.Columns.Add(goalTree.ID.ToString(), $"{goalTree.Title} ({goalTree.Values.Where(value => value.Unlocked).Count()}/{goalTree.Count})");

                if (first)
                {
                    for (int i = 0; i <= y; i++)
                        dataGridView.Rows.Add();

                    first = false;
                }

                foreach (KeyValuePair<int, Goal> pair in goalTree.Ordered().Where(pair => pair.Key <= goalTree.NextToUnlockPosition()))
                {
                    Color cellBackground = Color.Green;
                    if (pair.Key == goalTree.NextToUnlockPosition())
                        cellBackground = Color.Orange;
                    dataGridView.Rows[pair.Key].Cells[columnId] = new DataGridViewTextBoxCell() { Value = $"{pair.Value.Title} ({pair.Value.PointsCurrent}/{pair.Value.PointsToUnlock})" };
                    dataGridView.Rows[pair.Key].Cells[columnId].Style.BackColor = cellBackground;
                }
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewTextBoxCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.SelectionBackColor = Color.LightGray;
                    }
                }
            }
        }
    }
}