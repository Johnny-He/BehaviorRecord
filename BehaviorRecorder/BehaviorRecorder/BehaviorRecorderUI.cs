using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BehaviorRecorder.Models;
using BehaviorRecorder.Services;

namespace BehaviorRecorder
{
    public partial class BehaviorRecorderUi : Form
    {
        private readonly Services.BehaviorRecorder _behaviorRecorder;
        private readonly BehaviorPlayer _behaviorPlayer;
        private BehaviorRecord _behaviorRecord;

        public BehaviorRecorderUi(Services.BehaviorRecorder behaviorRecorder, BehaviorPlayer behaviorPlayer)
        {
            _behaviorRecorder = behaviorRecorder;
            _behaviorPlayer = behaviorPlayer;
            KeyPreview = true;
            KeyDown += TriggerRecorderEvent;

            InitializeComponent();
            RecordNameInput.GotFocus += RemovePlaceHolder;
            RecordNameInput.LostFocus += AddPlaceHolder;
        }

        private void StartRecord_Click(object sender, System.EventArgs e)
        {
            //todo can't show cursor history immediately
            //Invoke(new Action(test));

            PrintLog("Record Start !!");
            Task.Run(() => { _behaviorRecorder.StartRecord(); });
        }

        private void StopRecord_Click(object sender, EventArgs e)
        {
            _behaviorRecord = _behaviorRecorder.StopRecord();
            foreach (var record in _behaviorRecord.BehaviorWithTimeSpans)
            {
                PrintLog(
                    $"Points X: {record.Points.X}, Y: {record.Points.Y}, action = {record.BehaviorAction.ToString()}, occur on = {record.Interval}");
            }

            SaveRecordPupop.Visible = true;
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
            _behaviorPlayer.Play(RecordHistory.SelectedItem.ToString());
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
            if (!string.IsNullOrEmpty(RecordNameInput.Text))
            {
                _behaviorRecord.Name = RecordNameInput.Text;
                _behaviorRecorder.SaveRecord(_behaviorRecord);
            }

            SaveRecordPupop.Visible = false;
            ReloadRecordHistory();
        }

        private void ReloadRecordHistory()
        {
            RecordHistory.Items.Clear();
            var recordHistory = _behaviorRecorder.GetRecordHistory();
            foreach (var record in recordHistory)
            {
                RecordHistory.Items.Add(record);
            }
        }

        private void RemovePlaceHolder(object sender, EventArgs e)
        {
            if (RecordNameInput.Text == "Record name")
            {
                RecordNameInput.Text = "";
            }
        }

        private void AddPlaceHolder(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RecordNameInput.Text))
            {
                RecordNameInput.Text = "Record name";
            }
        }
    }
}