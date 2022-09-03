using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using BehaviorRecorder.Enums;
using BehaviorRecorder.Helpers;
using BehaviorRecorder.Models;
using BehaviorRecorder.Repositories;
using Gma.System.MouseKeyHook;

namespace BehaviorRecorder.Services
{
    public class BehaviorRecorder
    {
        private bool _isRecording;

        private readonly BehaviorRecord _behaviorRecord = new BehaviorRecord()
        {
            BehaviorWithTimeSpans = new List<BehaviorWithInterval>()
        };

        private readonly Stopwatch _stopwatch;
        private TimeSpan _lastTimeSpan;
        private readonly IKeyboardMouseEvents _globalHook;
        private readonly BehaviorRecorderRepository _behaviorRecorderRepository;


        public BehaviorRecorder()
        {
            _globalHook = Hook.GlobalEvents();
            //todo when stop record, need to cancel global hook
            //todo shouldn't in constructor
             _globalHook.MouseClick += RecordMouseClickEvent;
             _globalHook.KeyPress += RecordKeyPressEvent;
            _stopwatch = new Stopwatch();
            _lastTimeSpan = new TimeSpan();
            _behaviorRecorderRepository = new BehaviorRecorderRepository();
        }


        public void StartRecord()
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
                        _behaviorRecord.BehaviorWithTimeSpans.Add(new BehaviorWithInterval
                        {
                            BehaviorAction = BehaviorAction.MouseMove,
                            Interval = stopwatchElapsed - _lastTimeSpan,
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
                _behaviorRecord.BehaviorWithTimeSpans.Add(new BehaviorWithInterval
                {
                    BehaviorAction = BehaviorAction.KeyPress,
                    Interval = _stopwatch.Elapsed - _lastTimeSpan,
                    PressKey = e.KeyChar,
                });
            }
         
        }

        private void RecordMouseClickEvent(object sender, MouseEventArgs e)
        {
            if (_isRecording && WindowsBehaviorHelper.GetCursorPos(out var point))
            {
                _behaviorRecord.BehaviorWithTimeSpans.Add(new BehaviorWithInterval
                {
                    BehaviorAction = BehaviorAction.MouseClick,
                    Interval = _stopwatch.Elapsed - _lastTimeSpan,
                    Points = new Point
                    {
                        X = point.X,
                        Y = point.Y
                    }
                });
            }
        }

        public string[] GetRecordHistory()
        {
            return _behaviorRecorderRepository.GetAllRecord().Select(record => record.Name).ToArray();
        }

        public BehaviorRecord StopRecord()
        {
            _stopwatch.Stop();
            _isRecording = false;
            return _behaviorRecord;
        }

        public void SaveRecord(BehaviorRecord behaviorRecord)
        {
            _behaviorRecorderRepository.SaveRecord(behaviorRecord);
        }

        public void DiscardRecord()
        {
            _behaviorRecord.BehaviorWithTimeSpans.Clear();
        }
    }
}