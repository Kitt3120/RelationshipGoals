using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace RelationshipGoals.Goal
{
    internal class GoalTreeHeaderCell : DataGridViewColumnHeaderCell
    {
        public GoalTree GoalTree { get; private set; }

        public GoalTreeHeaderCell(GoalTree goalTree)
        {
            GoalTree = goalTree;
            Value = $"{goalTree.Title} ({goalTree.GetValues().Where(value => value.Unlocked).Count()}/{goalTree.Count})";
            ToolTipText = goalTree.Description;
            Style.BackColor = (goalTree.FullyUnlocked ? Color.Violet : Color.Plum);
        }

        protected override void OnDoubleClick(DataGridViewCellEventArgs e)
        {
            base.OnDoubleClick(e);
            FormEditGoalTree formEditGoalTree = new FormEditGoalTree(GoalTree);
            formEditGoalTree.ShowDialog();

            if (formEditGoalTree.NeedsRefresh)
                Program.ServiceProvider.GetService<GoalManager>().FillGrid(DataGridView);
        }
    }
}