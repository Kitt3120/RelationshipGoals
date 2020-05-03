using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelationshipGoals.Goals
{
    internal class GoalTreeHeaderCell : DataGridViewColumnHeaderCell
    {
        public GoalTree GoalTree { get; private set; }

        public GoalTreeHeaderCell(GoalTree goalTree)
        {
            GoalTree = goalTree;
            Value = $"{goalTree.Title} ({goalTree.Values.Where(value => value.Unlocked).Count()}/{goalTree.Count})";
            ToolTipText = goalTree.Description;
            Style.BackColor = (goalTree.FullyUnlocked ? Color.Green : Color.Orange);
        }

        protected override void OnDoubleClick(DataGridViewCellEventArgs e)
        {
            base.OnDoubleClick(e);
            MessageBox.Show("Clicked Goal-Tree \"" + GoalTree.Title + "\"");
        }
    }
}