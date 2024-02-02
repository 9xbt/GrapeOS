using GrapeOS.Graphics;
using GrapeOS.Graphics.Controls;

namespace GrapeOS.Graphics.Apps
{
    internal sealed class LoadingDialogue : Window
    {
        internal LoadingDialogue() : base(189, 83, 422, 323, nameof(LoadingDialogue))
        {
            Borderless = true;

            //_ = new Label(this, ((Width - 4) / 2) - ());
        }
    }
}
