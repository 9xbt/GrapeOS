using GrapeOS.Graphics.Controls;
using GrapeGL.Graphics;

namespace GrapeOS.Graphics.Apps
{
    internal sealed class HelloWorld : Window
    {
        internal HelloWorld() : base(150, 150, 300, 200, "Test Application")
        {
            Borderless = true;

            _ = new Label(this, 10, 10, "Hello, world!", Resources.Geneva, Color.Black);
        }
    }
}
