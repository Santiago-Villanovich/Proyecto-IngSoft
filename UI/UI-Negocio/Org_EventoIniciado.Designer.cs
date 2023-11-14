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
            this.lblNombreEquipoTiempo = new System.Windows.Forms.Label();
            this.btnGuardarEquipoTiempo = new System.Windows.Forms.Button();
            this.datagvEquipos = new System.Windows.Forms.DataGridView();
            this.gboxParticipantes = new System.Windows.Forms.GroupBox();
            this.datagvParticipantes = new System.Windows.Forms.DataGridView();
            this.btnGuardarCategoria = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagvEquipos)).BeginInit();
            this.gboxParticipantes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagvParticipantes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Categoria";
            // 
            // cboxCategoriaElegir
            // 
            this.cboxCategoriaElegir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCategoriaElegir.FormattingEnabled = true;
            this.cboxCategoriaElegir.Location = new System.Drawing.Point(69, 44);
            this.cboxCategoriaElegir.Name = "cboxCategoriaElegir";
            this.cboxCategoriaElegir.Size = new System.Drawing.Size(265, 24);
            this.cboxCategoriaElegir.TabIndex = 2;
            // 
            // btnIniciarCategoria
            // 
            this.btnIniciarCategoria.Location = new System.Drawing.Point(69, 74);
            this.btnIniciarCategoria.Name = "btnIniciarCategoria";
            this.btnIniciarCategoria.Size = new System.Drawing.Size(265, 33);
            this.btnIniciarCategoria.TabIndex = 3;
            this.btnIniciarCategoria.Text = "Iniciar categoria";
            this.btnIniciarCategoria.UseVisualStyleBackColor = true;
            this.btnIniciarCategoria.Click += new System.EventHandler(this.btnIniciarCategoria_Click);
            // 
            // lblNombreEquipoTiempo
            // 
            this.lblNombreEquipoTiempo.AutoSize = true;
            this.lblNombreEquipoTiempo.Font = new System.Drawing.Font("Franklin Gothic Medium", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreEquipoTiempo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(231)))), ((int)(((byte)(222)))));
            this.lblNombreEquipoTiempo.Location = new System.Drawing.Point(8, 18);
            this.lblNombreEquipoTiempo.Name = "lblNombreEquipoTiempo";
            this.lblNombreEquipoTiempo.Size = new System.Drawing.Size(108, 36);
            this.lblNombreEquipoTiempo.TabIndex = 5;
            this.lblNombreEquipoTiempo.Text = "nombre";
            // 
            // btnGuardarEquipoTiempo
            // 
            this.btnGuardarEquipoTiempo.ForeColor = System.Drawing.Color.Black;
            this.btnGuardarEquipoTiempo.Location = new System.Drawing.Point(14, 313);
            this.btnGuardarEquipoTiempo.Name = "btnGuardarEquipoTiempo";
            this.btnGuardarEquipoTiempo.Size = new System.Drawing.Size(190, 49);
            this.btnGuardarEquipoTiempo.TabIndex = 7;
            this.btnGuardarEquipoTiempo.Text = "Guardar ";
            this.btnGuardarEquipoTiempo.UseVisualStyleBackColor = true;
            this.btnGuardarEquipoTiempo.Click += new System.EventHandler(this.GuardarEquipo_Click);
            // 
            // datagvEquipos
            // 
            this.datagvEquipos.AllowUserToAddRows = false;
            this.datagvEquipos.AllowUserToDeleteRows = false;
            this.datagvEquipos.AllowUserToOrderColumns = true;
            this.datagvEquipos.AllowUserToResizeColumns = false;
            this.datagvEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.datagvEquipos.ColumnHeadersHeight = 29;
            this.datagvEquipos.Location = new System.Drawing.Point(29, 130);
            this.datagvEquipos.MultiSelect = false;
            this.datagvEquipos.Name = "datagvEquipos";
            this.datagvEquipos.RowHeadersWidth = 51;
            this.datagvEquipos.RowTemplate.Height = 24;
            this.datagvEquipos.Size = new System.Drawing.Size(354, 480);
            this.datagvEquipos.TabIndex = 10;
            this.datagvEquipos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagvEquipos_CellClick);
            // 
            // gboxParticipantes
            // 
            this.gboxParticipantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxParticipantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.gboxParticipantes.Controls.Add(this.lblNombreEquipoTiempo);
            this.gboxParticipantes.Controls.Add(this.datagvParticipantes);
            this.gboxParticipantes.Controls.Add(this.btnGuardarEquipoTiempo);
            this.gboxParticipantes.Location = new System.Drawing.Point(417, 130);
            this.gboxParticipantes.Name = "gboxParticipantes";
            this.gboxParticipantes.Size = new System.Drawing.Size(521, 385);
            this.gboxParticipantes.TabIndex = 11;
            this.gboxParticipantes.TabStop = false;
            // 
            // datagvParticipantes
            // 
            this.datagvParticipantes.AllowUserToResizeRows = false;
            this.datagvParticipantes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagvParticipantes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.datagvParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvParticipantes.Location = new System.Drawing.Point(14, 72);
            this.datagvParticipantes.Name = "datagvParticipantes";
            this.datagvParticipantes.RowHeadersWidth = 51;
            this.datagvParticipantes.RowTemplate.Height = 24;
            this.datagvParticipantes.Size = new System.Drawing.Size(492, 179);
            this.datagvParticipantes.TabIndex = 8;
            this.datagvParticipantes.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.datagvParticipantes_RowsAdded);
            // 
            // btnGuardarCategoria
            // 
            this.btnGuardarCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardarCategoria.Location = new System.Drawing.Point(69, 616);
            this.btnGuardarCategoria.Name = "btnGuardarCategoria";
            this.btnGuardarCategoria.Size = new System.Drawing.Size(265, 33);
            this.btnGuardarCategoria.TabIndex = 12;
            this.btnGuardarCategoria.Text = "Terminar categoria";
            this.btnGuardarCategoria.UseVisualStyleBackColor = true;
            this.btnGuardarCategoria.Click += new System.EventHandler(this.btnGuardarCategoria_Click);
            // 
            // Org_EventoIniciado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(231)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(1096, 679);
            this.Controls.Add(this.btnGuardarCategoria);
            this.Controls.Add(this.gboxParticipantes);
            this.Controls.Add(this.datagvEquipos);
            this.Controls.Add(this.btnIniciarCategoria);
            this.Controls.Add(this.cboxCategoriaElegir);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Org_EventoIniciado";
            this.Text = "Org_EventoIniciado";
            this.Load += new System.EventHandler(this.Org_EventoIniciado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagvEquipos)).EndInit();
            this.gboxParticipantes.ResumeLayout(false);
            this.gboxParticipantes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagvParticipantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxCategoriaElegir;
        private System.Windows.Forms.Button btnIniciarCategoria;
        private System.Windows.Forms.Label lblNombreEquipoTiempo;
        private System.Windows.Forms.Button btnGuardarEquipoTiempo;
        private System.Windows.Forms.DataGridView datagvEquipos;
        private System.Windows.Forms.GroupBox gboxParticipantes;
        private System.Windows.Forms.DataGridView datagvParticipantes;
        private System.Windows.Forms.Button btnGuardarCategoria;
    }
}