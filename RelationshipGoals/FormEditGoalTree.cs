using MySql.Data.MySqlClient;
using RelationshipGoals.Goal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelationshipGoals
{
    public partial class FormEditGoalTree : Form
    {
        public GoalTree GoalTree { get; private set; }

        public FormEditGoalTree(GoalTree goalTree)
        {
            InitializeComponent();
            GoalTree = goalTree;
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
            dataGridView.Controls.Clear();

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

                Button upButton;
                Button downButton;

                upButton = new Button()
                {
                    Text = "Up",
                    AutoSize = true,
                    Anchor = AnchorStyles.Left,
                    Dock = DockStyle.Left,
                    FlatStyle = FlatStyle.Flat
                };

                downButton = new Button()
                {
                    Text = "Down",
                    AutoSize = true,
                    Anchor = AnchorStyles.Right,
                    Dock = DockStyle.Right,
                    FlatStyle = FlatStyle.Flat
                };

                upButton.Click += (sender, eventArgs) =>
                {
                    GoalTree.Swap(pair.Key, pair.Key - 1);
                    controlPanel.Controls.Remove(upButton);
                    controlPanel.Controls.Remove(downButton);
                    dataGridView.Controls.Remove(controlPanel);
                    dataGridView.Controls.Remove(controlPanel);
                    upButton.Dispose();
                    downButton.Dispose();
                    controlPanel.Dispose();
                    controlPanel = null; //For event
                    LoadGoals();
                };

                downButton.Click += (sender, eventArgs) =>
                {
                    GoalTree.Swap(pair.Key, pair.Key + 1);
                    controlPanel.Controls.Remove(upButton);
                    controlPanel.Controls.Remove(downButton);
                    dataGridView.Controls.Remove(controlPanel);
                    upButton.Dispose();
                    downButton.Dispose();
                    controlPanel.Dispose();
                    controlPanel = null; //So SizeChanged Event does get handled below
                    LoadGoals();
                };

                controlPanel.Controls.Add(upButton);
                controlPanel.Controls.Add(downButton);
                dataGridView.Controls.Add(controlPanel);

                Rectangle displayRectangle = dataGridView.GetCellDisplayRectangle(2, pair.Key, true);
                controlPanel.Location = displayRectangle.Location;
                controlPanel.Size = displayRectangle.Size;

                dataGridView.SizeChanged += (sender, eventArgs) =>
                {
                    if (controlPanel != null)
                    {
                        displayRectangle = dataGridView.GetCellDisplayRectangle(2, pair.Key, true);
                        controlPanel.Location = displayRectangle.Location;
                        controlPanel.Size = displayRectangle.Size;
                    }
                };
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            buttonUpdate.Enabled = false;

            try
            {
                GoalTree.Title = textBoxTitle.Text.Trim();
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