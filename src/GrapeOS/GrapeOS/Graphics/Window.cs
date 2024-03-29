﻿using System.Collections.Generic;
using Cosmos.System;
using GrapeOS.Tasking;
using GrapeGL.Graphics;
using System.Reflection.Metadata.Ecma335;

namespace GrapeOS.Graphics
{
    internal class Window : Process
    {
        private int _originalX, _originalY;
        private ushort _originalWidth, _originalHeight;

        private int _dragStartX, _dragStartY, _dragStartMouseX, _dragStartMouseY;
        private bool _dragging = false;

        internal string Title;
        internal int X, Y;
        internal ushort Width, Height;
        internal bool Borderless;
        internal bool Maximized = false;
        internal bool Minimized = false;

        internal Canvas Contents;
        internal List<Control> Controls;

        internal bool Focused
        {
            get => WindowManager.FocusedWindow == this;
        }

        internal bool isMouseOverArea {
           get => MouseManager.X > X && MouseManager.X < X + Width && MouseManager.Y > Y && MouseManager.Y < Y + Height;
        } 

        internal bool IsMouseOver() // Empty comments!
        {
            WindowManager.WindowOrder.Reverse();
            bool toReturn = true;

            int location = WindowManager.WindowOrder.IndexOf(this);

            if (location + 1 == WindowManager.WindowOrder.Count) {
                WindowManager.WindowOrder.Reverse();
                return isMouseOverArea;
            } 

            // Loop through higher windows and check if mouse is over any of them along with ours
            for (int i = location + 1; i < WindowManager.WindowOrder.Count; i++) 
                // If the mouse is not over a higher window, true.
                toReturn = toReturn && !WindowManager.WindowOrder[i].isMouseOverArea && isMouseOverArea;

            WindowManager.WindowOrder.Reverse();
            return toReturn;
        }

        internal bool IsMouseOverTitlebar
        {
            get => MouseManager.X > X && MouseManager.X < X + Width && MouseManager.Y > Y && MouseManager.Y < Y + 22 && IsMouseOver();
        }

        internal bool IsMouseOverCloseButton
        {
            get => MouseManager.X > X + 4 && MouseManager.X < X + 17 && MouseManager.Y > Y + 4 && MouseManager.Y < Y + 17 && IsMouseOver();
        }

        internal bool IsMouseOverMaximizeButton
        {
            get => MouseManager.X > X + Width - 33 && MouseManager.X < X + Width - 20 && MouseManager.Y > Y + 4 && MouseManager.Y < Y + 17 && IsMouseOver();
        }

        internal bool IsMouseOverMinimizeButton
        {
            get => MouseManager.X > X + Width - 17 && MouseManager.X < X + Width - 4 && MouseManager.Y > Y + 4 && MouseManager.Y < Y + 17 && IsMouseOver();
        }

        protected Window(int X, int Y, ushort Width, ushort Height, string Title) : base(Title)
        {
            this.Title = Title;
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;

            Contents = new Canvas(Width, Height);
            Controls = new List<Control>();
            Render();

            WindowManager.AddWindow(this);
        }

        internal virtual void Render()
        {
            // Clear the window
            Contents.Clear(new Color(0xFFDADADA));

            // Render the window border
            Contents.DrawRectangle(0, 0, Width, Height, 0, Color.Black);
            Contents.DrawLine(1, 1, Width - 2, 1, Color.White);
            Contents.DrawLine(1, 1, 1, Height - 2, Color.White);
            Contents.DrawLine(2, Height - 2, Width - 1, Height - 2, new Color(Borderless ? 0xFFC0C0C0 : 0xFFB3B3B3));
            Contents.DrawLine(Width - 2, 2, Width - 2, Height - 2, new Color(Borderless ? 0xFFC0C0C0 : 0xFFB3B3B3));

            if (Borderless)
            {
                // Render the window corners
                Contents[Width - 2, 1] = new Color(0xFFF3F3F3);
                Contents[1, Height - 2] = new Color(0xFFF3F3F3);

                // Render the controls
                RenderControls();

                // Update the WM
                WindowManager.Render();
                return;
            }

            // Render the title bar
            RenderTitlebarButtons();

            for (int i = 0; i < 6; i++) Contents.DrawLine(21, 4 + i * 2, Width - 38, 4 + i * 2, Color.White);
            for (int i = 0; i < 6; i++) Contents.DrawLine(22, 5 + i * 2, Width - 37, 5 + i * 2, new Color(0xFF969696));

            Contents.DrawFilledRectangle((Width / 2) - (Resources.Charcoal.MeasureString(Title + " ") / 2) - 1,
                4, (ushort)(Resources.Charcoal.MeasureString(Title + " ") + 2), 12, 0, new Color(0xFFDADADA));
            Contents.DrawString((Width / 2) - (Resources.Charcoal.MeasureString(Title) / 2) - 1,
                2, Title, Resources.Charcoal, Color.Black);

            for (int i = 0; i < 6; i++) Contents[(Width / 2) + (Resources.Charcoal.MeasureString(Title + " ") / 2),
                4 + i * 2] = Color.White;
            for (int i = 0; i < 6; i++) Contents[(Width / 2) - (Resources.Charcoal.MeasureString(Title + " ") / 2) - 1,
                5 + i * 2] = new Color(0xFF969696);

            if (Minimized)
            {
                WindowManager.Render();
                return;
            }

            // Render window contents area
            Contents.DrawLine(4, 20, Width - 6, 20, new Color(0xFFB3B3B3));
            Contents.DrawLine(4, 20, 4, Height - 6, new Color(0xFFB3B3B3));
            Contents.DrawLine(4, Height - 6, Width - 5, Height - 6, Color.White);
            Contents.DrawLine(Width - 5, 21, Width - 5, Height - 6, Color.White);
            Contents.DrawRectangle(5, 21, (ushort)(Width - 10), (ushort)(Height - 27), 0, Color.Black);
            Contents.DrawFilledRectangle(6, 22, (ushort)(Width - 12), (ushort)(Height - 29), 0, new Color(0xFFE7E7E7));

            // Render the controls
            RenderControls();

            // Update the WM
            WindowManager.Render();
        }

        internal void RenderControls()
        {
            foreach (Control c in Controls)
            {
                if (c == null) Controls.Remove(c);
                else Contents.DrawImage(c.X + (Borderless ? 2 : 6), c.Y + (Borderless ? 2 : 22), c.Contents, c.RenderWithAlpha);
            }
        }

        private void RenderTitlebarButtons()
        {
            Contents.DrawImage(4, 4, IsMouseOverCloseButton && MouseManager.MouseState == MouseState.Left ? Resources.CloseButtonPressed : Resources.CloseButton);
            Contents.DrawImage(Width - 33, 4, IsMouseOverMaximizeButton && MouseManager.MouseState == MouseState.Left ? Resources.MaximizeButtonPressed : Resources.MaximizeButton);
            Contents.DrawImage(Width - 17, 4, IsMouseOverMinimizeButton && MouseManager.MouseState == MouseState.Left ? Resources.MinimizeButtonPressed : Resources.MinimizeButton);

            WindowManager.Render();
        }
        internal override void HandleRun()
        {
            // Handle titlebar buttons
            if (!Borderless && MouseManager.LastMouseState != MouseManager.MouseState)
                RenderTitlebarButtons();

            if (!Borderless && IsMouseOverCloseButton &&
                MouseManager.LastMouseState == MouseState.Left &&
                MouseManager.MouseState == MouseState.None)
            {
                Dispose();
            }
            else if (!Borderless && IsMouseOverMaximizeButton &&
                MouseManager.LastMouseState == MouseState.Left &&
                MouseManager.MouseState == MouseState.None)
            {
                if (Minimized)
                    Height = _originalHeight;

                Maximized = !Maximized;
                Minimized = false;

                // Do the resizing
                if (Maximized)
                {
                    _originalX = X;
                    _originalY = Y;
                    _originalWidth = Width;
                    _originalHeight = Height;

                    X = 0;
                    Y = 0;
                    Width = WindowManager.Screen.Width;
                    Height = WindowManager.Screen.Height;
                }
                else
                {
                    X = _originalX;
                    Y = _originalY;
                    Width = _originalWidth;
                    Height = _originalHeight;
                }

                Contents.Dispose();
                Contents = new Canvas(Width, Height);
                Render();
            }
            else if (!Borderless && IsMouseOverMinimizeButton &&
                MouseManager.LastMouseState == MouseState.Left &&
                MouseManager.MouseState == MouseState.None)
            {
                Minimized = !Minimized;
                Maximized = false;

                if (Minimized)
                    _originalHeight = Height;

                Height = Minimized ? (ushort)22 : _originalHeight;

                Contents.Dispose();
                Contents = new Canvas(Width, Height);
                Render();
            }

            if (Focused) {

                // Handle dragging
                if (!Borderless && IsMouseOverTitlebar && !IsMouseOverCloseButton && // TODO: fix the commented part
                    !IsMouseOverMaximizeButton && !IsMouseOverMinimizeButton &&
                    MouseManager.LastMouseState == MouseState.None &&
                    MouseManager.MouseState == MouseState.Left)
                {
                    _dragStartX = X;
                    _dragStartY = Y;
                    _dragStartMouseX = (int)MouseManager.X;
                    _dragStartMouseY = (int)MouseManager.Y;
                    _dragging = true;
                }

                if (_dragging && MouseManager.MouseState == MouseState.None)
                    _dragging = false;

                if (_dragging)
                {
                    X = (int)(_dragStartX + (MouseManager.X - _dragStartMouseX));
                    Y = (int)(_dragStartY + (MouseManager.Y - _dragStartMouseY));

                    WindowManager.Render();
                }
            }
            else if (MouseManager.LastMouseState != MouseManager.MouseState && IsMouseOver()) WindowManager.FocusedWindow = this;

            // Handle the controls
            foreach (Control c in Controls)
            {
                if (c == null) Controls.Remove(c);
                else c.HandleRun();
            }
        }
    }
}
