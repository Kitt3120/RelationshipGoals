using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace RelationshipGoals.Goals
{
    internal class GoalTree
    {
        public int ID { get; }
        public string Title { get; }
        public string Description { get; }
        public OrderedDictionary Goals { get; }

        public GoalTree(int id, string title, string description)
        {
            ID = id;
            Title = title;
            Description = description;

            Goals = new OrderedDictionary();
        }

        public void Add(Goal goal) => Goals.Add(Goals.Count, goal);

        public void Insert(int index, Goal goal) => Goals.Add(index, goal);

        public void Remove(Goal goal) => Goals.RemoveAt(PositionOf(goal));

        public void RemoveAt(int index) => Goals.Remove(index);

        public int PositionOf(Goal goal) => Goals.OfType<KeyValuePair<int, object>>().Where(pair => pair.Value == goal).Select(pair => pair.Key).FirstOrDefault(); //Goals.Where(pair => pair.Value == goal).private Select(pair => pair.Key).private FirstOrDefault();

        public Goal At(int index) => (Goal)Goals[index];

        public Goal Before(Goal goal)
        {
            if (!Goals.Contains(goal))
                return null;
            else if (PositionOf(goal) == 0)
                return null;
            else
                return (Goal)Goals[PositionOf(goal) - 1];
        }

        public Goal After(Goal goal)
        {
            if (!Goals.Contains(goal))
                return null;
            else if (PositionOf(goal) >= Goals.Count - 1)
                return null;
            else
                return (Goal)Goals[PositionOf(goal) + 1];
        }

        public Goal LastUnlocked() => Goals.Values.OfType<Goal>().LastOrDefault(goal => goal.Unlocked);

        public int LastUnlockedPosition() => PositionOf(LastUnlocked());
    }
}