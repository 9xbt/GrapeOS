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
        }

        internal static void Render()
        {
            Screen.Clear(Color.CoolGreen);

            Screen.DrawString(11, 11, "GrapeOS v0.0.1", default, Color.Black);
            Screen.DrawString(10, 10, "GrapeOS v0.0.1", default, Color.White);

            Screen.DrawString(11, 41, Screen.GetFPS() + " FPS", default, Color.Black);
            Screen.DrawString(10, 40, Screen.GetFPS() + " FPS", default, Color.White);

            Screen.DrawRectangle((int)MouseManager.X, (int)MouseManager.Y, 2, 2, 0, Color.Black);

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
