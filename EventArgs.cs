﻿using System;

namespace ODL
{
    public class TimeEventArgs : EventArgs
    {
        public TimeSpan Duration { get; }

        public TimeEventArgs(TimeSpan Duration)
        {
            this.Duration = Duration;
        }
    }

    public class ClosingEventArgs : EventArgs
    {
        public Exception Error { get; } = null;
        public bool Cancel { get; } = false;
        public bool CausedByException { get { return this.Error != null; } }

        public ClosingEventArgs() { }

        public ClosingEventArgs(Exception Error)
        {
            this.Error = Error;
        }
    }

    public class ClosedEventArgs : EventArgs
    {
        public Exception Error { get; } = null;
        public bool CausedByException { get { return this.Error != null; } }

        public ClosedEventArgs()
        {

        }

        public ClosedEventArgs(Exception Error)
        {
            this.Error = Error;
        }
    }

    public enum MouseButtons
    {
        Left = 1,
        Middle = 2,
        Right = 4
    }

    public class MouseEventArgs : EventArgs
    {
        public int OldX { get; }
        public int OldY { get; }
        public int X { get; }
        public int Y { get; }
        public bool OldLeftButton { get; }
        public bool LeftButton { get; }
        public bool OldRightButton { get; }
        public bool RightButton { get; }
        public bool OldMiddleButton { get; }
        public bool MiddleButton { get; }
        public int WheelY { get; }

        public MouseEventArgs(int OldX, int OldY, int X, int Y,
                bool OldLeftButton, bool LeftButton,
                bool OldRightButton, bool RightButton,
                bool OldMiddleButton, bool MiddleButton,
                int WheelY = 0)
        {
            this.OldX = OldX;
            this.OldY = OldY;
            this.X = X;
            this.Y = Y;
            this.OldLeftButton = OldLeftButton;
            this.LeftButton = LeftButton;
            this.OldRightButton = OldRightButton;
            this.RightButton = RightButton;
            this.OldMiddleButton = OldMiddleButton;
            this.MiddleButton = MiddleButton;
            this.WheelY = WheelY;
        }

        public bool Over(Sprite s)
        {
            if (s.Bitmap == null) return false;
            if (X >= s.X && X < s.X + s.Bitmap.Width * s.ZoomX &&
                Y >= s.Y && Y < s.Y + s.Bitmap.Height * s.ZoomY)
            {
                return true;
            }
            return false;
        }

        public bool InArea(Rect r)
        {
            return InArea(r.X, r.Y, r.Width, r.Height);
        }

        public bool InArea(Point p, Size s)
        {
            return InArea(p.X, p.Y, s.Width, s.Height);
        }

        public bool InArea(Point p, int Width, int Height)
        {
            return InArea(p.X, p.Y, Width, Height);
        }

        public bool InArea(int X, int Y, Size s)
        {
            return InArea(X, Y, s.Width, s.Height);
        }

        public bool InArea(int X, int Y, int Width, int Height)
        {
            return this.X >= X && this.X < X + Width && this.Y >= Y && this.Y < Y + Height;
        }
    }

    public class FocusEventArgs : EventArgs
    {
        public bool Focus { get; }

        public FocusEventArgs(bool Focus)
        {
            this.Focus = Focus;
        }
    }

    public class TextInputEventArgs : EventArgs
    {
        public string Text { get; }
        public bool Backspace { get; }

        public TextInputEventArgs(string Text, bool Backspace = false)
        {
            this.Text = Text;
            this.Backspace = Backspace;
        }
    }
}
