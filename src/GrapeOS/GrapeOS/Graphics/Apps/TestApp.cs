using GrapeOS.Graphics.Controls;
using GrapeGL.Graphics;

namespace GrapeOS.Graphics.Apps
{
    internal sealed class TestApp : Window
    {
        private ProgressBar _bar;

        internal TestApp() : base(90, 150, 300, 200, "Test Application")
        {
            _ = new Label(this, 10, 10, "Hello, world!", Resources.Geneva, Color.Black);
            _bar = new ProgressBar(this, 10, 36, 160, 12);
            _ = new Button(this, 10, 58, 63, 20, "Close");
        }

        internal override void HandleRun()
        {
            base.HandleRun();

            if (_bar.Value >= 100) _bar.Value = 0;

            _bar.Value += 0.10;
            _bar.Render();
            WindowManager.Render();
        }
    }
}
