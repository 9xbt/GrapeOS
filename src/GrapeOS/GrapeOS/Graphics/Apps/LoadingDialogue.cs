using GrapeOS.Tasking;
using GrapeOS.Graphics;
using GrapeOS.Graphics.Controls;
using GrapeGL.Graphics;

namespace GrapeOS.Graphics.Apps
{
    internal sealed class LoadingDialogue : Window
    {
        internal LoadingDialogue() : base(301, 223, 422, 323, nameof(LoadingDialogue))
        {
            Borderless = true;

            _ = new Label(this, ((Width - 4) / 2) - (Resources.Charcoal.MeasureString("Starting Up...") / 2),
                268, "Starting Up...", Resources.Charcoal, Color.Black);
            _ = new ImageView(this, 33, 24, Resources.BootLogo);
        }
    }
}
