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

        private void RefreshDataGridView()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            GoalManager goalManager = Program.ServiceProvider.GetService<GoalManager>();

            //Max amount of rows that need to be generated. X amount does not have to be calculated before creating the table.
            int y = goalManager.GoalTrees.Max(goalTree => goalTree.MaxPosition());

            //We can't create the rows before at least 1 column has been added, so we have to add on the first loop iteration after adding the first column.
            bool first = true;

            foreach (GoalTree goalTree in goalManager.GoalTrees)
            {
                //int columnId = dataGridView.Columns.Add(goalTree.ID.ToString(), $"{goalTree.Title} ({goalTree.Values.Where(value => value.Unlocked).Count()}/{goalTree.Count})");
                int columnId = dataGridView.Columns.Add(new GoalTreeColumn(goalTree));

                if (first)
                {
                    for (int i = 0; i <= y; i++)
                        dataGridView.Rows.Add();

                    first = false;
                }

                IEnumerable<KeyValuePair<int, Goal>> filtered = (goalTree.FullyUnlocked ? goalTree.Ordered() : goalTree.Ordered().Where(pair => pair.Key <= goalTree.NextToUnlockPosition()));

                foreach (KeyValuePair<int, Goal> pair in filtered)
                {
                    Color cellBackground = Color.Green;
                    if (pair.Key == goalTree.NextToUnlockPosition())
                        cellBackground = Color.Orange;

                    GoalCell cell = new GoalCell(pair.Value);
                    cell.Style.BackColor = cellBackground;
                    dataGridView.Rows[pair.Key].Cells[columnId] = cell;
                }
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (typeof(DataGridViewTextBoxCell).IsAssignableFrom(row.Cells[i].GetType()))
                    {
                        DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)row.Cells[i];
                        cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        if (row.Cells[i].Value == null)
                        {
                            cell.Style.BackColor = Color.LightGray;
                            cell.Style.SelectionBackColor = Color.LightGray;
                            cell.Style.ForeColor = Color.Black;
                            cell.Style.SelectionForeColor = Color.Black;
                            cell.Value = "-";
                            cell.ToolTipText = $"This is an empty slot, a goal is missing here.{Environment.NewLine}Relationship Goals will skip this cell.";
                        }
                    }
                }
            }
        }
    }
}