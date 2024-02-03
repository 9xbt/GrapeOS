using System;
using Cosmos.System;
using GrapeGL.Graphics;

namespace GrapeOS.Graphics
{
    internal abstract class Control
    {
        internal int X, Y;
        internal ushort Width, Height;
        internal bool RenderWithAlpha = false;

        internal Window Parent;
        internal Action Clicked;
        internal Canvas Contents;

        public bool IsMouseOver
        {
            get => MouseManager.X > Parent.X + X && MouseManager.X < Parent.X + X + Width &&
                MouseManager.Y > Parent.Y + Y && MouseManager.Y < Parent.Y + Y + Height;
        }

        protected Control(Window Parent, int X, int Y, ushort Width, ushort Height)
        {
            this.Parent = Parent;
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;

            Contents = new Canvas(Width, Height);
            Parent.Controls.Add(this);
        }

        internal virtual void Render()
            => Parent.RenderControls();

        internal virtual void HandleRun()
        {
            if (Parent.Focused &&
                MouseManager.LastMouseState == MouseState.Left &&
                MouseManager.MouseState == MouseState.None)
            {
                Clicked?.Invoke();
            }
        }
    }
}
