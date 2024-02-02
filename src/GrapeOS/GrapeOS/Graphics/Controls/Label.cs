using GrapeGL.Graphics;
using GrapeGL.Graphics.Fonts;

namespace GrapeOS.Graphics.Controls
{
    internal sealed class Label : Control
    {
        internal string Text;
        internal Font Font;
        internal Color Color;

        internal Label(Window Parent, int X, int Y, string Text, Font Font, Color Color) : base(Parent, X, Y, Font.MeasureString(Text), Font.Size)
        {
            this.Text = Text;
            this.Font = Font;
            this.Color = Color;
            RenderWithAlpha = true;

            Render();
        }

        internal override void Render()
        {
            Contents.Clear(new Color(0));
            Contents.DrawString(0, 0, Text, Font, Color);
            Parent.Render();
        }
    }
}
