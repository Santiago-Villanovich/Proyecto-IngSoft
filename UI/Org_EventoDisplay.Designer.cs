namespace UI
{
    partial class Org_EventoDisplay
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
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblEstilo = new System.Windows.Forms.Label();
            this.lblMetrosTiempo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(132, 169);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(71, 16);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "00/00/0000";
            // 
            // lblEstilo
            // 
            this.lblEstilo.AutoSize = true;
            this.lblEstilo.Location = new System.Drawing.Point(146, 260);
            this.lblEstilo.Name = "lblEstilo";
            this.lblEstilo.Size = new System.Drawing.Size(40, 16);
            this.lblEstilo.TabIndex = 1;
            this.lblEstilo.Text = "Estilo";
            // 
            // lblMetrosTiempo
            // 
            this.lblMetrosTiempo.AutoSize = true;
            this.lblMetrosTiempo.Location = new System.Drawing.Point(132, 219);
            this.lblMetrosTiempo.Name = "lblMetrosTiempo";
            this.lblMetrosTiempo.Size = new System.Drawing.Size(66, 16);
            this.lblMetrosTiempo.TabIndex = 2;
            this.lblMetrosTiempo.Text = "10000 mts";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Contacto";
            // 
            // Org_EventoDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMetrosTiempo);
            this.Controls.Add(this.lblEstilo);
            this.Controls.Add(this.lblFecha);
            this.Name = "Org_EventoDisplay";
            this.Size = new System.Drawing.Size(311, 355);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblEstilo;
        private System.Windows.Forms.Label lblMetrosTiempo;
        private System.Windows.Forms.Label label1;
    }
}
