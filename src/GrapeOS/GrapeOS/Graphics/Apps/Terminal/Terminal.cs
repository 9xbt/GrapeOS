using GrapeOS.Graphics.Controls;
using GrapeGL.Graphics;
using System.Reflection.Metadata;
using GrapeOS.Tasking;
using Cosmos.System;

namespace GrapeOS.Graphics.Apps.Terminal
{
    using System;
    using SVGAIITerminal;

    internal sealed class Terminal : Window
    {
        private bool _reading;

        internal SVGAIITerminal terminal;

        private Shell _shell;

        internal Terminal(Shell shell = null) : base(420, 150, 300, 200, "Terminal")        {
            terminal = new SVGAIITerminal(this.Width - 12, this.Height - 29, Resources.Fragment, UpdateRequest, IdleRequest);
            terminal.SetCursorPosition(0, 0);

            if (shell == null) shell = new GShell(terminal);
            
            _shell = shell;
        }

        private void IdleRequest() {
            ProcessScheduler.HandleRun();

            if (KeyboardManager.TryReadKey(out var key)) terminal.KeyBuffer.Enqueue(key);
        }

        private void UpdateRequest() {
            Contents.DrawImage(6, 22, terminal.Contents, false);

            WindowManager.Render();
        }

        internal override void HandleRun()
        {
            base.HandleRun();

            _shell?.Run();
        }
    }
}