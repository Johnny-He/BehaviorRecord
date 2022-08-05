
namespace BehaviorRecorder
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Record = new System.Windows.Forms.Button();
            this.UserBehaviorLog = new System.Windows.Forms.ListBox();
            this.StopRecord = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Record
            // 
            this.Record.Location = new System.Drawing.Point(411, 41);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(75, 23);
            this.Record.TabIndex = 1;
            this.Record.Text = "Record";
            this.Record.UseVisualStyleBackColor = true;
            this.Record.Click += new System.EventHandler(this.Record_Click);
            // 
            // UserBehaviorLog
            // 
            this.UserBehaviorLog.FormattingEnabled = true;
            this.UserBehaviorLog.ItemHeight = 15;
            this.UserBehaviorLog.Location = new System.Drawing.Point(22, 31);
            this.UserBehaviorLog.Name = "UserBehaviorLog";
            this.UserBehaviorLog.Size = new System.Drawing.Size(383, 319);
            this.UserBehaviorLog.TabIndex = 4;
            // 
            // StopRecord
            // 
            this.StopRecord.Location = new System.Drawing.Point(411, 97);
            this.StopRecord.Name = "StopRecord";
            this.StopRecord.Size = new System.Drawing.Size(122, 23);
            this.StopRecord.TabIndex = 5;
            this.StopRecord.Text = "StopRecord(F4)";
            this.StopRecord.UseVisualStyleBackColor = true;
            this.StopRecord.Click += new System.EventHandler(this.StopRecord_Click);
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(412, 163);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(121, 27);
            this.Play.TabIndex = 6;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.StopRecord);
            this.Controls.Add(this.UserBehaviorLog);
            this.Controls.Add(this.Record);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Record;
        private System.Windows.Forms.ListBox UserBehaviorLog;
        private System.Windows.Forms.Button StopRecord;
        private System.Windows.Forms.Button Play;
    }
}

