﻿using System.Collections.Generic;
using System.Linq;

namespace RelationshipGoals.Goals
{
    internal class GoalTree
    {
        public int ID { get; }
        public string Title { get; }
        public string Description { get; }

        private List<Goal> _goals;

        public GoalTree(int id, string title, string description)
        {
            ID = id;
            Title = title;
            Description = description;

            _goals = new List<Goal>();
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

        public int LastUnlockedIndex() => _goals.FindLastIndex(goal => goal.Unlocked);
    }
}