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
            Resources.Generate(ResourceType.Priority);
            ProcessScheduler.AddProcess(WindowManager.Instance);
            ProcessScheduler.AddProcess(new LoadingDialogue());
        }

        protected override void Run()
        {
            ProcessScheduler.HandleRun();
        }
    }
}
