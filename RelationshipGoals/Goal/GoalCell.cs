using RelationshipGoals.Services.AssetService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace RelationshipGoals.Goal
{
    internal class GoalCell : DataGridViewTextBoxCell
    {
        public Goal Goal { get; private set; }

        public GoalCell(Goal goal) : base()
        {
            Goal = goal;
            Value = $"{goal.Title} ({goal.PointsCurrent}/{goal.PointsToUnlock})";
            Style.BackColor = (goal.Unlocked ? Color.Violet : Color.Plum);
            ToolTipText = goal.Description;
        }

        protected override void OnDoubleClick(DataGridViewCellEventArgs e)
        {
            base.OnDoubleClick(e);
            FormEditGoal formEditGoal = new FormEditGoal(Goal);
            formEditGoal.ShowDialog();

            if (formEditGoal.NeedsRefresh)
                Program.ServiceProvider.GetService<GoalManager>().FillGrid(DataGridView);
        }
    }
}