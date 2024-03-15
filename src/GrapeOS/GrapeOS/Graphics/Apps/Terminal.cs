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

        internal Terminal() : base(420, 150, 300, 200, "Terminal")
        {
            terminal = new SVGAIITerminal.SVGAIITerminal(this.Width - 12, this.Height - 29 + 6, Resources.SVGAIIGeneva, () => { this.UpdateRequest(); });
            terminal.SetCursorPosition(0, 0);
        }

        internal void UpdateRequest() {
            
        }

        internal override void HandleRun()
        {
            base.HandleRun();

            terminal.UpdateRequest();

            Contents.DrawImage(6, 22, terminal.Contents, false);

            WindowManager.Render();
        }
    }
}