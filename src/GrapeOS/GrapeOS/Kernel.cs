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
            try
            {
                Resources.Generate();
                ProcessScheduler.AddProcess(WindowManager.Instance);
                ProcessScheduler.AddProcess(new HelloWorld());
            }
            catch (Exception ex)
            {
                WindowManager.Instance.Screen.Clear(Color.Red);
                WindowManager.Instance.Screen.DrawString(10, 10, "An error occurred: " +
                    ex.Message,Resources.Charcoal, Color.White, Shadow: true);
            }
        }

        protected override void Run()
        {
            try
            {
                ProcessScheduler.HandleRun();
            }
            catch (Exception ex)
            {
                WindowManager.Instance.Screen.Clear(Color.Red);
                WindowManager.Instance.Screen.DrawString(10, 10, "An error occurred: " +
                    ex.Message, Resources.Charcoal, Color.White, Shadow: true);
            }
        }
    }
}
