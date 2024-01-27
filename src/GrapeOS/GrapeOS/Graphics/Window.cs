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
            Render();

            WindowManager.Instance.AddWindow(this);
        }

        internal virtual void Render()
        {
            Contents.Clear(new Color(0xFFDADADA));

            // Render the window border
            Contents.DrawRectangle(0, 0, Width, Height, 0, Color.Black);
            Contents.DrawLine(1, 1, Width - 2, 1, Color.White);
            Contents.DrawLine(1, 1, 1, Height - 2, Color.White);
            Contents.DrawLine(2, Height - 2, Width - 1, Height - 2, new Color(Borderless ? 0xFFC0C0C0 : 0xFFB3B3B3));
            Contents.DrawLine(Width - 2, 2, Width - 2, Height - 2, new Color(Borderless ? 0xFFC0C0C0 : 0xFFB3B3B3));

            if (Borderless)
            {
                Contents[Width - 2, 1] = new Color(0xFFF3F3F3);
                Contents[1, Height - 2] = new Color(0xFFF3F3F3);
                return;
            }

            // Render title bar
            Contents.DrawImage(4, 4, Resources.CloseButton);
            Contents.DrawImage(Width - 33, 4, Resources.MaximizeButton);
            Contents.DrawImage(Width - 17, 4, Resources.MinimizeButton);

            for (int i = 0; i < 6; i++) Contents.DrawLine(21, 4 + i * 2, Width - 38, 4 + i * 2, Color.White);
            for (int i = 0; i < 6; i++) Contents.DrawLine(22, 5 + i * 2, Width - 37, 5 + i * 2, new Color(0xFF969696));

            Contents.DrawFilledRectangle((Width / 2) - (Resources.Charcoal.MeasureString(Title) / 2),
                4, Resources.Charcoal.MeasureString(Title), 12, 0, new Color(0xFFDADADA));
            Contents.DrawString((Width / 2) - ((Resources.Charcoal.MeasureString(Title) - 8) / 2) + 4,
                2, Title, Resources.Charcoal, Color.Black, SpacingModifier: -1);

            // Render window contents area
            Contents.DrawLine(4, 20, Width - 6, 20, new Color(0xFFB3B3B3));
            Contents.DrawLine(4, 20, 4, Height - 6, new Color(0xFFB3B3B3));
            Contents.DrawLine(4, Height - 6, Width - 5, Height - 6, Color.White);
            Contents.DrawLine(Width - 5, 21, Width - 5, Height - 6, Color.White);
            Contents.DrawRectangle(5, 21, (ushort)(Width - 10), (ushort)(Height - 27), 0, Color.Black);

            Contents.DrawFilledRectangle(6, 22, (ushort)(Width - 12), (ushort)(Height - 29), 0, new Color(0xFFE7E7E7));
        }

        internal override void HandleRun()
        {
            
        }
    }
}
