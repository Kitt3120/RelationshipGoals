using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelationshipGoals.Services.AssetService;

namespace RelationshipGoals.Boot
{
    public static class BootAnimation
    {
        public static Image HeartImage { get; private set; }

        public static void Play() => Play(10);

        public static void Play(int amount)
        {
            if (HeartImage == null)
                HeartImage = Image.FromFile(Program.ServiceProvider.GetService<AssetService>().FindSub("Boot").FilterFiles("heart.png")[0]);

            for (int i = 0; i < amount; i++)
                new FormHeart().Show();
        }
    }
}