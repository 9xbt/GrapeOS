using GrapeGL.Graphics;
using GrapeGL.Graphics.Fonts;

namespace GrapeOS.Graphics.Controls
{
    internal sealed class Label : Control
    {
        internal string Text;
        internal FontFace Font;
        internal Color Color;

        internal Label(Window Parent, int X, int Y, string Text, FontFace Font, Color Color) : base(Parent, X, Y, Font.MeasureString(Text), (ushort)Font.GetHeight())
        {
            this.Text = Text;
            this.Font = Font;
            this.Color = Color;
            RenderWithAlpha = true;

            Render();
        }

        internal override void Render()
        {
            Contents.Clear(Color.Transparent);
            Contents.DrawString(0, 0, Text, Font, Color);

            base.Render();
        }
    }
}
