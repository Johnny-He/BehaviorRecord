using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BehaviorRecorder.Models;
using BehaviorRecorder.Services;

namespace BehaviorRecorder
{
    public partial class BehaviorRecorderUi : Form
    {
        private readonly MouseRecorder _behaviorRecorder;
        private BehaviorRecord _behaviorRecord;

        public BehaviorRecorderUi(MouseRecorder behaviorRecorder)
        {
            _behaviorRecorder = behaviorRecorder;
            this.KeyPreview = true;
            this.KeyDown += TriggerRecorderEvent;
            InitializeComponent();
        }

        private void StartRecord_Click(object sender, System.EventArgs e)
        {
            //todo can't show cursor history immediately
            //Invoke(new Action(test));

            PrintLog("Record Start !!");
            Task.Run(() => { _behaviorRecorder.Record(); });
        }

        private void StopRecord_Click(object sender, EventArgs e)
        {
            _behaviorRecord = _behaviorRecorder.StopRecord();
            foreach (var record in _behaviorRecord.BehaviorWithTimeSpans)
            {
                PrintLog(
                    $"Points X: {record.Points.X}, Y: {record.Points.Y}, action = {record.BehaviorAction.ToString()}, occur on = {record.Interval}");
            }

            PrintLog($"Record Stop !!");
        }


        private void TriggerRecorderEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "F3":
                    StartRecord_Click(sender, e);
                    break;
                case "F4":
                    StopRecord_Click(sender, e);
                    break;
                case "F5":
                    Play_Click(sender, e);
                    break;
                case "F6":
                    SaveRecord_Click(sender, e);
                    break;
            }
        }

        private void Play_Click(object sender, EventArgs e)
        {
            PrintLog("Playing Recorder Start !!");
            _behaviorRecorder.Play(null);
            PrintLog("Playing Recorder End !!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintLog("This button is clicked");
        }

        private void PrintLog(string message)
        {
            UserBehaviorLog.Items.Add(message);
            UserBehaviorLog.SetSelected(UserBehaviorLog.Items.Count - 1, true);
        }

        private void SaveRecord_Click(object sender, EventArgs e)
        {
            var formPopup = new SaveRecordPopup(_behaviorRecorder, _behaviorRecord);
            formPopup.Show(this); // if you need non-modal window
        }
    }
}