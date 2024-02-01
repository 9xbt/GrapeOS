using System;
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
        private int _framesToHeapCollect = 20;
        private byte _lastSecond = RTC.Second;

        internal List<Window> Windows = new List<Window>();
        internal Display Screen = Display.GetDisplay(1024, 768);

        internal static WindowManager Instance = new WindowManager();

        internal WindowManager() : base(nameof(WindowManager))
        {
            MouseManager.ScreenWidth = Screen.Width;
            MouseManager.ScreenHeight = Screen.Height;

            Screen.DefineCursor(Resources.Mouse);
        }

        internal Window FocusedWindow
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

        internal void AddWindow(Window window)
            => Windows.Add(window);

        internal void RemoveWindow(Window window)
            => Windows.Remove(window);

        internal void Render()
        {
            Screen.Clear(new Color(0xFFB3B3DA));

            Screen.DrawString(10, 10, "GrapeOS v0.0.1", Resources.Charcoal, Color.White, Shadow: true);
            Screen.DrawString(10, 36, Screen.GetFPS() + " FPS", Resources.Charcoal, Color.White, Shadow: true);

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
