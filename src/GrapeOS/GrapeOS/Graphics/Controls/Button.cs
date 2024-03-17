using GrapeGL.Graphics;

namespace GrapeOS.Graphics.Controls
{
    internal class Button : Control
    {
        internal string Text;

        internal Button(Window Parent, int X, int Y, ushort Width, ushort Height, string Text) : base(Parent, X, Y, Width, Height)
        {
            this.Text = Text;
            RenderWithAlpha = true;

            Render();
        }

        internal override void Render()
        {
            Contents.Clear(new Color(0));
            Contents.DrawFilledRectangle(1, 1, (ushort)(Width - 2), (ushort)(Height - 2), 0, Pressed ? new Color(0xFF666666) : new Color(0xFFE7E7E7));
            Contents.DrawFilledRectangle(3, 3, (ushort)(Width - 4), (ushort)(Height - 4), 0, Pressed ? new Color(0xFF878787) : new Color(0xFFE7E7E7));

            Contents[2, 0] = new Color(0xFF3F3F3F);
            Contents[1, 1] = Color.Black;
            Contents[0, 2] = new Color(0xFF3F3F3F);
            Contents[2, 1] = new Color(Pressed ? 0xFF666666 : 0xFFCDCDCD);
            Contents[1, 2] = new Color(Pressed ? 0xFF666666 : 0xFFCDCDCD);
            Contents[Width - 3, 0] = new Color(0xFF3F3F3F);
            Contents[Width - 2, 1] = Color.Black;
            Contents[Width - 1, 2] = new Color(0xFF3F3F3F);
            Contents[Width - 3, 1] = new Color(Pressed ? 0xFF666666 : 0xFFCDCDCD);
            Contents[Width - 2, 2] = new Color(Pressed ? 0xFF666666 : 0xFFCDCDCD);
            Contents[0, Height - 3] = new Color(0xFF3F3F3F);
            Contents[1, Height - 2] = Color.Black;
            Contents[2, Height - 1] = new Color(0xFF3F3F3F);
            Contents[1, Height - 3] = new Color(Pressed ? 0xFF666666 : 0xFFCDCDCD);
            Contents[2, Height - 2] = new Color(Pressed ? 0xFF666666 : 0xFFCDCDCD);
            Contents[Width - 1, Height - 3] = new Color(0xFF3F3F3F);
            Contents[Width - 2, Height - 2] = Color.Black;
            Contents[Width - 3, Height - 1] = new Color(0xFF3F3F3F);
            Contents[3, 3] = Pressed ? new Color(0xFF777777) : Color.White;
            Contents[Width - 3, Height - 3] = Pressed ? new Color(0xFFA5A5A5) : new Color(0xFF969696);
            Contents[Width - 4, Height - 4] = Pressed ? new Color(0xFF969696) : new Color(0xFFC0C0C0);

            Contents.DrawLine(3, 0, Width - 3, 0, Color.Black);
            Contents.DrawLine(0, 3, 0, Height - 3, Color.Black);
            Contents.DrawLine(Width - 1, 3, Width - 1, Height - 3, Color.Black);
            Contents.DrawLine(3, Height - 1, Width - 3, Height - 1, Color.Black);
            Contents.DrawLine(2, 2, Width - 3, 2, Pressed ? new Color(0xFF777777) : Color.White);
            Contents.DrawLine(2, 2, 2, Height - 3, Pressed ? new Color(0xFF777777) : Color.White);
            Contents.DrawLine(Width - 2, 3, Width - 2, Height - 2, Pressed ? new Color(0xFFA5A5A5) : new Color(0xFF969696));
            Contents.DrawLine(3, Height - 2, Width - 2, Height - 2, Pressed ? new Color(0xFFA5A5A5) : new Color(0xFF969696));
            Contents.DrawLine(Width - 3, 3, Width - 3, Height - 3, Pressed ? new Color(0xFF969696) : new Color(0xFFC0C0C0));
            Contents.DrawLine(3, Height - 3, Width - 3, Height - 3, Pressed ? new Color(0xFF969696) : new Color(0xFFC0C0C0));

            Contents.DrawString((Width / 2) - (Resources.Charcoal.MeasureString(Text) / 2) - 1, (Height / 2) - (Resources.Charcoal.GetHeight() / 2) - 1,
                Text, Resources.Charcoal, Pressed ? Color.White : Color.Black);

            base.Render();
        }

        internal override void HandleDown()
        {
            base.HandleDown();
            Render();
        }

        internal override void HandleUp()
        {
            base.HandleDown();
            Render();
        }
    }
}
