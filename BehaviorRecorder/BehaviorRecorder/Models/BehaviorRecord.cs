using System.Collections.Generic;

namespace BehaviorRecorder.Models
{
    public class BehaviorRecord
    {
        public string Name{ get; set; }
        public List<BehaviorWithInterval> BehaviorWithTimeSpans { get; set; }
    }
}