using GrapeOS.Graphics.Controls;
using GrapeGL.Graphics;
using SVGAIITerminal;
using System.Reflection.Metadata;

namespace GrapeOS.Graphics.Apps.Terminal
{
    using SVGAIITerminal;

    internal static class Shell
    {
        public static void Run(string Input, SVGAIITerminal Terminal) {
            string[] args = Input.Trim().Split(' ');

            switch (args[0].ToLower()) {
                case "clear":
                    Terminal.Clear();
                    break;
                case "ping":
                    Terminal.WriteLine("Pong!");
                    break;
            }
        }
    }
}