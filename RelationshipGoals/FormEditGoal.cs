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
    public partial class FormEditGoal : Form
    {
        public Goal.Goal Goal { get; private set; }

        /// <summary>
        /// Whether or not the DataGridView has to be refreshed because a value has changed
        /// </summary>
        public bool NeedsRefresh { get; private set; }

        public FormEditGoal(Goal.Goal goal)
        {
            InitializeComponent();
            Goal = goal;
            NeedsRefresh = false;
        }

        private void FormEditGoal_Load(object sender, EventArgs e)
        {
            Text = $"Editing Goal \"{Goal.Title}\"";

            textBoxTitle.Text = Goal.Title;
            textBoxDescription.Text = Goal.Description;
            textBoxPointsToUnlock.Text = Goal.PointsToUnlock.ToString();
            textBoxPoints.Text = Goal.PointsCurrent.ToString();

            trackBarPoints.Minimum = 0;
            trackBarPoints.Maximum = Goal.PointsToUnlock;
            trackBarPoints.Value = Goal.PointsCurrent;
            checkBoxUnlocked.Checked = Goal.Unlocked;
        }

        private void trackBarPoints_Scroll(object sender, EventArgs e)
        {
            textBoxPoints.Text = trackBarPoints.Value.ToString();
            checkBoxUnlocked.Checked = trackBarPoints.Value >= trackBarPoints.Maximum;
        }

        private void textBoxPoints_TextChanged(object sender, EventArgs e)
        {
            int points;
            if (!int.TryParse(textBoxPoints.Text, out points))
                points = 0;

            trackBarPoints.Value = points;
        }

        private void textBoxPointsToUnlock_TextChanged(object sender, EventArgs e)
        {
            int points;
            if (!int.TryParse(textBoxPointsToUnlock.Text, out points))
                points = 0;

            trackBarPoints.Maximum = points;
        }

        private void checkBoxUnlocked_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPoints.Text = (checkBoxUnlocked.Checked ? trackBarPoints.Maximum : 0).ToString();
        }

        private void textBoxTitle_TextChanged(object sender, EventArgs e)
        {
            Text = $"Editing Goal \"{textBoxTitle.Text}\"";
        }

        private void FormEditGoal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!NeedsRefresh)
                if (MessageBox.Show("Close without saving?", "Close Goal editing", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    e.Cancel = true;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            buttonUpdate.Enabled = false;

            try
            {
                Goal.Title = textBoxTitle.Text.Trim();
                NeedsRefresh = true; //As soon as the first query goes through, a UI refresh is needed
                Goal.Description = textBoxDescription.Text.Trim();
                Goal.PointsCurrent = trackBarPoints.Value;
                Goal.PointsToUnlock = trackBarPoints.Maximum;
            }
            catch (MySqlException)
            {
                MessageBox.Show($"Ein unbekannter Fehler ist aufgetreten.{Environment.NewLine}Die Einstellungen konnten nicht mit dem SQL-Server synchronisiert werden!", "SQL-Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonUpdate.Enabled = true;
                return;
            }

            Close();
        }
    }
}