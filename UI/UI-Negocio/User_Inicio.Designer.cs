namespace UI.UI_Negocio
{
    partial class User_Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_Inicio));
            this.DaysContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDomingo = new System.Windows.Forms.Label();
            this.btnAnteriorMes = new System.Windows.Forms.Button();
            this.btnSiguienteMes = new System.Windows.Forms.Button();
            this.lblMesNow = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gboxEventoHoy = new System.Windows.Forms.GroupBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.gboxEventoHoy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DaysContainer
            // 
            this.DaysContainer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.DaysContainer.Location = new System.Drawing.Point(55, 128);
            this.DaysContainer.Name = "DaysContainer";
            this.DaysContainer.Size = new System.Drawing.Size(523, 519);
            this.DaysContainer.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(452, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Sabado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(381, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Viernes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Jueves";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Miercoles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Martes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Lunes";
            // 
            // lblDomingo
            // 
            this.lblDomingo.AutoSize = true;
            this.lblDomingo.Location = new System.Drawing.Point(11, 68);
            this.lblDomingo.Name = "lblDomingo";
            this.lblDomingo.Size = new System.Drawing.Size(62, 16);
            this.lblDomingo.TabIndex = 8;
            this.lblDomingo.Text = "Domingo";
            // 
            // btnAnteriorMes
            // 
            this.btnAnteriorMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnteriorMes.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAnteriorMes.Location = new System.Drawing.Point(353, 5);
            this.btnAnteriorMes.Name = "btnAnteriorMes";
            this.btnAnteriorMes.Size = new System.Drawing.Size(82, 40);
            this.btnAnteriorMes.TabIndex = 16;
            this.btnAnteriorMes.Text = "▲";
            this.btnAnteriorMes.UseVisualStyleBackColor = true;
            this.btnAnteriorMes.Click += new System.EventHandler(this.btnAnteriorMes_Click);
            // 
            // btnSiguienteMes
            // 
            this.btnSiguienteMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguienteMes.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSiguienteMes.Location = new System.Drawing.Point(441, 5);
            this.btnSiguienteMes.Name = "btnSiguienteMes";
            this.btnSiguienteMes.Size = new System.Drawing.Size(76, 40);
            this.btnSiguienteMes.TabIndex = 15;
            this.btnSiguienteMes.Text = "▼";
            this.btnSiguienteMes.UseVisualStyleBackColor = true;
            this.btnSiguienteMes.Click += new System.EventHandler(this.btnSiguienteMes_Click);
            // 
            // lblMesNow
            // 
            this.lblMesNow.AutoSize = true;
            this.lblMesNow.Font = new System.Drawing.Font("Lucida Sans Unicode", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesNow.Location = new System.Drawing.Point(23, 17);
            this.lblMesNow.Name = "lblMesNow";
            this.lblMesNow.Size = new System.Drawing.Size(60, 28);
            this.lblMesNow.TabIndex = 17;
            this.lblMesNow.Text = "Mes";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMesNow);
            this.panel1.Controls.Add(this.btnAnteriorMes);
            this.panel1.Controls.Add(this.lblDomingo);
            this.panel1.Controls.Add(this.btnSiguienteMes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(55, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 96);
            this.panel1.TabIndex = 19;
            // 
            // gboxEventoHoy
            // 
            this.gboxEventoHoy.Controls.Add(this.lblTitulo);
            this.gboxEventoHoy.Controls.Add(this.pictureBox1);
            this.gboxEventoHoy.Location = new System.Drawing.Point(584, 27);
            this.gboxEventoHoy.Name = "gboxEventoHoy";
            this.gboxEventoHoy.Size = new System.Drawing.Size(421, 620);
            this.gboxEventoHoy.TabIndex = 20;
            this.gboxEventoHoy.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Lucida Sans Unicode", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(1, 17);
            this.lblTitulo.MaximumSize = new System.Drawing.Size(420, 0);
            this.lblTitulo.MinimumSize = new System.Drawing.Size(420, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(420, 28);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Titulo Evento";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(409, 321);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // User_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(231)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(1131, 669);
            this.Controls.Add(this.gboxEventoHoy);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DaysContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "User_Inicio";
            this.Text = "User_Inicio";
            this.Load += new System.EventHandler(this.User_Inicio_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gboxEventoHoy.ResumeLayout(false);
            this.gboxEventoHoy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel DaysContainer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDomingo;
        private System.Windows.Forms.Button btnAnteriorMes;
        private System.Windows.Forms.Button btnSiguienteMes;
        private System.Windows.Forms.Label lblMesNow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gboxEventoHoy;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}