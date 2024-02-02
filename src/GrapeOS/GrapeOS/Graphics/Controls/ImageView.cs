using GrapeGL.Graphics;

namespace GrapeOS.Graphics.Controls
{
    internal sealed class ImageView : Control
    {
        internal Canvas Image;

        internal ImageView(Window Parent, int X, int Y, Canvas Image) : base(Parent, X, Y, (ushort)(Image.Width + 4), (ushort)(Image.Height + 4))
        {
            this.Image = Image;
            RenderWithAlpha = true;

            Render();
        }

        internal override void Render()
        {
            Contents.Clear(new Color(0));
            Contents.DrawImage(2, 2, Image);
            Parent.Render();
        }
    }
}
