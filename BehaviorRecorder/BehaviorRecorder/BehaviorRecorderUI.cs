using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BehaviorRecorder.Services;

namespace BehaviorRecorder
{
    public partial class Form1 : Form
    {
        private readonly MouseRecorder _behaviorMouseRecorder;

        public Form1(MouseRecorder behaviorMouseRecorder)
        {
            _behaviorMouseRecorder = behaviorMouseRecorder;
            this.KeyPreview = true;
            this.KeyDown += TriggerRecorderEvent;
            InitializeComponent();
        }

        private void StartRecord_Click(object sender, System.EventArgs e)
        {
            //todo can't show cursor history immediately
            //Invoke(new Action(test));

            PrintLog("Record Start !!");
            Task.Run(() => { _behaviorMouseRecorder.Record(); });
        }

        private void StopRecord_Click(object sender, EventArgs e)
        {
            _behaviorMouseRecorder.StopRecord();

            var behaviorRecord = _behaviorMouseRecorder.GetRecord();
            foreach (var record in behaviorRecord.BehaviorWithTimeSpans)
            {
                PrintLog(
                    $"Points X: {record.Points.X}, Y: {record.Points.Y}, action = {record.BehaviorAction.ToString()}, occur on = {record.Intervals}");
            }

            PrintLog($"Record Stop !!");
            //This selects and highlights the last line
        }


        private void TriggerRecorderEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "F5":
                    Play_Click(sender, e);
                    break;
                case "F4":
                    StopRecord_Click(sender, e);
                    break;
                case "F3":
                    StartRecord_Click(sender, e);
                    break;
            }
        }

        private void Play_Click(object sender, EventArgs e)
        {
            _behaviorMouseRecorder.Play(null);
            PrintLog("Playing Recorder !!");
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
    }
}