using System.Collections.Generic;
using Cosmos.System;
using Cosmos.Core.Memory;
using Cosmos.HAL;
using GrapeOS.Tasking;
using GrapeGL.Hardware.GPU;
using GrapeGL.Graphics;

namespace GrapeOS.Graphics
{
    internal sealed class WindowManager : Process
    {
        private static int _framesToHeapCollect = 20;
        private static byte _lastSecond = RTC.Second;

        internal static List<Window> Windows = new List<Window>();
        internal static Display Screen = Display.GetDisplay(800, 600);

        internal static WindowManager Instance = new WindowManager();

        internal WindowManager() : base(nameof(WindowManager))
        {
            MouseManager.ScreenWidth = Screen.Width;
            MouseManager.ScreenHeight = Screen.Height;
            MouseManager.X = (uint)Screen.Width / 2;
            MouseManager.Y = (uint)Screen.Height / 2;

            Screen.DefineCursor(Resources.Mouse);
        }

        internal static Window FocusedWindow
        {
            get
            {
                if (Windows.Count < 1)
                    return null;

                return Windows[^1];
            }
            set
            {
                Windows.Remove(value);
                Windows.Add(value);
            }
        }

        internal static void AddWindow(Window window)
            => Windows.Add(window);

        internal static bool RemoveWindow(Window window)
            => Windows.Remove(window);

        internal static void Render()
        {
            Screen.Clear(new Color(0xFFB3B3DA));

            Screen.DrawString(10, 10, "GrapeOS v0.0.1", Resources.Charcoal, Color.White, Shadow: true);
            Screen.DrawString(10, 36, Screen.GetFPS() + " FPS", Resources.Charcoal, Color.White, Shadow: true);

            // This generates MASSIVE lag spikes; only use if you really need to debug this sort of stuff
            /*Screen.DrawString(10, 88, "Process list:", Resources.Charcoal, Color.White, Shadow: true);
            for (int i = 0; i < ProcessScheduler.Processes.Count; i++)
                Screen.DrawString(10, 114 + (i * 16), ProcessScheduler.Processes[i].PID + " (" + ProcessScheduler.Processes[i].Name + ")",
                    Resources.Charcoal, Color.White, Shadow: true);

            Screen.DrawString(200, 88, "Window list:", Resources.Charcoal, Color.White, Shadow: true);
            for (int i = 0; i < Windows.Count; i++)
                Screen.DrawString(200, 114 + (i * 16), Windows[i].PID + " (" + Windows[i].Name + ")",
                    Resources.Charcoal, Color.White, Shadow: true);*/

            foreach (Window w in Windows)
            {
                if (w == null)
                {
                    RemoveWindow(w);
                    continue;
                }

                Screen.DrawImage(w.X, w.Y, w.Contents, false);

                if (w.Borderless) continue;

                Screen.DrawLine(w.X + 2, w.Y + w.Height, w.X + w.Width + 1, w.Y + w.Height, Color.Black);
                Screen.DrawLine(w.X + w.Width, w.Y + 2, w.X + w.Width, w.Y + w.Height + 1, Color.Black);
            }

            Screen.Update(false);

            if (_framesToHeapCollect <= 0)
            {
                Heap.Collect();
                _framesToHeapCollect = 20;
            }

            _framesToHeapCollect--;
        }

        internal override void HandleRun()
        {
            if (_lastSecond != RTC.Second)
            {
                Render();
                _lastSecond = RTC.Second;
            }

            // Rendering the mouse technically counts as rendering a frame.
            // Since we don't need to copy the framebuffer for rendering the
            // mouse, just increase the FPS counter by one.
            Screen.SetCursor(MouseManager.X, MouseManager.Y, true);
            Screen._Frames++;
        }
    }
}
