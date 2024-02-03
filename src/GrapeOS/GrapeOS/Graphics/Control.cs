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
        internal bool Pressed;

        internal Window Parent;
        internal Action Clicked;
        internal Canvas Contents;

        public bool IsMouseOver
        {
            get => MouseManager.X > Parent.X + X + (Parent.Borderless ? 2 : 6) &&
                MouseManager.X < Parent.X + X + Width + (Parent.Borderless ? 2 : 6) &&
                MouseManager.Y > Parent.Y + Y + (Parent.Borderless ? 2 : 22) &&
                MouseManager.Y < Parent.Y + Y + Height + (Parent.Borderless ? 2 : 22);
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

        internal virtual void HandleDown()
            => Pressed = true;

        internal virtual void HandleUp()
            => Pressed = false;

        internal virtual void Render()
            => Parent.RenderControls();

        internal virtual void HandleRun()
        {
            if (Parent.Focused && IsMouseOver &&
                MouseManager.LastMouseState == MouseState.None &&
                MouseManager.MouseState == MouseState.Left)
            {
                HandleDown();
            }

            if (Parent.Focused && IsMouseOver &&
                MouseManager.LastMouseState == MouseState.Left &&
                MouseManager.MouseState == MouseState.None)
            {
                HandleUp();

                if (IsMouseOver) Clicked?.Invoke();
            }
        }
    }
}
