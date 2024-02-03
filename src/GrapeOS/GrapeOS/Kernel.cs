using System;
using Sys = Cosmos.System;
using GrapeOS.Tasking;
using GrapeOS.Graphics;
using GrapeOS.Graphics.Apps;
using GrapeGL.Graphics;

namespace GrapeOS
{
    public sealed class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.Write("Welcome to ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Grape OS");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("!");

            Resources.Generate(ResourceType.Priority);

            ProcessScheduler.AddProcess(WindowManager.Instance);
            LoadingDialogue.Instance = (LoadingDialogue)ProcessScheduler.AddProcess(new LoadingDialogue());
            ProcessScheduler.HandleRun();

            Resources.Generate(ResourceType.Normal);

            LoadingDialogue.Instance.Dispose();

            ProcessScheduler.AddProcess(new HelloWorld());
        }

        protected override void Run()
        {
            ProcessScheduler.HandleRun();
        }
    }
}
