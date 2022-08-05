using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using BehaviorRecorder.Enums;
using BehaviorRecorder.Helpers;
using BehaviorRecorder.Models;

namespace BehaviorRecorder.Services
{
    public class MouseRecorder
    {
        private bool _recordFlag;

        private readonly BehaviorRecord _behaviorRecord = new BehaviorRecord()
        {
            BehaviorWithTimeSpans = new List<BehaviorWithTimeSpan>()
        };
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public void Play(BehaviorRecord behaviorRecord)
        {
            foreach (var record in _behaviorRecord.BehaviorWithTimeSpans)
            {
                Thread.Sleep(record.Intervals);
                WindowsBehaviorHelper.SetCursorPos(record.Points.X, record.Points.Y);
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
            var lastTimeSpan = new TimeSpan();
            
            _stopwatch.Start();
            while (_recordFlag)
            {
                if (WindowsBehaviorHelper.GetCursorPos(out current_pos))
                {
                    if ((current_pos.X != prev_pos.X) || (current_pos.Y != prev_pos.Y))
                    {
                        var stopwatchElapsed = _stopwatch.Elapsed;
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

        public BehaviorRecord GetRecord()
        {
            return _behaviorRecord;
        }

        public void StopRecord()
        {
            _recordFlag = false;
        }
    }
}