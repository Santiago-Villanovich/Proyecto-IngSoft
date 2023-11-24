namespace UI.UI_Negocio
{
    partial class Org_IniciarEvento
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEventoProximos = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnDescargarPDF = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEventoHoy = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(31, 55);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(511, 235);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblEventoProximos
            // 
            this.lblEventoProximos.AutoSize = true;
            this.lblEventoProximos.Font = new System.Drawing.Font("Lucida Sans Unicode", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventoProximos.Location = new System.Drawing.Point(25, 329);
            this.lblEventoProximos.Name = "lblEventoProximos";
            this.lblEventoProximos.Size = new System.Drawing.Size(255, 34);
            this.lblEventoProximos.TabIndex = 1;
            this.lblEventoProximos.Tag = "81";
            this.lblEventoProximos.Text = "Eventos proximos";
            this.lblEventoProximos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(231)))), ((int)(((byte)(222)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Font = new System.Drawing.Font("Lucida Sans Unicode", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(6, 55);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowLines = false;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.Size = new System.Drawing.Size(486, 707);
            this.treeView1.TabIndex = 3;
            // 
            // btnDescargarPDF
            // 
            this.btnDescargarPDF.Location = new System.Drawing.Point(107, 21);
            this.btnDescargarPDF.Name = "btnDescargarPDF";
            this.btnDescargarPDF.Size = new System.Drawing.Size(283, 28);
            this.btnDescargarPDF.TabIndex = 4;
            this.btnDescargarPDF.Tag = "83";
            this.btnDescargarPDF.Text = "Descargar PDF";
            this.btnDescargarPDF.UseVisualStyleBackColor = true;
            this.btnDescargarPDF.Click += new System.EventHandler(this.btnDescargarPDF_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(31, 366);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(511, 457);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // lblEventoHoy
            // 
            this.lblEventoHoy.AutoSize = true;
            this.lblEventoHoy.Font = new System.Drawing.Font("Lucida Sans Unicode", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventoHoy.Location = new System.Drawing.Point(25, 18);
            this.lblEventoHoy.Name = "lblEventoHoy";
            this.lblEventoHoy.Size = new System.Drawing.Size(238, 34);
            this.lblEventoHoy.TabIndex = 5;
            this.lblEventoHoy.Tag = "82";
            this.lblEventoHoy.Text = "El evento de hoy";
            this.lblEventoHoy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Controls.Add(this.btnDescargarPDF);
            this.groupBox1.Location = new System.Drawing.Point(559, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 768);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // Org_IniciarEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(231)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(1101, 862);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblEventoHoy);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.lblEventoProximos);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Org_IniciarEvento";
            this.Text = "Org_IniciarEvento";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblEventoProximos;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnDescargarPDF;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblEventoHoy;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}