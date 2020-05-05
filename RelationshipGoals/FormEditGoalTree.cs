using MySql.Data.MySqlClient;
using RelationshipGoals.Goal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelationshipGoals
{
    public partial class FormEditGoalTree : Form
    {
        public GoalTree GoalTree { get; private set; }

        /// <summary>
        /// Whether or not the DataGridView has to be refreshed because a value has changed
        /// </summary>
        public bool NeedsRefresh { get; private set; }

        public FormEditGoalTree(GoalTree goalTree)
        {
            InitializeComponent();
            GoalTree = goalTree;
            NeedsRefresh = false;
        }

        private void FormEditGoalTree_Load(object sender, EventArgs e)
        {
            textBoxTitle.Text = GoalTree.Title;
            textBoxDescription.Text = GoalTree.Description;

            LoadGoals();
        }

        private void LoadGoals()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            dataGridView.Columns.Add("position", "Position");
            dataGridView.Columns.Add("goal", "Goal");
            dataGridView.Columns.Add("options", "Options");

            for (int i = 0; i <= GoalTree.MaxPosition(); i++)
                dataGridView.Rows.Add();

            foreach (KeyValuePair<int, Goal.Goal> pair in GoalTree.GetPairs())
            {
                dataGridView[0, pair.Key] = new DataGridViewTextBoxCell() { Value = pair.Key };
                dataGridView[1, pair.Key] = new DataGridViewTextBoxCell() { Value = pair.Value.Title };

                Panel controlPanel = new Panel();
                controlPanel.Controls.Add(new Button() { Text = "up", AutoSize = true, Anchor = AnchorStyles.Left, Dock = DockStyle.Left, FlatStyle = FlatStyle.Flat });
                controlPanel.Controls.Add(new Button() { Text = "down", AutoSize = true, Anchor = AnchorStyles.Right, Dock = DockStyle.Right, FlatStyle = FlatStyle.Flat });
                dataGridView.Controls.Add(controlPanel);

                Rectangle displayRectangle = dataGridView.GetCellDisplayRectangle(2, pair.Key, true);
                controlPanel.Location = displayRectangle.Location;
                controlPanel.Size = displayRectangle.Size;

                dataGridView.SizeChanged += (sender, eventArgs) =>
                {
                    displayRectangle = dataGridView.GetCellDisplayRectangle(2, pair.Key, true);
                    controlPanel.Location = displayRectangle.Location;
                    controlPanel.Size = displayRectangle.Size;
                };
            }
        }

        private void FormEditGoalTree_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!NeedsRefresh)
                if (MessageBox.Show("Close without saving?", "Close GoalTree editing", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    e.Cancel = true;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            buttonUpdate.Enabled = false;

            try
            {
                GoalTree.Title = textBoxTitle.Text.Trim();
                NeedsRefresh = true; //As soon as the first query goes through, a UI refresh is needed
                GoalTree.Description = textBoxDescription.Text.Trim();
            }
            catch (MySqlException)
            {
                MessageBox.Show($"Ein unbekannter Fehler ist aufgetreten.{Environment.NewLine}Die Einstellungen konnten nicht mit dem SQL-Server synchronisiert werden!", "SQL-Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            buttonUpdate.Enabled = true;
        }
    }
}