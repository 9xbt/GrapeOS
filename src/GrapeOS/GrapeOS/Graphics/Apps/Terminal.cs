using GrapeOS.Graphics.Controls;
using GrapeGL.Graphics;
using SVGAIITerminal;
using SVGAIITerminal.TextKit;
using System.Reflection.Metadata;

namespace GrapeOS.Graphics.Apps
{
    internal sealed class Terminal : Window
    {
        public SVGAIITerminal.SVGAIITerminal terminal;

        internal Terminal() : base(150, 150, 300, 200, "Test Application")
        {
            terminal = new SVGAIITerminal.SVGAIITerminal(this.Width - 12, this.Height - (23 + 6), Resources.SVGAIIGeneva, () => { this.HandleRun(); });
        }

        internal override void HandleRun()
        {
            base.HandleRun();

            Contents.DrawImage(6, 22, terminal.Contents, false);

            WindowManager.Render();
        }
    }
}