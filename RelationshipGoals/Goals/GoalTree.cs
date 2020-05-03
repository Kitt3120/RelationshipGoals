using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RelationshipGoals.Goals
{
    internal class GoalTree
    {
        public int ID { get; }
        public string Title { get; }
        public string Description { get; }

        private Dictionary<int, Goal> _goals;

        public Goal this[int position] { get => At(position); set => Insert(position, value); }

        public int Count { get => _goals.Count; }
        public Dictionary<int, Goal>.KeyCollection Keys { get => _goals.Keys; }
        public Dictionary<int, Goal>.ValueCollection Values { get => _goals.Values; }

        public bool FullyUnlocked { get { return _goals.Values.All(goal => goal.Unlocked); } }

        public GoalTree(int id, string title, string description)
        {
            ID = id;
            Title = title;
            Description = description;

            _goals = new Dictionary<int, Goal>();
        }

        //Inserts goal at next available free position
        public int Add(Goal goal)
        {
            int nextFreePosition = _goals.Keys.Where(key => !_goals.ContainsKey(key + 1)).Min(key => key) + 1;
            Insert(nextFreePosition, goal);
            return nextFreePosition;
        }

        public void Insert(int position, Goal goal) => _goals[position] = goal;

        public void Remove(Goal goal) => RemoveAt(PositionOf(goal));

        public void RemoveAt(int position) => _goals.Remove(position);

        public int PositionOf(Goal goal) => _goals.Where(pair => pair.Value == goal).FirstOrDefault().Key;

        public int MinPosition() => _goals.Select(pair => pair.Key).Min();

        public int MaxPosition() => _goals.Keys.Max();

        public Goal At(int index) => _goals[index];

        public Goal Before(Goal goal)
        {
            if (!_goals.ContainsValue(goal) || PositionOf(goal) <= MinPosition())
                return null;
            else
                return At(_goals.Where(pair => pair.Key < PositionOf(goal)).Select(pair => pair.Key).Max());
        }

        public Goal After(Goal goal)
        {
            if (!_goals.ContainsValue(goal) || PositionOf(goal) >= MaxPosition())
                return null;
            else
                return At(_goals.Where(pair => pair.Key > PositionOf(goal)).Select(pair => pair.Key).Min());
        }

        public Goal LastUnlocked() => At(LastUnlockedPosition());

        public int LastUnlockedPosition()
        {
            List<int> keysUnlocked = _goals.Where(pair => pair.Value.Unlocked).Select(pair => pair.Key).ToList();
            if (keysUnlocked.Count == 0)
                return -1;
            return keysUnlocked.Max();
        }

        public Goal NextToUnlock() => (FullyUnlocked ? null : At(NextToUnlockPosition()));

        public int NextToUnlockPosition()
        {
            if (FullyUnlocked)
                return -1;

            List<int> possibleNexts = _goals.Where(pair => pair.Key > LastUnlockedPosition()).Select(pair => pair.Key).ToList();
            if (possibleNexts.Count == 0)
                return 0;
            return possibleNexts.Min();
        }

        public Dictionary<int, Goal> Ordered()
        {
            return _goals.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}