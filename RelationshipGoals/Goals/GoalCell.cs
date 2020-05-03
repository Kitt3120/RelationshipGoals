using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelationshipGoals.Goals
{
    internal class GoalCell : DataGridViewTextBoxCell
    {
        public Goal Goal { get; private set; }

        public GoalCell(Goal goal) : base()
        {
            Goal = goal;
            Value = $"{goal.Title} ({goal.PointsCurrent}/{goal.PointsToUnlock})";
            ToolTipText = goal.Description;
        }

        protected override void OnDoubleClick(DataGridViewCellEventArgs e)
        {
            base.OnDoubleClick(e);
            MessageBox.Show("Clicked Goal \"" + Goal.Title + "\"");
        }
    }
}