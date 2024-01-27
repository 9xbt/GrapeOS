using Cosmos.System;
using Cosmos.Core.Memory;
using GrapeOS.Tasking;
using GrapeGL.Hardware.GPU;
using GrapeGL.Graphics;

namespace GrapeOS.Graphics
{
    internal class WindowManager : Process
    {
        private int _framesToHeapCollect = 10;

        internal Display Screen = Display.GetDisplay(1024, 768);

        internal WindowManager() : base(nameof(WindowManager))
        {
            MouseManager.ScreenWidth = Screen.Width;
            MouseManager.ScreenHeight = Screen.Height;
        }

        internal void Render()
        {
            Screen.Clear(Color.CoolGreen);
            
            Screen.DrawString(10, 10, "GrapeOS v0.0.1", Resources.Charcoal, Color.White, false, true);
            Screen.DrawString(20, 49, Screen.GetFPS() + " FPS", Resources.Charcoal, Color.White, false, true);

            Screen.DrawImage((int)MouseManager.X, (int)MouseManager.Y, Resources.Mouse);

            Screen.Update();
        }

        internal override void HandleRun()
        {
            Render();

            if (_framesToHeapCollect <= 0)
            {
                Heap.Collect();
                _framesToHeapCollect = 10;
            }

            _framesToHeapCollect--;
        }
    }
}
