using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrapeGL.Graphics;

namespace GrapeOS.Graphics.Apps
{
    internal class Test : Window
    {
        internal Test() : base(50, 50, 300, 200, "Test Application")
        {

        }

        internal override void Render()
        {
            base.Render();

            Contents.DrawString(10, 10, "Hello, world!", Resources.Charcoal, Color.Black, Shadow: true);
        }
    }
}
