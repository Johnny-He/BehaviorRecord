using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using BehaviorRecorder.Enums;
using BehaviorRecorder.Helpers;
using BehaviorRecorder.Models;
using Gma.System.MouseKeyHook;

namespace BehaviorRecorder.Services
{
    public class MouseRecorder
    {
        private bool _isRecording;

        private readonly BehaviorRecord _behaviorRecord = new BehaviorRecord()
        {
            BehaviorWithTimeSpans = new List<BehaviorWithTimeSpan>()
        };

        private readonly Stopwatch _stopwatch;
        private TimeSpan _lastTimeSpan;
        private readonly IKeyboardMouseEvents _globalHook;


        public MouseRecorder()
        {
            _globalHook = Hook.GlobalEvents();
            //shouldn't in constructor
            _globalHook.MouseClick += RecordMouseClickEvent;
            // _globalHook.KeyPress += RecordKeyPressEvent;
            _stopwatch = new Stopwatch();
            _lastTimeSpan = new TimeSpan();
        }

     

        public void Play(BehaviorRecord behaviorRecord)
        {
            foreach (var record in _behaviorRecord.BehaviorWithTimeSpans.ToList())
            {
                Thread.Sleep(record.Intervals);
                switch (record.BehaviorAction)
                {
                    case BehaviorAction.MouseMove:
                        WindowsBehaviorHelper.SetCursorPos(record.Points.X, record.Points.Y);
                        break;
                    case BehaviorAction.MouseClick:
                        WindowsBehaviorHelper.LeftMouseClick(record.Points.X, record.Points.Y);
                        break;
                    case BehaviorAction.KeyPress:
                        
                        
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void Record()
        {
            _isRecording = true;
            var prev_pos = new Point
            {
                X = 0,
                Y = 0
            };
            Point current_pos;

            _stopwatch.Start();
            while (_isRecording)
            {
                if (WindowsBehaviorHelper.GetCursorPos(out current_pos))
                {
                    if ((current_pos.X != prev_pos.X) || (current_pos.Y != prev_pos.Y))
                    {
                        var stopwatchElapsed = _stopwatch.Elapsed;
                        _behaviorRecord.BehaviorWithTimeSpans.Add(new BehaviorWithTimeSpan
                        {
                            BehaviorAction = BehaviorAction.MouseMove,
                            Intervals = stopwatchElapsed - _lastTimeSpan,
                            Points = current_pos
                        });
                        _lastTimeSpan = stopwatchElapsed;
                    }

                    prev_pos.X = current_pos.X;
                    prev_pos.Y = current_pos.Y;
                }
            }
        }
        
        private void RecordKeyPressEvent(object sender, KeyPressEventArgs e)
        {
            if (_isRecording)
            {
                _behaviorRecord.BehaviorWithTimeSpans.Add(new BehaviorWithTimeSpan
                {
                    BehaviorAction = BehaviorAction.KeyPress,
                    Intervals = _stopwatch.Elapsed - _lastTimeSpan,
                    PressKey = e.KeyChar,
                });
            }
         
        }

        private void RecordMouseClickEvent(object sender, MouseEventArgs e)
        {
            if (_isRecording && WindowsBehaviorHelper.GetCursorPos(out var point))
            {
                _behaviorRecord.BehaviorWithTimeSpans.Add(new BehaviorWithTimeSpan
                {
                    BehaviorAction = BehaviorAction.MouseClick,
                    Intervals = _stopwatch.Elapsed - _lastTimeSpan,
                    Points = new Point
                    {
                        X = point.X,
                        Y = point.Y
                    }
                });
            }
        }

        public BehaviorRecord GetRecord()
        {
            return _behaviorRecord;
        }

        public void StopRecord()
        {
            _stopwatch.Stop();
            _isRecording = false;
        }
    }
}