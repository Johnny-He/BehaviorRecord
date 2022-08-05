using System;
using BehaviorRecorder.Enums;

namespace BehaviorRecorder.Models
{
    public class BehaviorWithTimeSpan
    {
        public BehaviorAction BehaviorAction { get; set; }
        public TimeSpan Time { get; set; }
    }
}