namespace UI.UI_Negocio
{
    partial class Org_EventoIniciado
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
            this.cboxCategoriaElegir = new System.Windows.Forms.ComboBox();
            this.btnIniciarCategoria = new System.Windows.Forms.Button();
            this.lblNombreEquipo = new System.Windows.Forms.Label();
            this.datagvParticipantes = new System.Windows.Forms.DataGridView();
            this.GuardarEquipo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.datagvEquipos = new System.Windows.Forms.DataGridView();
            this.gboxMetros = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.datagvParticipantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagvEquipos)).BeginInit();
            this.gboxMetros.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Categoria";
            // 
            // cboxCategoriaElegir
            // 
            this.cboxCategoriaElegir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCategoriaElegir.FormattingEnabled = true;
            this.cboxCategoriaElegir.Location = new System.Drawing.Point(32, 51);
            this.cboxCategoriaElegir.Name = "cboxCategoriaElegir";
            this.cboxCategoriaElegir.Size = new System.Drawing.Size(193, 24);
            this.cboxCategoriaElegir.TabIndex = 2;
            // 
            // btnIniciarCategoria
            // 
            this.btnIniciarCategoria.Location = new System.Drawing.Point(32, 81);
            this.btnIniciarCategoria.Name = "btnIniciarCategoria";
            this.btnIniciarCategoria.Size = new System.Drawing.Size(193, 33);
            this.btnIniciarCategoria.TabIndex = 3;
            this.btnIniciarCategoria.Text = "Iniciar";
            this.btnIniciarCategoria.UseVisualStyleBackColor = true;
            this.btnIniciarCategoria.Click += new System.EventHandler(this.btnIniciarCategoria_Click);
            // 
            // lblNombreEquipo
            // 
            this.lblNombreEquipo.AutoSize = true;
            this.lblNombreEquipo.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.8F);
            this.lblNombreEquipo.Location = new System.Drawing.Point(6, 43);
            this.lblNombreEquipo.Name = "lblNombreEquipo";
            this.lblNombreEquipo.Size = new System.Drawing.Size(71, 23);
            this.lblNombreEquipo.TabIndex = 5;
            this.lblNombreEquipo.Text = "nombre";
            // 
            // datagvParticipantes
            // 
            this.datagvParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvParticipantes.Location = new System.Drawing.Point(6, 80);
            this.datagvParticipantes.Name = "datagvParticipantes";
            this.datagvParticipantes.RowHeadersWidth = 51;
            this.datagvParticipantes.RowTemplate.Height = 24;
            this.datagvParticipantes.Size = new System.Drawing.Size(488, 217);
            this.datagvParticipantes.TabIndex = 6;
            this.datagvParticipantes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // GuardarEquipo
            // 
            this.GuardarEquipo.ForeColor = System.Drawing.Color.Black;
            this.GuardarEquipo.Location = new System.Drawing.Point(6, 326);
            this.GuardarEquipo.Name = "GuardarEquipo";
            this.GuardarEquipo.Size = new System.Drawing.Size(102, 36);
            this.GuardarEquipo.TabIndex = 7;
            this.GuardarEquipo.Text = "Guardar ";
            this.GuardarEquipo.UseVisualStyleBackColor = true;
            this.GuardarEquipo.Click += new System.EventHandler(this.GuardarEquipo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 333);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(301, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Al guardar pasara al siguiente equipo";
            // 
            // datagvEquipos
            // 
            this.datagvEquipos.AllowUserToAddRows = false;
            this.datagvEquipos.AllowUserToDeleteRows = false;
            this.datagvEquipos.AllowUserToOrderColumns = true;
            this.datagvEquipos.AllowUserToResizeColumns = false;
            this.datagvEquipos.ColumnHeadersHeight = 29;
            this.datagvEquipos.Location = new System.Drawing.Point(32, 130);
            this.datagvEquipos.MultiSelect = false;
            this.datagvEquipos.Name = "datagvEquipos";
            this.datagvEquipos.RowHeadersWidth = 51;
            this.datagvEquipos.RowTemplate.Height = 24;
            this.datagvEquipos.Size = new System.Drawing.Size(354, 468);
            this.datagvEquipos.TabIndex = 10;
            this.datagvEquipos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagvEquipos_CellClick);
            // 
            // gboxMetros
            // 
            this.gboxMetros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.gboxMetros.Controls.Add(this.lblNombreEquipo);
            this.gboxMetros.Controls.Add(this.datagvParticipantes);
            this.gboxMetros.Controls.Add(this.label3);
            this.gboxMetros.Controls.Add(this.GuardarEquipo);
            this.gboxMetros.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.8F);
            this.gboxMetros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(231)))), ((int)(((byte)(222)))));
            this.gboxMetros.Location = new System.Drawing.Point(431, 130);
            this.gboxMetros.Name = "gboxMetros";
            this.gboxMetros.Size = new System.Drawing.Size(500, 368);
            this.gboxMetros.TabIndex = 11;
            this.gboxMetros.TabStop = false;
            this.gboxMetros.Text = "Equipo";
            // 
            // Org_EventoIniciado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(231)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(1007, 656);
            this.Controls.Add(this.gboxMetros);
            this.Controls.Add(this.datagvEquipos);
            this.Controls.Add(this.btnIniciarCategoria);
            this.Controls.Add(this.cboxCategoriaElegir);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Org_EventoIniciado";
            this.Text = "Org_EventoIniciado";
            this.Load += new System.EventHandler(this.Org_EventoIniciado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagvParticipantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagvEquipos)).EndInit();
            this.gboxMetros.ResumeLayout(false);
            this.gboxMetros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxCategoriaElegir;
        private System.Windows.Forms.Button btnIniciarCategoria;
        private System.Windows.Forms.Label lblNombreEquipo;
        private System.Windows.Forms.DataGridView datagvParticipantes;
        private System.Windows.Forms.Button GuardarEquipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView datagvEquipos;
        private System.Windows.Forms.GroupBox gboxMetros;
    }
}