using System;
using System.Windows.Forms;
using BehaviorRecorder.Models;
using BehaviorRecorder.Services;

namespace BehaviorRecorder
{
    public partial class SaveRecordPopup : Form
    {
        private readonly MouseRecorder _behaviorMouseRecorder;
        private readonly BehaviorRecord _behaviorRecord;

        public SaveRecordPopup(MouseRecorder behaviorMouseRecorder, BehaviorRecord behaviorRecord)
        {
            _behaviorMouseRecorder = behaviorMouseRecorder;
            _behaviorRecord = behaviorRecord;
            InitializeComponent();
            RecordName.GotFocus += RemovePlaceHolder;
            RecordName.LostFocus += AddPlaceHolder;
        }

        private void AddPlaceHolder(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RecordName.Text))
            {
                RecordName.Text = "Record name";
            }
        }

        private void RemovePlaceHolder(object sender, EventArgs e)
        {
            if (RecordName.Text == "Record name")
            {
                RecordName.Text = "";
            }
        }

        private void SaveBehaviorRecord_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(RecordName.Text))
            {
                _behaviorRecord.Name = RecordName.Text;
                _behaviorMouseRecorder.SaveRecord(_behaviorRecord);
                Close();
            }
        }
    }
}