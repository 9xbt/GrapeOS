using IL2CPU.API.Attribs;
using GrapeOS.Graphics.Apps;
using GrapeGL.Graphics;
using GrapeGL.Graphics.Fonts;
using System.IO;

namespace GrapeOS
{
    internal enum ResourceType
    {
        Priority,
        Normal
    }

    internal static class Resources
    {
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Fonts.Fragment.acf")] private static readonly byte[] _fragmentRaw;
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
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.TalkingMan.bmp")] private static readonly byte[] _talkingManRaw;

        public static BtfFontFace Charcoal, Chicago, Geneva;
        public static AcfFontFace Fragment;
        public static Canvas BootLogo, CloseButton, MaximizeButton, MinimizeButton, CloseButtonPressed, MaximizeButtonPressed, MinimizeButtonPressed, Mouse, TalkingMan;

        public static void Generate(ResourceType type)
        {
            switch (type)
            {
                case ResourceType.Priority:
                    Fragment = new AcfFontFace(new MemoryStream(_fragmentRaw));
                    Charcoal = new BtfFontFace(_charcoalRaw, 16, -1);
                    Chicago = new BtfFontFace(_chicagoRaw, 16);
                    Geneva = new BtfFontFace(_genevaRaw, 16);
                    BootLogo = Image.FromBitmap(_bootLogoRaw);
                    Mouse = Image.FromBitmap(_mouseRaw);
                    return;

                case ResourceType.Normal:
                    CloseButton = Image.FromBitmap(_closeButtonRaw); LoadingDialogue.SetProgress((float)1 / 7);
                    CloseButtonPressed = Image.FromBitmap(_closeButtonPressedRaw); LoadingDialogue.SetProgress((float)2 / 7);
                    MaximizeButton = Image.FromBitmap(_maximizeButtonRaw); LoadingDialogue.SetProgress((float)3 / 7);
                    MaximizeButtonPressed = Image.FromBitmap(_maximizeButtonPressedRaw); LoadingDialogue.SetProgress((float)4 / 7);
                    MinimizeButton = Image.FromBitmap(_minimizeButtonRaw); LoadingDialogue.SetProgress((float)5 / 7);
                    MinimizeButtonPressed = Image.FromBitmap(_minimizeButtonPressedRaw); LoadingDialogue.SetProgress((float)6 / 7);
                    TalkingMan = Image.FromBitmap(_talkingManRaw); LoadingDialogue.SetProgress((float)7 / 7);
                    break;
            }
        }
    }
}
