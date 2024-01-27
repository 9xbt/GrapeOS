using IL2CPU.API.Attribs;
using GrapeGL.Graphics;
using GrapeGL.Graphics.Fonts;

namespace GrapeOS
{
    // This should ideally be in alphabetical order, and so it will be
    internal static class Resources
    {
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Fonts.Charcoal.btf")]
        private static byte[] _CharcoalRaw;
        
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Fonts.Geneva.btf")]
        private static byte[] _GenevaRaw;
        
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.Mouse.bmp")]
        private static byte[] _mouseRaw;

        public static Font Charcoal;
        public static Font Geneva;
        public static Canvas Mouse;

        public static void Generate()
        {
            Charcoal = new Font(_CharcoalRaw, 16);
            Geneva = new Font(_GenevaRaw, 16);
            Mouse = Image.FromBitmap(_mouseRaw);
        }
    }
}
