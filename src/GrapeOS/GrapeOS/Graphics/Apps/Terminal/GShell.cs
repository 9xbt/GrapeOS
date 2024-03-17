using GrapeOS.Graphics.Controls;
using GrapeGL.Graphics;
using SVGAIITerminal;
using System.Reflection.Metadata;

namespace GrapeOS.Graphics.Apps.Terminal
{
    using System;
    using System.IO;
    using GrapeOS.Tasking;
    using SVGAIITerminal;

    internal sealed class GShell : Shell
    {   
        private bool _reading = false;

        private string _virtualDir = @"0:\";

        public GShell(SVGAIITerminal Terminal) : base(Terminal) { }

        internal override void Run()
        {
            if (!_reading) {
                _reading = true;

                _terminal.Write("# ");

                string[] args = _terminal.ReadLine().Trim().Split(' ');

                switch (args[0].ToLower()) {
                    case "clear":
                        _terminal.Clear();
                        break;
                    case "ping":
                        _terminal.WriteLine("Ping!");
                        break;
                }

                _reading = false;
            }
        }
    }
}