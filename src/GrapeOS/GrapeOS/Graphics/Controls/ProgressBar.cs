using System;
using GrapeGL.Graphics;

namespace GrapeOS.Graphics.Controls
{
    internal class ProgressBar : Control
    {
        internal double Value;

        internal ProgressBar(Window Parent, int X, int Y, ushort Width, ushort Height) : base(Parent, X, Y, Width, Height)
            => Render();

        internal override void Render()
        {
            Contents.Clear(new Color(0xFFDADAFF));
            Contents.DrawRectangle(0, 0, Width, Height, 0, Color.Black);
            Contents.DrawFilledRectangle(1, 1, (ushort)Math.Ceiling(Value * (Width - 2) / 100), (ushort)(Height - 2), 0, new Color(0xFF666666));
            
            base.Render();
        }
    }
}
