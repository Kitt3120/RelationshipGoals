using System.Collections.Generic;

namespace RelationshipGoals.Goals
{
    internal class GoalTree
    {
        private List<Goal> _goals;

        public string Title { get; }

        public GoalTree(string title)
        {
            _goals = new List<Goal>();
            Title = title;
        }

        public void Add(Goal goal) => _goals.Add(goal);

        public void Insert(int index, Goal goal) => _goals.Insert(index, goal);

        public void Remove(Goal goal) => _goals.Remove(goal);

        public void RemoveAt(int index) => _goals.RemoveAt(index);

        public int IndexOf(Goal goal) => _goals.IndexOf(goal);

        public Goal At(int index) => _goals[index];

        public Goal Before(Goal goal)
        {
            if (!_goals.Contains(goal))
                return null;
            else if (_goals.IndexOf(goal) == 0)
                return null;
            else
                return _goals[_goals.IndexOf(goal) - 1];
        }

        public Goal After(Goal goal)
        {
            if (!_goals.Contains(goal))
                return null;
            else if (_goals.IndexOf(goal) >= _goals.Count - 1)
                return null;
            else
                return _goals[_goals.IndexOf(goal) + 1];
        }

        public Goal LastUnlocked() => _goals.FindLast(goal => goal.Unlocked);

        public Goal LastUnlockedIndex() => _goals.FindLast(goal => goal.Unlocked);
    }
}