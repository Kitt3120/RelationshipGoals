using RelationshipGoals.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipGoals.Goal
{
    public class Goal
    {
        public int ID { get; }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    SQLHandler.Current.SendQuery($"update Goal set Title = '{value}' where ID = {ID}");
                    _title = value;
                }
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    SQLHandler.Current.SendQuery($"update Goal set Description = '{value}' where ID = {ID}");
                    _description = value;
                }
            }
        }

        private int _pointsCurrent;

        public int PointsCurrent
        {
            get { return _pointsCurrent; }
            set
            {
                if (_pointsCurrent != value)
                {
                    SQLHandler.Current.SendQuery($"update Goal set PointsCurrent = {value} where ID = {ID}");
                    _pointsCurrent = value;
                }
            }
        }

        private int _pointsToUnlock;

        public int PointsToUnlock
        {
            get { return _pointsToUnlock; }
            set
            {
                if (_pointsToUnlock != value)
                {
                    SQLHandler.Current.SendQuery($"update Goal set PointsToUnlock = {value} where ID = {ID}");
                    _pointsToUnlock = value;
                }
            }
        }

        public bool Unlocked { get { return PointsCurrent >= PointsToUnlock; } }

        public Goal(int id, string title, string description, int pointsCurrent, int pointsToUnlock)
        {
            ID = id;
            _title = title;
            _description = description;
            _pointsCurrent = pointsCurrent;
            _pointsToUnlock = pointsToUnlock;
        }
    }
}