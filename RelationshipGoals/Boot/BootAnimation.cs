using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipGoals.Boot
{
    public static class BootAnimation
    {
        public static void Play() => Play(25);

        public static void Play(int amount)
        {
            for (int i = 0; i < amount; i++)
                new FormHeart().Show();
        }
    }
}