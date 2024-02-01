#pragma warning disable CA1416

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
            Resources.Generate();
            ProcessScheduler.AddProcess(WindowManager.Instance);
            ProcessScheduler.AddProcess(new HelloWorld());
        }

        protected override void Run()
        {
            ProcessScheduler.HandleRun();
        }
    }
}
