using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BehaviorRecorder.Models;

namespace BehaviorRecorder.Services
{
    public class MouseRecorder
    {
        private bool _recordFlag;
        private List<Point> _cursorHistory = new List<Point>();

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern int GetKeyboardState(byte[] keystate);

        [DllImport("user32.dll")]
        public static extern int SetKeyboardState(byte[] keystate);

        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);
        public void Play(BehaviorRecord behaviorRecord)
        {
            foreach (Point point in _cursorHistory)
            {
                SetCursorPos(point.X, point.Y);
                System.Threading.Thread.Sleep(10);
            }
        }

        public void Record()
        {
            _recordFlag = true;
            Point prev_pos;
            Point current_pos;

            prev_pos.X = 0;
            prev_pos.Y = 0;

            while (_recordFlag)
            {
                if (GetCursorPos(out current_pos))
                {

                    if ((current_pos.X != prev_pos.X) || (current_pos.Y != prev_pos.Y))
                    {
                        _cursorHistory.Add(current_pos);
                    }

                    prev_pos.X = current_pos.X;
                    prev_pos.Y = current_pos.Y;
                }
            }
        }

        public List<Point> PrintRecord()
        {
            return _cursorHistory;
        }

        public void StopRecord()
        {
            _recordFlag = false;
            foreach (var point in _cursorHistory)
            {
                // UserBehaviorLog.Items.Add($"Test X: {point.X}, Y: {point.Y}");
            }
        }
    }

    public class BehaviorRecord
    {
        public List<BehaviorWithTimeSpan> BehaviorWithTimeSpans { get; set; }
    }

    public class BehaviorWithTimeSpan
    {
        public string Action { get; set; }
        public DateTime Time { get; set; }
    }
}