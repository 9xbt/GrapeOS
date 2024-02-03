using IL2CPU.API.Attribs;
using GrapeOS.Graphics.Apps;
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
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Fonts.Charcoal.btf")] private static readonly byte[] _charcoalRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Fonts.Chicago.btf")] private static readonly byte[] _chicagoRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Fonts.Geneva.btf")] private static readonly byte[] _genevaRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.BootLogo.bmp")] private static readonly byte[] _bootLogoRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.Close.bmp")] private static readonly byte[] _closeButtonRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.ClosePressed.bmp")] private readonly static byte[] _closeButtonPressedRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.Maximize.bmp")] private static readonly byte[] _maximizeButtonRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.MaximizePressed.bmp")] private static readonly byte[] _maximizeButtonPressedRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.Minimize.bmp")] private static readonly byte[] _minimizeButtonRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.MinimizePressed.bmp")] private static readonly byte[] _minimizeButtonPressedRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.Mouse.bmp")] private static readonly byte[] _mouseRaw;

        public static Font Charcoal, Chicago, Geneva;
        public static Canvas BootLogo, CloseButton, MaximizeButton, MinimizeButton, CloseButtonPressed, MaximizeButtonPressed, MinimizeButtonPressed, Mouse;

        public static void Generate(ResourceType type)
        {
            switch (type)
            {
                case ResourceType.Priority:
                    Charcoal = new Font(_charcoalRaw, 16, -1);
                    Chicago = new Font(_chicagoRaw, 16);
                    Geneva = new Font(_genevaRaw, 16);
                    BootLogo = Image.FromBitmap(_bootLogoRaw);
                    Mouse = Image.FromBitmap(_mouseRaw);
                    return;

                case ResourceType.Normal:
                    CloseButton = Image.FromBitmap(_closeButtonRaw); LoadingDialogue.SetProgress((float)1 / 6);
                    CloseButtonPressed = Image.FromBitmap(_closeButtonPressedRaw); LoadingDialogue.SetProgress((float)2 / 6);
                    MaximizeButton = Image.FromBitmap(_maximizeButtonRaw); LoadingDialogue.SetProgress((float)3 / 6);
                    MaximizeButtonPressed = Image.FromBitmap(_maximizeButtonPressedRaw); LoadingDialogue.SetProgress((float)4 / 6);
                    MinimizeButton = Image.FromBitmap(_minimizeButtonRaw); LoadingDialogue.SetProgress((float)5 / 6);
                    MinimizeButtonPressed = Image.FromBitmap(_minimizeButtonPressedRaw); LoadingDialogue.SetProgress((float)6 / 6);
                    break;
            }
        }
    }
}
