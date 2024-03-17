using GrapeOS.Graphics.Controls;
using GrapeGL.Graphics;
using System.Reflection.Metadata;
using GrapeOS.Tasking;
using Cosmos.System;

namespace GrapeOS.Graphics.Apps.Terminal
{
    using SVGAIITerminal;

    internal sealed class Terminal : Window
    {
        private bool _reading;

        private SVGAIITerminal _terminal;

        internal Terminal() : base(420, 150, 300, 200, "Terminal")
        {
            _terminal = new SVGAIITerminal(this.Width - 12, this.Height - 29, Resources.Fragment, UpdateRequest, IdleRequest);
            _terminal.SetCursorPosition(0, 0);
        }

        private void IdleRequest() {
            ProcessScheduler.HandleRun();

            if (KeyboardManager.TryReadKey(out var key)) _terminal.KeyBuffer.Enqueue(key);
        }

        private void UpdateRequest() {
            Contents.DrawImage(6, 22, _terminal.Contents, false);

            WindowManager.Render();
        }

        internal override void HandleRun()  //abcdefg
        {
            base.HandleRun();

            if (Focused && !_reading) {
                _reading = true;

                _terminal.Write("# ");

                var input = _terminal.ReadLine();
                
                Shell.Run(input, _terminal);

                _reading = false;
            }
        }
    }
}