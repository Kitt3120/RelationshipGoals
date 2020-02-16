using System.Collections.Generic;
using System.Linq;

namespace RelationshipGoals.Goals
{
    internal class GoalTree
    {
        public int ID { get; }
        public string Title { get; }
        public string Description { get; }

        private Dictionary<int, Goal> _goals;

        public GoalTree(int id, string title, string description)
        {
            ID = id;
            Title = title;
            Description = description;

            _goals = new Dictionary<int, Goal>();
        }

        public void Add(Goal goal) => _goals.Add(_goals.Count, goal);

        public void Insert(int index, Goal goal) => _goals.Add(index, goal);

        public void Remove(Goal goal) => _goals.Remove(_goals.Where(pair => pair.Value == goal).Select(pair => pair.Key).FirstOrDefault());

        public void RemoveAt(int index) => _goals.Remove(index);

        public int PositionOf(Goal goal) => _goals.Where(pair => pair.Value == goal).Select(pair => pair.Key).FirstOrDefault();

        public Goal At(int index) => _goals[index];

        public Goal Before(Goal goal)
        {
            if (!_goals.ContainsValue(goal))
                return null;
            else if (PositionOf(goal) == 0)
                return null;
            else
                return _goals[PositionOf(goal) - 1];
        }

        public Goal After(Goal goal)
        {
            if (!_goals.ContainsValue(goal))
                return null;
            else if (PositionOf(goal) >= _goals.Count - 1)
                return null;
            else
                return _goals[PositionOf(goal) + 1];
        }

        public Goal LastUnlocked() => _goals.FirstOrDefault(pair => pair.Value.Unlocked).Value;

        public int LastUnlockedPosition() => _goals.FirstOrDefault(pair => pair.Value.Unlocked).Key;
    }
}