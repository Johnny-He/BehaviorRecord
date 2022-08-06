using System;
using System.Threading;
using BehaviorRecorder.Enums;
using BehaviorRecorder.Helpers;
using BehaviorRecorder.Repositories;

namespace BehaviorRecorder.Services
{
    public class BehaviorPlayer
    {
        private readonly BehaviorRecorderRepository _behaviorRecorderRepository;

        public BehaviorPlayer()
        {
            _behaviorRecorderRepository = new BehaviorRecorderRepository();
        }

        public void Play(string recordName)
        {
            var recordByName = _behaviorRecorderRepository.GetRecordByName(recordName);
            foreach (var record in recordByName.BehaviorWithTimeSpans)
            {
                Thread.Sleep(record.Interval);
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
    }
}