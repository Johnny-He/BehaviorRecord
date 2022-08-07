using System;
using BehaviorRecorder.Enums;

namespace BehaviorRecorder.Models
{
    public class BehaviorWithInterval
    {
        public BehaviorAction BehaviorAction { get; set; }
        public TimeSpan Interval { get; set; }
        public Point Points { get; set; }
        public char PressKey { get; set; }
    }
}