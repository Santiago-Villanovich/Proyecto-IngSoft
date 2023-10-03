namespace UI.UI_Sistema
{
    partial class FormCrearOrg
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDireccionweb = new System.Windows.Forms.TextBox();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkboxPileta = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rb25mts = new System.Windows.Forms.RadioButton();
            this.rb20mts = new System.Windows.Forms.RadioButton();
            this.txtPiletaDir = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numupPiletaCarril = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb50mts = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numupPiletaCarril)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Direccion web";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cuit";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(25, 61);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(195, 22);
            this.txtNombre.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(259, 61);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(195, 22);
            this.txtEmail.TabIndex = 5;
            // 
            // txtDireccionweb
            // 
            this.txtDireccionweb.Location = new System.Drawing.Point(25, 139);
            this.txtDireccionweb.Name = "txtDireccionweb";
            this.txtDireccionweb.Size = new System.Drawing.Size(195, 22);
            this.txtDireccionweb.TabIndex = 6;
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(259, 139);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(195, 22);
            this.txtCuit.TabIndex = 7;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(489, 304);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(155, 49);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar Organizacion";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(489, 42);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(571, 253);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(905, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 32);
            this.button1.TabIndex = 10;
            this.button1.Text = "Eliminar organizacion";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(744, 301);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(155, 32);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar seleccion";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // checkboxPileta
            // 
            this.checkboxPileta.AutoSize = true;
            this.checkboxPileta.Location = new System.Drawing.Point(25, 205);
            this.checkboxPileta.Name = "checkboxPileta";
            this.checkboxPileta.Size = new System.Drawing.Size(123, 20);
            this.checkboxPileta.TabIndex = 13;
            this.checkboxPileta.Text = "Pileta asociada";
            this.checkboxPileta.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Cantidad de andariveles";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Metros de la pileta";
            // 
            // rb25mts
            // 
            this.rb25mts.AutoSize = true;
            this.rb25mts.Location = new System.Drawing.Point(12, 129);
            this.rb25mts.Name = "rb25mts";
            this.rb25mts.Size = new System.Drawing.Size(66, 20);
            this.rb25mts.TabIndex = 19;
            this.rb25mts.TabStop = true;
            this.rb25mts.Text = "25 mts";
            this.rb25mts.UseVisualStyleBackColor = true;
            // 
            // rb20mts
            // 
            this.rb20mts.AutoSize = true;
            this.rb20mts.Location = new System.Drawing.Point(12, 103);
            this.rb20mts.Name = "rb20mts";
            this.rb20mts.Size = new System.Drawing.Size(66, 20);
            this.rb20mts.TabIndex = 18;
            this.rb20mts.TabStop = true;
            this.rb20mts.Text = "20 mts";
            this.rb20mts.UseVisualStyleBackColor = true;
            // 
            // txtPiletaDir
            // 
            this.txtPiletaDir.Location = new System.Drawing.Point(9, 37);
            this.txtPiletaDir.Name = "txtPiletaDir";
            this.txtPiletaDir.Size = new System.Drawing.Size(183, 22);
            this.txtPiletaDir.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Direccion";
            // 
            // numupPiletaCarril
            // 
            this.numupPiletaCarril.Location = new System.Drawing.Point(213, 37);
            this.numupPiletaCarril.Name = "numupPiletaCarril";
            this.numupPiletaCarril.Size = new System.Drawing.Size(184, 22);
            this.numupPiletaCarril.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb50mts);
            this.groupBox1.Controls.Add(this.numupPiletaCarril);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.rb25mts);
            this.groupBox1.Controls.Add(this.rb20mts);
            this.groupBox1.Controls.Add(this.txtPiletaDir);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(25, 230);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 187);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // rb50mts
            // 
            this.rb50mts.AutoSize = true;
            this.rb50mts.Location = new System.Drawing.Point(12, 155);
            this.rb50mts.Name = "rb50mts";
            this.rb50mts.Size = new System.Drawing.Size(66, 20);
            this.rb50mts.TabIndex = 24;
            this.rb50mts.TabStop = true;
            this.rb50mts.Text = "50 mts";
            this.rb50mts.UseVisualStyleBackColor = true;
            // 
            // FormCrearOrg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 449);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkboxPileta);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.txtDireccionweb);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormCrearOrg";
            this.Text = "FormCrearOrg";
            this.Load += new System.EventHandler(this.FormCrearOrg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numupPiletaCarril)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDireccionweb;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox checkboxPileta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rb25mts;
        private System.Windows.Forms.RadioButton rb20mts;
        private System.Windows.Forms.TextBox txtPiletaDir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb50mts;
        private System.Windows.Forms.NumericUpDown numupPiletaCarril;
    }
}