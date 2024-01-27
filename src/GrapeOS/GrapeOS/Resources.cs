using IL2CPU.API.Attribs;
using GrapeGL.Graphics;
using GrapeGL.Graphics.Fonts;

namespace GrapeOS
{
    internal static class Resources
    {
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Fonts.Charcoal.btf")] private static byte[] _CharcoalRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Fonts.Geneva.btf")] private static byte[] _GenevaRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.Mouse.bmp")] private static byte[] _mouseRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.Close.bmp")] private static byte[] _closeButtonRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.Maximize.bmp")] private static byte[] _maximizeButtonRaw;
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.Minimize.bmp")] private static byte[] _minimizeButtonRaw;

        public static Font Charcoal, Geneva;
        public static Canvas Mouse, CloseButton, MaximizeButton, MinimizeButton;

        public static void Generate()
        {
            Charcoal = new Font(_CharcoalRaw, 16, -1);
            Geneva = new Font(_GenevaRaw, 16);
            Mouse = Image.FromBitmap(_mouseRaw);
            CloseButton = Image.FromBitmap(_closeButtonRaw);
            MaximizeButton = Image.FromBitmap(_maximizeButtonRaw);
            MinimizeButton = Image.FromBitmap(_minimizeButtonRaw);
        }
    }
}
