namespace UI
{
    partial class GestUsuarios
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnDarPermisos = new System.Windows.Forms.Button();
            this.btnSacarPermisos = new System.Windows.Forms.Button();
            this.labelDni = new System.Windows.Forms.Label();
            this.labelAdmin = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(44, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(587, 115);
            this.dataGridView1.TabIndex = 0;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(66, 194);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 1;
            this.labelNombre.Text = "Nombre";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(66, 231);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(44, 13);
            this.labelApellido.TabIndex = 2;
            this.labelApellido.Text = "Apellido";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(459, 231);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(172, 23);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnDarPermisos
            // 
            this.btnDarPermisos.Location = new System.Drawing.Point(459, 181);
            this.btnDarPermisos.Name = "btnDarPermisos";
            this.btnDarPermisos.Size = new System.Drawing.Size(83, 38);
            this.btnDarPermisos.TabIndex = 4;
            this.btnDarPermisos.Text = "Dar permisos";
            this.btnDarPermisos.UseVisualStyleBackColor = true;
            this.btnDarPermisos.Click += new System.EventHandler(this.btnDarPermisos_Click);
            // 
            // btnSacarPermisos
            // 
            this.btnSacarPermisos.Location = new System.Drawing.Point(548, 181);
            this.btnSacarPermisos.Name = "btnSacarPermisos";
            this.btnSacarPermisos.Size = new System.Drawing.Size(83, 38);
            this.btnSacarPermisos.TabIndex = 5;
            this.btnSacarPermisos.Text = "Quitar permisos";
            this.btnSacarPermisos.UseVisualStyleBackColor = true;
            this.btnSacarPermisos.Click += new System.EventHandler(this.btnSacarPermisos_Click);
            // 
            // labelDni
            // 
            this.labelDni.AutoSize = true;
            this.labelDni.Location = new System.Drawing.Point(230, 194);
            this.labelDni.Name = "labelDni";
            this.labelDni.Size = new System.Drawing.Size(23, 13);
            this.labelDni.TabIndex = 6;
            this.labelDni.Text = "Dni";
            // 
            // labelAdmin
            // 
            this.labelAdmin.AutoSize = true;
            this.labelAdmin.Location = new System.Drawing.Point(230, 231);
            this.labelAdmin.Name = "labelAdmin";
            this.labelAdmin.Size = new System.Drawing.Size(36, 13);
            this.labelAdmin.TabIndex = 7;
            this.labelAdmin.Text = "Admin";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(272, 230);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // GestUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 400);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.labelAdmin);
            this.Controls.Add(this.labelDni);
            this.Controls.Add(this.btnSacarPermisos);
            this.Controls.Add(this.btnDarPermisos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GestUsuarios";
            this.Text = "GestUsuarios";
            this.Load += new System.EventHandler(this.GestUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnDarPermisos;
        private System.Windows.Forms.Button btnSacarPermisos;
        private System.Windows.Forms.Label labelDni;
        private System.Windows.Forms.Label labelAdmin;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}