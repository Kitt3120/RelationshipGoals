using RelationshipGoals.Properties;
using RelationshipGoals.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelationshipGoals.Goals
{
    internal class GoalManager
    {
        private SQLHandler _sqlHandler;

        public GoalManager()
        {
            NewConnection();
        }

        public void NewConnection()
        {
            _sqlHandler = new SQLHandler(Settings.Default.SQL_Server_Address, Settings.Default.SQL_Server_Schema, Settings.Default.SQL_Server_Login, Settings.Default.SQL_Server_Password);
        }
    }
}