using IL2CPU.API.Attribs;
//using GrapeOS.Graphics.Apps;
using GrapeGL.Graphics;
using GrapeGL.Graphics.Fonts;

namespace GrapeOS
{
    internal enum ResourceType
    {
        Priority,
        Normal
    }

    internal static class Resources
    {
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Fonts.Charcoal.btf")] private static readonly byte[] _CharcoalRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Fonts.Geneva.btf")] private static readonly byte[] _GenevaRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.BootLogo.bmp")] private static readonly byte[] _bootLogoRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.Close.bmp")] private static readonly byte[] _closeButtonRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.ClosePressed.bmp")] private readonly static byte[] _closeButtonPressedRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.Maximize.bmp")] private static readonly byte[] _maximizeButtonRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.MaximizePressed.bmp")] private static readonly byte[] _maximizeButtonPressedRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.Minimize.bmp")] private static readonly byte[] _minimizeButtonRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.MinimizePressed.bmp")] private static readonly byte[] _minimizeButtonPressedRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.Mouse.bmp")] private static readonly byte[] _mouseRaw;

        public static Font Charcoal, Geneva;
        public static Canvas BootLogo, CloseButton, MaximizeButton, MinimizeButton, CloseButtonPressed, MaximizeButtonPressed, MinimizeButtonPressed, Mouse;

        public static void Generate(ResourceType type)
        {
            switch (type)
            {
                case ResourceType.Priority:
                    Charcoal = new Font(_CharcoalRaw, 16, -1);
                    Geneva = new Font(_GenevaRaw, 16);
                    BootLogo = Image.FromBitmap(_bootLogoRaw);
                    Mouse = Image.FromBitmap(_mouseRaw);
                    return;

                case ResourceType.Normal:
                    CloseButton = Image.FromBitmap(_closeButtonRaw); //LoadingDialogue.ItemsLoaded++;
                    CloseButtonPressed = Image.FromBitmap(_closeButtonPressedRaw); //LoadingDialogue.ItemsLoaded++;
                    MaximizeButton = Image.FromBitmap(_maximizeButtonRaw); //LoadingDialogue.ItemsLoaded++;
                    MaximizeButtonPressed = Image.FromBitmap(_maximizeButtonPressedRaw); //LoadingDialogue.ItemsLoaded++;
                    MinimizeButton = Image.FromBitmap(_minimizeButtonRaw); //LoadingDialogue.ItemsLoaded++;
                    MinimizeButtonPressed = Image.FromBitmap(_minimizeButtonPressedRaw); //LoadingDialogue.ItemsLoaded++;
                    break;
            }
        }
    }
}
