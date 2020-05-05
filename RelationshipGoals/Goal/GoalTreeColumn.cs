using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelationshipGoals.Goal
{
    internal class GoalTreeColumn : DataGridViewTextBoxColumn
    {
        public GoalTree GoalTree { get; private set; }

        public GoalTreeColumn(GoalTree goalTree)
        {
            GoalTree = goalTree;
            Name = goalTree.ID.ToString();
            HeaderText = goalTree.Title;
            SortMode = DataGridViewColumnSortMode.NotSortable;
            HeaderCell = new GoalTreeHeaderCell(goalTree);
        }
    }
}