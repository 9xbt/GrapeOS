using IL2CPU.API.Attribs;
using GrapeGL.Graphics;
using GrapeGL.Graphics.Fonts;

namespace GrapeOS
{
    // This should ideally be in alphabetical order, and so it will be
    internal static class Resources
    {
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Fonts.Charcoal.btf")]
        private static byte[] _fontCharcoalRaw;
        
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Fonts.Geneva.btf")]
        private static byte[] _fontGenevaRaw;
        
        [ManifestResourceStream(ResourceName = "GrapeOS.Resources.Images.Mouse.bmp")]
        private static byte[] _mouseRaw;

        public static Font FontCharcoal;
        public static Font FontGeneva;
        public static Canvas Mouse;

        public static void Generate()
        {
            FontCharcoal = new Font(_fontCharcoalRaw, 16);
            FontGeneva = new Font(_fontGenevaRaw, 16);
            Mouse = Image.FromBitmap(_mouseRaw);
        }
    }
}
