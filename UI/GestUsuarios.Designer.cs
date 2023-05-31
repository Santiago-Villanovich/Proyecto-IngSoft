﻿namespace UI
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
            this.checkAdmin = new System.Windows.Forms.CheckBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
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
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(41, 190);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 1;
            this.labelNombre.Tag = "7";
            this.labelNombre.Text = "Nombre";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(41, 230);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(44, 13);
            this.labelApellido.TabIndex = 2;
            this.labelApellido.Tag = "8";
            this.labelApellido.Text = "Apellido";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(459, 231);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(172, 23);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Tag = "18";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnDarPermisos
            // 
            this.btnDarPermisos.Location = new System.Drawing.Point(459, 181);
            this.btnDarPermisos.Name = "btnDarPermisos";
            this.btnDarPermisos.Size = new System.Drawing.Size(83, 38);
            this.btnDarPermisos.TabIndex = 4;
            this.btnDarPermisos.Tag = "16";
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
            this.btnSacarPermisos.Tag = "17";
            this.btnSacarPermisos.Text = "Quitar permisos";
            this.btnSacarPermisos.UseVisualStyleBackColor = true;
            this.btnSacarPermisos.Click += new System.EventHandler(this.btnSacarPermisos_Click);
            // 
            // labelDni
            // 
            this.labelDni.AutoSize = true;
            this.labelDni.Location = new System.Drawing.Point(243, 190);
            this.labelDni.Name = "labelDni";
            this.labelDni.Size = new System.Drawing.Size(23, 13);
            this.labelDni.TabIndex = 6;
            this.labelDni.Tag = "2";
            this.labelDni.Text = "Dni";
            // 
            // labelAdmin
            // 
            this.labelAdmin.AutoSize = true;
            this.labelAdmin.Location = new System.Drawing.Point(243, 230);
            this.labelAdmin.Name = "labelAdmin";
            this.labelAdmin.Size = new System.Drawing.Size(36, 13);
            this.labelAdmin.TabIndex = 7;
            this.labelAdmin.Tag = "15";
            this.labelAdmin.Text = "Admin";
            // 
            // checkAdmin
            // 
            this.checkAdmin.AutoSize = true;
            this.checkAdmin.Location = new System.Drawing.Point(285, 231);
            this.checkAdmin.Name = "checkAdmin";
            this.checkAdmin.Size = new System.Drawing.Size(15, 14);
            this.checkAdmin.TabIndex = 8;
            this.checkAdmin.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(91, 183);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(132, 20);
            this.txtNombre.TabIndex = 9;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(91, 223);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(132, 20);
            this.txtApellido.TabIndex = 10;
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(272, 183);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(132, 20);
            this.txtDNI.TabIndex = 11;
            // 
            // GestUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 400);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.checkAdmin);
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
        private System.Windows.Forms.CheckBox checkAdmin;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDNI;
    }
}