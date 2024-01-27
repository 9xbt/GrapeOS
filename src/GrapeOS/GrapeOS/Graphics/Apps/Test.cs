using GrapeGL.Graphics;

namespace GrapeOS.Graphics.Apps
{
    internal class Test : Window
    {
        internal Test() : base(150, 150, 300, 200, "Test Application")
        {

        }

        internal override void Render()
        {
            base.Render();

            Contents.DrawString(150, 86, "Hello, world!", Resources.Geneva, Color.Black, true);
        }
    }
}
