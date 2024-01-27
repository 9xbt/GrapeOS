using Sys = Cosmos.System;
using GrapeOS.Tasking;
using GrapeOS.Graphics;

namespace GrapeOS
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Resources.Generate();
            ProcessScheduler.AddProcess(new WindowManager());
        }

        protected override void Run()
        {
            ProcessScheduler.HandleRun();
        }
    }
}
