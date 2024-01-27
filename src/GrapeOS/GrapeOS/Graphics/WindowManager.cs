using Cosmos.System;
using Cosmos.Core.Memory;
using GrapeGL.Hardware.GPU;
using GrapeGL.Graphics;

namespace GrapeOS.Graphics
{
    internal static class WindowManager
    {
        private static int _framesToHeapCollect = 10;

        internal static Display Screen = Display.GetDisplay(1024, 768);

        internal static void Initialize()
        {
            MouseManager.ScreenWidth = Screen.Width;
            MouseManager.ScreenHeight = Screen.Height;
            Resources.Generate();
        }

        internal static void Render()
        {
            Screen.Clear(Color.CoolGreen); //
            
            Screen.DrawString(10, 10, "GrapeOS v0.0.1", Resources.FontCharcoal, Color.White, false, true);
            
            Screen.DrawString(20, 49, Screen.GetFPS() + "\nFPS", Resources.FontGeneva, Color.White, true, true);

            Screen.DrawImage((int)MouseManager.X, (int)MouseManager.Y, Resources.Mouse);

            Screen.Update();

            if (_framesToHeapCollect <= 0)
            {
                Heap.Collect();
                _framesToHeapCollect = 10;
            }

            _framesToHeapCollect--;
        }

        internal static void HandleRun()
        {
            if (_framesToHeapCollect <= 0)
            {
                Heap.Collect();
                _framesToHeapCollect = 10;
            }

            _framesToHeapCollect--;
        }
    }
}
