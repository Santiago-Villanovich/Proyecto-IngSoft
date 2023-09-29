namespace UI.UI_Negocio
{
    partial class Org_NuevoEvento
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkElementos = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.richtextDetalleEvento = new System.Windows.Forms.RichTextBox();
            this.numupCoste = new System.Windows.Forms.NumericUpDown();
            this.cboxPileta = new System.Windows.Forms.ComboBox();
            this.cboxEstilo = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lblRegistrarPileta = new System.Windows.Forms.Label();
            this.numupEdadMin = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.lblNombreCat = new System.Windows.Forms.Label();
            this.numupEdadMax = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.btnAgregarCat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDeshacerCat = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.listboxCategorias = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numupCoste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numupEdadMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numupEdadMax)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha del Evento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripcion del evento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Coste de Inscripcion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Seleccionar Pileta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Estilo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(377, 50);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(244, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "Detalles especificos (Opcional)";
            // 
            // checkElementos
            // 
            this.checkElementos.AutoSize = true;
            this.checkElementos.Location = new System.Drawing.Point(28, 223);
            this.checkElementos.Name = "checkElementos";
            this.checkElementos.Size = new System.Drawing.Size(198, 27);
            this.checkElementos.TabIndex = 8;
            this.checkElementos.Text = "Se utilizan elementos";
            this.checkElementos.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(43, 81);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(230, 22);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // richtextDetalleEvento
            // 
            this.richtextDetalleEvento.Location = new System.Drawing.Point(43, 154);
            this.richtextDetalleEvento.Name = "richtextDetalleEvento";
            this.richtextDetalleEvento.Size = new System.Drawing.Size(230, 96);
            this.richtextDetalleEvento.TabIndex = 10;
            this.richtextDetalleEvento.Text = "";
            // 
            // numupCoste
            // 
            this.numupCoste.DecimalPlaces = 2;
            this.numupCoste.Location = new System.Drawing.Point(74, 326);
            this.numupCoste.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numupCoste.Name = "numupCoste";
            this.numupCoste.Size = new System.Drawing.Size(199, 28);
            this.numupCoste.TabIndex = 11;
            this.numupCoste.ThousandsSeparator = true;
            // 
            // cboxPileta
            // 
            this.cboxPileta.FormattingEnabled = true;
            this.cboxPileta.Location = new System.Drawing.Point(30, 79);
            this.cboxPileta.Name = "cboxPileta";
            this.cboxPileta.Size = new System.Drawing.Size(320, 31);
            this.cboxPileta.TabIndex = 12;
            // 
            // cboxEstilo
            // 
            this.cboxEstilo.FormattingEnabled = true;
            this.cboxEstilo.Location = new System.Drawing.Point(28, 155);
            this.cboxEstilo.Name = "cboxEstilo";
            this.cboxEstilo.Size = new System.Drawing.Size(320, 31);
            this.cboxEstilo.TabIndex = 13;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(380, 78);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(336, 172);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            // 
            // lblRegistrarPileta
            // 
            this.lblRegistrarPileta.AutoSize = true;
            this.lblRegistrarPileta.Location = new System.Drawing.Point(222, 50);
            this.lblRegistrarPileta.Name = "lblRegistrarPileta";
            this.lblRegistrarPileta.Size = new System.Drawing.Size(128, 23);
            this.lblRegistrarPileta.TabIndex = 15;
            this.lblRegistrarPileta.Text = "Registrar pileta";
            // 
            // numupEdadMin
            // 
            this.numupEdadMin.Location = new System.Drawing.Point(97, 86);
            this.numupEdadMin.Maximum = new decimal(new int[] {
            110,
            0,
            0,
            0});
            this.numupEdadMin.Name = "numupEdadMin";
            this.numupEdadMin.Size = new System.Drawing.Size(74, 28);
            this.numupEdadMin.TabIndex = 17;
            this.numupEdadMin.ValueChanged += new System.EventHandler(this.numupEdadMin_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(26, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 22);
            this.label10.TabIndex = 18;
            this.label10.Text = "Categoria: ";
            // 
            // lblNombreCat
            // 
            this.lblNombreCat.AutoSize = true;
            this.lblNombreCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCat.Location = new System.Drawing.Point(126, 42);
            this.lblNombreCat.Name = "lblNombreCat";
            this.lblNombreCat.Size = new System.Drawing.Size(22, 22);
            this.lblNombreCat.TabIndex = 19;
            this.lblNombreCat.Text = "A";
            // 
            // numupEdadMax
            // 
            this.numupEdadMax.Location = new System.Drawing.Point(228, 86);
            this.numupEdadMax.Maximum = new decimal(new int[] {
            110,
            0,
            0,
            0});
            this.numupEdadMax.Name = "numupEdadMax";
            this.numupEdadMax.Size = new System.Drawing.Size(74, 28);
            this.numupEdadMax.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 23);
            this.label12.TabIndex = 22;
            this.label12.Text = "Entre";
            // 
            // btnAgregarCat
            // 
            this.btnAgregarCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.btnAgregarCat.Location = new System.Drawing.Point(146, 149);
            this.btnAgregarCat.Name = "btnAgregarCat";
            this.btnAgregarCat.Size = new System.Drawing.Size(156, 57);
            this.btnAgregarCat.TabIndex = 23;
            this.btnAgregarCat.Text = "Agregar categoria";
            this.btnAgregarCat.UseVisualStyleBackColor = true;
            this.btnAgregarCat.Click += new System.EventHandler(this.btnAgregarCat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnDeshacerCat);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.listboxCategorias);
            this.groupBox1.Controls.Add(this.btnAgregarCat);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.numupEdadMax);
            this.groupBox1.Controls.Add(this.lblNombreCat);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.numupEdadMin);
            this.groupBox1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.8F);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(231)))), ((int)(((byte)(222)))));
            this.groupBox1.Location = new System.Drawing.Point(365, 328);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(747, 244);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Defina las Categorias";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "y";
            // 
            // btnDeshacerCat
            // 
            this.btnDeshacerCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.btnDeshacerCat.Location = new System.Drawing.Point(29, 149);
            this.btnDeshacerCat.Name = "btnDeshacerCat";
            this.btnDeshacerCat.Size = new System.Drawing.Size(110, 57);
            this.btnDeshacerCat.TabIndex = 26;
            this.btnDeshacerCat.Text = "Deshacer";
            this.btnDeshacerCat.UseVisualStyleBackColor = true;
            this.btnDeshacerCat.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(505, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 23);
            this.label9.TabIndex = 25;
            // 
            // listboxCategorias
            // 
            this.listboxCategorias.FormattingEnabled = true;
            this.listboxCategorias.ItemHeight = 23;
            this.listboxCategorias.Location = new System.Drawing.Point(381, 42);
            this.listboxCategorias.Name = "listboxCategorias";
            this.listboxCategorias.Size = new System.Drawing.Size(336, 165);
            this.listboxCategorias.TabIndex = 24;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.groupBox2.Controls.Add(this.lblRegistrarPileta);
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Controls.Add(this.cboxEstilo);
            this.groupBox2.Controls.Add(this.cboxPileta);
            this.groupBox2.Controls.Add(this.checkElementos);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.8F);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(231)))), ((int)(((byte)(222)))));
            this.groupBox2.Location = new System.Drawing.Point(365, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(747, 283);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informacion Natacion";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.numupCoste);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.dateTimePicker1);
            this.groupBox3.Controls.Add(this.richtextDetalleEvento);
            this.groupBox3.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(231)))), ((int)(((byte)(222)))));
            this.groupBox3.Location = new System.Drawing.Point(10, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(349, 547);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Informacion General";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "$";
            // 
            // Org_NuevoEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(231)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(1124, 648);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Org_NuevoEvento";
            this.Text = "Org_NuevoEvento";
            this.Load += new System.EventHandler(this.Org_NuevoEvento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numupCoste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numupEdadMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numupEdadMax)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkElementos;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RichTextBox richtextDetalleEvento;
        private System.Windows.Forms.NumericUpDown numupCoste;
        private System.Windows.Forms.ComboBox cboxPileta;
        private System.Windows.Forms.ComboBox cboxEstilo;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lblRegistrarPileta;
        private System.Windows.Forms.NumericUpDown numupEdadMin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblNombreCat;
        private System.Windows.Forms.NumericUpDown numupEdadMax;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAgregarCat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeshacerCat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox listboxCategorias;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
    }
}