using Sys = Cosmos.System;
using GrapeOS.Tasking;
using GrapeOS.Graphics;

namespace GrapeOS
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            WindowManager.Initialize();
            ProcessScheduler.AddProcess(new Process(nameof(WindowManager), WindowManager.Render));
        }

        protected override void Run()
        {
            ProcessScheduler.HandleRun();
        }
    }
}
