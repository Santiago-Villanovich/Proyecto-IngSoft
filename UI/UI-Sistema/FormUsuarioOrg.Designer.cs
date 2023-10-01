namespace UI.UI_Sistema
{
    partial class FormUsuarioOrg
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
            this.dtgridUsuarios = new System.Windows.Forms.DataGridView();
            this.dtgridOrg = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblOrg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridOrg)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgridUsuarios
            // 
            this.dtgridUsuarios.AllowUserToAddRows = false;
            this.dtgridUsuarios.AllowUserToDeleteRows = false;
            this.dtgridUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridUsuarios.Location = new System.Drawing.Point(12, 12);
            this.dtgridUsuarios.MultiSelect = false;
            this.dtgridUsuarios.Name = "dtgridUsuarios";
            this.dtgridUsuarios.ReadOnly = true;
            this.dtgridUsuarios.RowHeadersWidth = 51;
            this.dtgridUsuarios.RowTemplate.Height = 24;
            this.dtgridUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgridUsuarios.Size = new System.Drawing.Size(573, 253);
            this.dtgridUsuarios.TabIndex = 0;
            this.dtgridUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgridUsuarios_CellClick);
            // 
            // dtgridOrg
            // 
            this.dtgridOrg.AllowUserToAddRows = false;
            this.dtgridOrg.AllowUserToDeleteRows = false;
            this.dtgridOrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridOrg.Location = new System.Drawing.Point(591, 12);
            this.dtgridOrg.MultiSelect = false;
            this.dtgridOrg.Name = "dtgridOrg";
            this.dtgridOrg.ReadOnly = true;
            this.dtgridOrg.RowHeadersWidth = 51;
            this.dtgridOrg.RowTemplate.Height = 24;
            this.dtgridOrg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgridOrg.Size = new System.Drawing.Size(424, 253);
            this.dtgridOrg.TabIndex = 1;
            this.dtgridOrg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgridOrg_CellClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(591, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 70);
            this.button1.TabIndex = 2;
            this.button1.Text = "Asociar usuario";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Apellido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Organizacion";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = ":";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(367, 292);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(16, 16);
            this.lblUsuario.TabIndex = 7;
            this.lblUsuario.Text = "A";
            // 
            // lblOrg
            // 
            this.lblOrg.AutoSize = true;
            this.lblOrg.Location = new System.Drawing.Point(367, 346);
            this.lblOrg.Name = "lblOrg";
            this.lblOrg.Size = new System.Drawing.Size(16, 16);
            this.lblOrg.TabIndex = 8;
            this.lblOrg.Text = "A";
            // 
            // FormUsuarioOrg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 415);
            this.Controls.Add(this.lblOrg);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtgridOrg);
            this.Controls.Add(this.dtgridUsuarios);
            this.Name = "FormUsuarioOrg";
            this.Text = "FormUsuarioOrg";
            this.Load += new System.EventHandler(this.FormUsuarioOrg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgridUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridOrg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgridUsuarios;
        private System.Windows.Forms.DataGridView dtgridOrg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblOrg;
    }
}