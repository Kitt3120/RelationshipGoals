using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipGoals.Goals
{
    public class Goal
    {
        public int ID { get; }
        public string Title { get; }
        public string Description { get; }
        public int PointsCurrent { get; }
        public int PointsToUnlock { get; }
        public bool Unlocked { get { return PointsCurrent >= PointsToUnlock; } }

        public Goal(int id, string title, string description, int pointsCurrent, int pointsToUnlock)
        {
            ID = id;
            Title = title;
            Description = description;
            PointsCurrent = pointsCurrent;
            PointsToUnlock = pointsToUnlock;
        }
    }
}