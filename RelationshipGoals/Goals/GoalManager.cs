using RelationshipGoals.Properties;
using RelationshipGoals.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelationshipGoals.Goals
{
    internal class GoalManager
    {
        private SQLHandler _sqlHandler;

        public List<Goal> Goals { get; private set; }
        public List<GoalTree> GoalTrees { get; private set; }

        public GoalManager()
        {
            Goals = new List<Goal>();
            GoalTrees = new List<GoalTree>();

            NewConnection();
            FetchData();
        }

        public void NewConnection() => _sqlHandler = new SQLHandler(Settings.Default.SQL_Server_Address, Settings.Default.SQL_Server_Schema, Settings.Default.SQL_Server_Login, Settings.Default.SQL_Server_Password);

        public void FetchData()
        {
            //Goals
            List<Goal> newGoals = new List<Goal>();

            DataTable goalDataTable = _sqlHandler.ReadQuery("SELECT * FROM Goal");
            foreach (DataRow row in goalDataTable.Rows)
            {
                int id = (int)row.ItemArray[0];
                string title = (string)row.ItemArray[1];
                string description = (string)row.ItemArray[2];
                int pointsCurrent = int.Parse(row.ItemArray[3].ToString());
                int pointsToUnlock = int.Parse(row.ItemArray[3].ToString());

                newGoals.Add(new Goal(id, title, description, pointsCurrent, pointsToUnlock));
            }

            //GoalTrees
            List<GoalTree> newGoalTrees = new List<GoalTree>();

            DataTable goalTreesDataTable = _sqlHandler.ReadQuery("SELECT * FROM GoalTree");
            foreach (DataRow row in goalTreesDataTable.Rows)
            {
                int id = (int)int.Parse(row.ItemArray[0].ToString());
                string title = (string)row.ItemArray[1];
                string description = (string)row.ItemArray[2];

                newGoalTrees.Add(new GoalTree(id, title, description));
            }

            //GoalOccurences
            DataTable goalOccurenceDataTable = _sqlHandler.ReadQuery("SELECT * FROM GoalOccurence");
            foreach (DataRow row in goalOccurenceDataTable.Rows)
            {
                int goalTreeId = int.Parse(row.ItemArray[0].ToString());
                int goalId = int.Parse(row.ItemArray[1].ToString());
                int position = int.Parse(row.ItemArray[2].ToString());

                newGoalTrees.Where(tree => tree.ID == goalTreeId).FirstOrDefault().Insert(position, newGoals.Where(goal => goal.ID == goalId).FirstOrDefault());
            }

            Goals = newGoals;
            GoalTrees = newGoalTrees;
        }

        public async Task FetchDataAsync()
        {
            //Goals
            List<Goal> newGoals = new List<Goal>();

            DataTable goalDataTable = await _sqlHandler.ReadQueryAsync("SELECT * FROM Goal");
            foreach (DataRow row in goalDataTable.Rows)
            {
                int id = (int)row.ItemArray[0];
                string title = (string)row.ItemArray[1];
                string description = (string)row.ItemArray[2];
                int pointsCurrent = int.Parse(row.ItemArray[3].ToString());
                int pointsToUnlock = int.Parse(row.ItemArray[3].ToString());

                newGoals.Add(new Goal(id, title, description, pointsCurrent, pointsToUnlock));
            }

            //GoalTrees
            List<GoalTree> newGoalTrees = new List<GoalTree>();

            DataTable goalTreesDataTable = await _sqlHandler.ReadQueryAsync("SELECT * FROM GoalTree");
            foreach (DataRow row in goalTreesDataTable.Rows)
            {
                int id = (int)int.Parse(row.ItemArray[0].ToString());
                string title = (string)row.ItemArray[1];
                string description = (string)row.ItemArray[2];

                newGoalTrees.Add(new GoalTree(id, title, description));
            }

            //GoalOccurences
            DataTable goalOccurenceDataTable = await _sqlHandler.ReadQueryAsync("SELECT * FROM GoalOccurence");
            foreach (DataRow row in goalOccurenceDataTable.Rows)
            {
                int goalTreeId = int.Parse(row.ItemArray[0].ToString());
                int goalId = int.Parse(row.ItemArray[1].ToString());
                int position = int.Parse(row.ItemArray[2].ToString());

                newGoalTrees.Where(tree => tree.ID == goalTreeId).FirstOrDefault().Insert(position, newGoals.Where(goal => goal.ID == goalId).FirstOrDefault());
            }

            Goals = newGoals;
            GoalTrees = newGoalTrees;
        }
    }
}