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
            this.label2 = new System.Windows.Forms.Label();
            this.lblNombreEquipo = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.GuardarEquipo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Equipo: ";
            // 
            // lblNombreEquipo
            // 
            this.lblNombreEquipo.AutoSize = true;
            this.lblNombreEquipo.Location = new System.Drawing.Point(29, 163);
            this.lblNombreEquipo.Name = "lblNombreEquipo";
            this.lblNombreEquipo.Size = new System.Drawing.Size(53, 16);
            this.lblNombreEquipo.TabIndex = 5;
            this.lblNombreEquipo.Text = "nombre";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(32, 207);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(495, 200);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // GuardarEquipo
            // 
            this.GuardarEquipo.Location = new System.Drawing.Point(32, 413);
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
            this.label3.Location = new System.Drawing.Point(151, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Al guardar pasara al siguiente equipo";
            // 
            // Org_EventoIniciado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(231)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(1007, 656);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GuardarEquipo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblNombreEquipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnIniciarCategoria);
            this.Controls.Add(this.cboxCategoriaElegir);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Org_EventoIniciado";
            this.Text = "Org_EventoIniciado";
            this.Load += new System.EventHandler(this.Org_EventoIniciado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxCategoriaElegir;
        private System.Windows.Forms.Button btnIniciarCategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombreEquipo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button GuardarEquipo;
        private System.Windows.Forms.Label label3;
    }
}