using RelationshipGoals.Services.AssetService;
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
    //TODO: Replace with FormHearts, a maximized, transparent form and only use Graphics to render hearts
    public partial class FormHeart : Form
    {
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

            pictureBoxHeart.Image = BootAnimation.HeartImage;

            Rectangle screenBounds = Screen.FromControl(this).Bounds;
            _location = new Point(_random.Next(Width, screenBounds.Width) - Width, screenBounds.Height);
            ApplyLocation();
        }

        private async void AnimationTick()
        {
            double swingSpeed = _random.NextDouble() / 10;
            int swingRange = _random.Next(75, 200);
            double acceleration = _random.NextDouble() / 4 + 0.1D;

            MethodInvoker applyLocationInvoker = new MethodInvoker(ApplyLocation);
            try
            {
                while (_location.Y + Height >= 0)
                {
                    _speed += acceleration;

                    _location.Y -= (int)_speed;
                    _xOffset = (int)(Math.Sin(_ticksLived * swingSpeed) * swingRange);
                    Invoke(applyLocationInvoker);

                    _ticksLived += 1;
                    await Task.Delay(1);
                }

                Invoke(new MethodInvoker(Close));
            }
            catch (ObjectDisposedException)
            { }
            catch (InvalidOperationException)
            { }
        }

        private void ApplyLocation() => SetDesktopLocation(_location.X + _xOffset, _location.Y);

        private async void FormHeart_Load(object sender, EventArgs e)
        {
            await Task.Delay(1000); //Wait so the heart pictures really are loaded
            _animationTask.Start();
        }
    }
}