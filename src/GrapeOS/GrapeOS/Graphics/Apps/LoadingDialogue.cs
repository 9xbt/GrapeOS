using GrapeOS.Graphics.Controls;
using GrapeGL.Graphics;

namespace GrapeOS.Graphics.Apps
{
    internal sealed class LoadingDialogue : Window
    {
        internal static LoadingDialogue Instance;

        internal static void SetProgress(float progress)
        {
            Instance.LoadingBar.Value = progress * 100;
            Instance.LoadingBar.Render();
            WindowManager.Render();
        }

        internal ProgressBar LoadingBar;

        internal LoadingDialogue() : base((WindowManager.Screen.Width / 2) - (422 / 2),
            (WindowManager.Screen.Height / 2) - (323 / 2),422, 323, nameof(LoadingDialogue))
        {
            Borderless = true;

            _ = new Label(this, ((Width - 4) / 2) - (Resources.Chicago.MeasureString("Starting Up...") / 2),
                268, "Starting Up...", Resources.Chicago, Color.Black);
            _ = new ImageView(this, 33, 24, Resources.BootLogo);
            LoadingBar = new ProgressBar(this, 129, 289, 160, 12);

            Render();
        }
    }
}
