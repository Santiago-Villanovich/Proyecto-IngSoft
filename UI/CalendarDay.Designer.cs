namespace UI
{
    partial class CalendarDay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numberDisplay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // numberDisplay
            // 
            this.numberDisplay.AutoSize = true;
            this.numberDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.numberDisplay.Location = new System.Drawing.Point(13, 13);
            this.numberDisplay.Name = "numberDisplay";
            this.numberDisplay.Size = new System.Drawing.Size(44, 31);
            this.numberDisplay.TabIndex = 0;
            this.numberDisplay.Text = "00";
            // 
            // CalendarDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numberDisplay);
            this.Name = "CalendarDay";
            this.Size = new System.Drawing.Size(69, 79);
            this.Load += new System.EventHandler(this.CalendarDay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numberDisplay;
    }
}
