using System;

namespace GrapeOS {
    using SVGAIITerminal;

    internal abstract class Shell {
        internal SVGAIITerminal _terminal;

        internal Shell(SVGAIITerminal Terminal) {
            _terminal = Terminal;
        }

        internal abstract void Run();
    }
}