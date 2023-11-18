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
            this.lblEvento = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // numberDisplay
            // 
            this.numberDisplay.AutoSize = true;
            this.numberDisplay.CausesValidation = false;
            this.numberDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.numberDisplay.Location = new System.Drawing.Point(7, 3);
            this.numberDisplay.Name = "numberDisplay";
            this.numberDisplay.Size = new System.Drawing.Size(55, 39);
            this.numberDisplay.TabIndex = 0;
            this.numberDisplay.Text = "00";
            this.numberDisplay.MouseLeave += new System.EventHandler(this.numberDisplay_MouseLeave);
            this.numberDisplay.MouseHover += new System.EventHandler(this.numberDisplay_MouseHover);
            this.numberDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.numberDisplay_MouseMove);
            // 
            // lblEvento
            // 
            this.lblEvento.AutoSize = true;
            this.lblEvento.Location = new System.Drawing.Point(11, 52);
            this.lblEvento.Name = "lblEvento";
            this.lblEvento.Size = new System.Drawing.Size(49, 16);
            this.lblEvento.TabIndex = 1;
            this.lblEvento.Text = "Evento";
            // 
            // CalendarDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblEvento);
            this.Controls.Add(this.numberDisplay);
            this.Name = "CalendarDay";
            this.Size = new System.Drawing.Size(69, 79);
            this.Load += new System.EventHandler(this.CalendarDay_Load);
            this.Click += new System.EventHandler(this.CalendarDay_Click);
            this.MouseLeave += new System.EventHandler(this.CalendarDay_MouseLeave);
            this.MouseHover += new System.EventHandler(this.CalendarDay_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CalendarDay_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numberDisplay;
        private System.Windows.Forms.Label lblEvento;
    }
}
