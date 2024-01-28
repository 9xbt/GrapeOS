﻿using Cosmos.System;
using Cosmos.Core.Memory;
using GrapeOS.Tasking;
using System.Collections.Generic;
using GrapeGL.Hardware.GPU;
using GrapeGL.Graphics;

namespace GrapeOS.Graphics
{
    internal sealed class WindowManager : Process
    {
        private int _framesToHeapCollect = 10;

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

        internal override void HandleRun()
        {
            Screen.Clear(new Color(0xFFB3B3DA));

            Screen.DrawString(10, 10, "GrapeOS v0.0.1", Resources.Charcoal, Color.White, Shadow: true);
            Screen.DrawString(10, 36, "Note: this is still very WIP", Resources.Charcoal, Color.White, Shadow: true);
            Screen.DrawString(10, 62, Screen.GetFPS() + " FPS", Resources.Charcoal, Color.White, Shadow: true);

            foreach (Window w in Windows)
            {
                if (w == null)
                {
                    RemoveWindow(w);
                    continue;
                }

                Screen.DrawImage(w.X, w.Y, w.Contents, false);
                Screen.DrawLine(w.X + 2, w.Y + w.Height, w.X + w.Width + 1, w.Y + w.Height, Color.Black);
                Screen.DrawLine(w.X + w.Width, w.Y + 2, w.X + w.Width, w.Y + w.Height + 1, Color.Black);
            }

            Screen.Update();
            Screen.SetCursor(MouseManager.X, MouseManager.Y, true); // TODO: make the mouse also support software for use with VBE

            if (_framesToHeapCollect <= 0)
            {
                Heap.Collect();
                _framesToHeapCollect = 10;
            }

            _framesToHeapCollect--;
        }
    }
}
