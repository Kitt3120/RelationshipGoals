using RelationshipGoals.Services.AssetService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelationshipGoals.Boot
{
    //TODO: Replace with FormHearts, a maximized, transparent form and only use Graphics object to render hearts
    public partial class FormHeart : Form
    {
        private static Image _heartImage;

        private Random _random;
        private int _ticksLived;
        private double _speed;
        private Task _animationTask;
        private Point _location;
        private int _xOffset;

        public FormHeart()
        {
            InitializeComponent();
            _random = new Random();
            _ticksLived = 0;
            _speed = 0.0D;
            _animationTask = new Task(AnimationTick);
            _xOffset = 0;

            if (_heartImage == null)
                _heartImage = Image.FromFile(Program.ServiceProvider.GetService<AssetService>().FindSub("Boot").FilterFiles("heart.png")[0]);

            pictureBoxHeart.Image = _heartImage;

            Rectangle screenBounds = Screen.FromControl(this).Bounds;
            _location = new Point(_random.Next(Width, screenBounds.Width) - Width, screenBounds.Height);
            ApplyLocation();
        }

        private async void AnimationTick()
        {
            double swingSpeed = _random.NextDouble() / 10;
            int swingRange = _random.Next(75, 200);

            MethodInvoker applyLocationInvoker = new MethodInvoker(ApplyLocation);
            while (_location.Y + Height >= 0)
            {
                _speed += 0.5D;

                _location.Y -= (int)_speed;
                _xOffset = (int)(Math.Sin(_ticksLived * swingSpeed) * swingRange);
                Invoke(applyLocationInvoker);

                _ticksLived += 1;
                await Task.Delay(1);
            }

            Invoke(new MethodInvoker(Close));
        }

        private void ApplyLocation() => SetDesktopLocation(_location.X + _xOffset, _location.Y);

        private async void FormHeart_Load(object sender, EventArgs e)
        {
            await Task.Delay(1000); //Wait so the heart pictures really are loaded
            _animationTask.Start();
        }
    }
}