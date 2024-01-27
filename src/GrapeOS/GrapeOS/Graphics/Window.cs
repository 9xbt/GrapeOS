using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrapeOS.Tasking;
using GrapeGL.Graphics;

namespace GrapeOS.Graphics
{
    internal class Window : Process
    {
        internal string Title;
        internal int X, Y;
        internal ushort Width, Height;

        internal bool Borderless = false;
        internal Canvas Contents;

        protected Window(int X, int Y, ushort Width, ushort Height, string Title) : base(Title)
        {
            this.Title = Title;
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;

            Contents = new Canvas(Width, Height);
        }

        internal virtual void Render()
        {
            Contents.Clear(new Color(231, 231, 231));

            Contents.DrawRectangle(0, 0, Width, Height, 0, Color.Black);
        }

        internal override void HandleRun()
        {
            
        }
    }
}
