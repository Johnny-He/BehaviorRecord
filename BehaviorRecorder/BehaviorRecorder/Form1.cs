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
            InitializeComponent();
        }

        private void Record_Click(object sender, System.EventArgs e)
        {
            //todo can't show cursor history immediately
            //Invoke(new Action(test));

            //todo record mouse click event
            //todo stop hot key
            //this.MouseClick += new MouseEventHandler(this);
            Task.Run(() => _behaviorMouseRecorder.Record());
        }

        private void StopRecord_Click(object sender, EventArgs e)
        {
            _behaviorMouseRecorder.StopRecord();
            
            var behaviorRecord = _behaviorMouseRecorder.GetRecord();
            foreach (var record in behaviorRecord.BehaviorWithTimeSpans)
            {
                UserBehaviorLog.Items.Add($"Points X: {record.Points.X}, Y: {record.Points.Y}, occur on = {record.Intervals}");
            }
        }

        private void Play_Click(object sender, EventArgs e)
        {
            _behaviorMouseRecorder.Play(null);
        }
    }
}