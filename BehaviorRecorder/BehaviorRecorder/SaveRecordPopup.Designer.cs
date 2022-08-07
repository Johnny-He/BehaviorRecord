namespace BehaviorRecorder
{
    partial class SaveRecordPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SaveBehaviorRecord = new System.Windows.Forms.Button();
            this.RecordName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SaveBehaviorRecord
            // 
            this.SaveBehaviorRecord.Location = new System.Drawing.Point(130, 12);
            this.SaveBehaviorRecord.Name = "SaveBehaviorRecord";
            this.SaveBehaviorRecord.Size = new System.Drawing.Size(86, 23);
            this.SaveBehaviorRecord.TabIndex = 0;
            this.SaveBehaviorRecord.Text = "SaveRecord";
            this.SaveBehaviorRecord.UseMnemonic = false;
            this.SaveBehaviorRecord.UseVisualStyleBackColor = true;
            this.SaveBehaviorRecord.Click += new System.EventHandler(this.SaveBehaviorRecord_Click);
            // 
            // RecordName
            // 
            this.RecordName.Location = new System.Drawing.Point(12, 12);
            this.RecordName.Name = "RecordName";
            this.RecordName.Size = new System.Drawing.Size(112, 23);
            this.RecordName.TabIndex = 1;
            this.RecordName.Text = "Record name";
            this.RecordName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SaveRecordPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 58);
            this.Controls.Add(this.RecordName);
            this.Controls.Add(this.SaveBehaviorRecord);
            this.Name = "SaveRecordPopup";
            this.Text = "SaveRecordPopup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveBehaviorRecord;
        private System.Windows.Forms.TextBox RecordName;
    }
}