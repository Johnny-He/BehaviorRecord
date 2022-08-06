
using System.Collections.Generic;
using BehaviorRecorder.Repositories;

namespace BehaviorRecorder
{
    partial class BehaviorRecorderUi
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
            this.button1 = new System.Windows.Forms.Button();
            this.SaveRecord = new System.Windows.Forms.Button();
            this.RecordHistory = new System.Windows.Forms.ListBox();
            this.RecordNameInput = new System.Windows.Forms.TextBox();
            this.SaveRecordPupop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveRecordPupop.SuspendLayout();
            this.SuspendLayout();
            // 
            // Record
            // 
            this.Record.Location = new System.Drawing.Point(296, 31);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(87, 23);
            this.Record.TabIndex = 1;
            this.Record.Text = "Record";
            this.Record.UseVisualStyleBackColor = true;
            this.Record.Click += new System.EventHandler(this.StartRecord_Click);
            // 
            // UserBehaviorLog
            // 
            this.UserBehaviorLog.FormattingEnabled = true;
            this.UserBehaviorLog.ItemHeight = 15;
            this.UserBehaviorLog.Location = new System.Drawing.Point(22, 31);
            this.UserBehaviorLog.Name = "UserBehaviorLog";
            this.UserBehaviorLog.Size = new System.Drawing.Size(268, 199);
            this.UserBehaviorLog.TabIndex = 4;
            // 
            // StopRecord
            // 
            this.StopRecord.Location = new System.Drawing.Point(389, 31);
            this.StopRecord.Name = "StopRecord";
            this.StopRecord.Size = new System.Drawing.Size(120, 23);
            this.StopRecord.TabIndex = 5;
            this.StopRecord.Text = "StopRecord(F4)";
            this.StopRecord.UseVisualStyleBackColor = true;
            this.StopRecord.Click += new System.EventHandler(this.StopRecord_Click);
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(296, 60);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(87, 27);
            this.Play.TabIndex = 6;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(296, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 27);
            this.button1.TabIndex = 7;
            this.button1.Text = "Test click button";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SaveRecord
            // 
            this.SaveRecord.Location = new System.Drawing.Point(135, 18);
            this.SaveRecord.Name = "SaveRecord";
            this.SaveRecord.Size = new System.Drawing.Size(87, 23);
            this.SaveRecord.TabIndex = 8;
            this.SaveRecord.Text = "SaveRecord(F6)";
            this.SaveRecord.UseVisualStyleBackColor = true;
            this.SaveRecord.Click += new System.EventHandler(this.SaveRecord_Click);
            // 
            // RecordHistory
            // 
            this.RecordHistory.FormattingEnabled = true;
            this.RecordHistory.ItemHeight = 15;
            this.RecordHistory.Location = new System.Drawing.Point(516, 31);
            this.RecordHistory.Name = "RecordHistory";
            this.RecordHistory.Size = new System.Drawing.Size(133, 199);
            this.RecordHistory.TabIndex = 9;
            this.RecordHistory.Items.AddRange(new Services.BehaviorRecorder().GetRecordHistory());
            // 
            // RecordNameInput
            // 
            this.RecordNameInput.Location = new System.Drawing.Point(18, 18);
            this.RecordNameInput.Name = "RecordNameInput";
            this.RecordNameInput.Size = new System.Drawing.Size(111, 23);
            this.RecordNameInput.TabIndex = 10;
            this.RecordNameInput.Text = "Record name";
            // 
            // SaveRecordPupop
            // 
            this.SaveRecordPupop.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.SaveRecordPupop.Controls.Add(this.label1);
            this.SaveRecordPupop.Controls.Add(this.RecordNameInput);
            this.SaveRecordPupop.Controls.Add(this.SaveRecord);
            this.SaveRecordPupop.Location = new System.Drawing.Point(241, 82);
            this.SaveRecordPupop.Name = "SaveRecordPupop";
            this.SaveRecordPupop.Size = new System.Drawing.Size(241, 68);
            this.SaveRecordPupop.TabIndex = 11;
            this.SaveRecordPupop.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Save";
            // 
            // BehaviorRecorderUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 276);
            this.Controls.Add(this.SaveRecordPupop);
            this.Controls.Add(this.RecordHistory);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.StopRecord);
            this.Controls.Add(this.UserBehaviorLog);
            this.Controls.Add(this.Record);
            this.Name = "BehaviorRecorderUi";
            this.Text = "Form1";
            this.SaveRecordPupop.ResumeLayout(false);
            this.SaveRecordPupop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Record;
        private System.Windows.Forms.ListBox UserBehaviorLog;
        private System.Windows.Forms.Button StopRecord;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SaveRecord;
        private System.Windows.Forms.ListBox RecordHistory;
        private System.Windows.Forms.TextBox RecordNameInput;
        private System.Windows.Forms.Panel SaveRecordPupop;
        private System.Windows.Forms.Label label1;
    }
}

