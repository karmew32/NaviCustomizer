namespace NaviCustomizer
{
    partial class BugReport
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
            this.bugLabel = new System.Windows.Forms.Label();
            this.bugPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // bugLabel
            // 
            this.bugLabel.AutoSize = true;
            this.bugLabel.Location = new System.Drawing.Point(70, 33);
            this.bugLabel.Name = "bugLabel";
            this.bugLabel.Size = new System.Drawing.Size(181, 13);
            this.bugLabel.TabIndex = 0;
            this.bugLabel.Text = "All bugs, if any exist, are listed below.";
            // 
            // bugPanel
            // 
            this.bugPanel.AutoScroll = true;
            this.bugPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.bugPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bugPanel.Location = new System.Drawing.Point(12, 84);
            this.bugPanel.Name = "bugPanel";
            this.bugPanel.Size = new System.Drawing.Size(305, 142);
            this.bugPanel.TabIndex = 1;
            // 
            // BugReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 262);
            this.Controls.Add(this.bugPanel);
            this.Controls.Add(this.bugLabel);
            this.Name = "BugReport";
            this.Text = "Bug Report";
            this.Load += new System.EventHandler(this.BugReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bugLabel;
        private System.Windows.Forms.Panel bugPanel;
    }
}