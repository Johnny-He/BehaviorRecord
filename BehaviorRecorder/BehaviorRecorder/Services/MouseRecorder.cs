using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using BehaviorRecorder.Enums;
using BehaviorRecorder.Models;

namespace BehaviorRecorder.Services
{
    public class MouseRecorder
    {
        private bool _recordFlag;
        private List<Point> _cursorHistory = new List<Point>();

        private BehaviorRecord _behaviorRecord = new BehaviorRecord()
        {
            BehaviorWithTimeSpans = new List<BehaviorWithTimeSpan>()
        };

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        // [DllImport("user32.dll")]
        // public static extern int GetKeyboardState(byte[] keystate);
        //
        // [DllImport("user32.dll")]
        // public static extern int SetKeyboardState(byte[] keystate);
        //
        // [DllImport("user32.dll")]
        // static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

        public void Play(BehaviorRecord behaviorRecord)
        {
            foreach (var record in _behaviorRecord.BehaviorWithTimeSpans)
            {
                Thread.Sleep(record.Intervals);
                SetCursorPos(record.Points.X, record.Points.Y);
            }
        }

        public void Record()
        {
            _recordFlag = true;
            var prev_pos = new Point
            {
                X = 0,
                Y = 0
            };
            Point current_pos;
            stopwatch.Start();
            var stopwatch = new Stopwatch();
            var lastTimeSpan = new TimeSpan();
            
            while (_recordFlag)
            {
                if (GetCursorPos(out current_pos))
                {
                    if ((current_pos.X != prev_pos.X) || (current_pos.Y != prev_pos.Y))
                    {
                        _cursorHistory.Add(current_pos);
                        var stopwatchElapsed = stopwatch.Elapsed;
                        _behaviorRecord.BehaviorWithTimeSpans.Add(new BehaviorWithTimeSpan
                        {
                            BehaviorAction = BehaviorAction.MouseMove,
                            Intervals = stopwatchElapsed - lastTimeSpan,
                            Points = current_pos
                        });
                        lastTimeSpan = stopwatchElapsed;
                    }

                    prev_pos.X = current_pos.X;
                    prev_pos.Y = current_pos.Y;
                }
            }
        }

        public BehaviorRecord PrintRecord()
        {
            return _behaviorRecord;
        }

        public void StopRecord()
        {
            _recordFlag = false;
        }
    }
}