using Sys = Cosmos.System;
using GrapeOS.Tasking;
using GrapeOS.Graphics;
using GrapeOS.Graphics.Apps;

namespace GrapeOS
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Resources.Generate();
            ProcessScheduler.AddProcess(WindowManager.Instance);
            ProcessScheduler.AddProcess(new Test());
        }

        protected override void Run()
        {
            ProcessScheduler.HandleRun();
        }
    }
}
