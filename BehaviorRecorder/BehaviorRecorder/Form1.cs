using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BehaviorRecorder.Services;

namespace BehaviorRecorder
{
    
    public partial class Form1 : Form
    {
        public MouseRecorder BehaviorMouseRecorder = new MouseRecorder();
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Record_Click(object sender, System.EventArgs e)
        {
            //todo can't show cursor history immediately
            //Invoke(new Action(test));

            //todo record mouse click event
            //todo stop hot key
            //this.MouseClick += new MouseEventHandler(this);
            Task.Run(() => BehaviorMouseRecorder.Record());
        }

        private void StopRecord_Click(object sender, EventArgs e)
        {
            BehaviorMouseRecorder.StopRecord();
            //todo GetRecord from Repo 
            var printRecord = BehaviorMouseRecorder.PrintRecord();

            foreach (var point in printRecord)
            {
                UserBehaviorLog.Items.Add($"Test X: {point.X}, Y: {point.Y}");
            }
        }

        private void Play_Click(object sender, EventArgs e)
        {
            BehaviorMouseRecorder.Play(null);
        }
    }
}

