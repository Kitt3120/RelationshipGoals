using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipGoals.Goals
{
    public class Goal
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PointsCurrent { get; set; }
        public int PointsToUnlock { get; set; }
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