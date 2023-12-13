namespace UI.UI_Sistema
{
    partial class MenuAdmin2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarPermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verBitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verHistorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarOrganizacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asociarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarIdiomasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarToolStripMenuItem,
            this.organizacionesToolStripMenuItem,
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administrarToolStripMenuItem
            // 
            this.administrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarUsuariosToolStripMenuItem,
            this.gestionarPermisosToolStripMenuItem,
            this.verBitacoraToolStripMenuItem,
            this.verHistorialToolStripMenuItem});
            this.administrarToolStripMenuItem.Name = "administrarToolStripMenuItem";
            this.administrarToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.administrarToolStripMenuItem.Tag = "10";
            this.administrarToolStripMenuItem.Text = "Administrar";
            // 
            // gestionarUsuariosToolStripMenuItem
            // 
            this.gestionarUsuariosToolStripMenuItem.Name = "gestionarUsuariosToolStripMenuItem";
            this.gestionarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.gestionarUsuariosToolStripMenuItem.Tag = "11";
            this.gestionarUsuariosToolStripMenuItem.Text = "Gestionar usuarios";
            this.gestionarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.gestionarUsuariosToolStripMenuItem_Click);
            // 
            // gestionarPermisosToolStripMenuItem
            // 
            this.gestionarPermisosToolStripMenuItem.Name = "gestionarPermisosToolStripMenuItem";
            this.gestionarPermisosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.gestionarPermisosToolStripMenuItem.Tag = "24";
            this.gestionarPermisosToolStripMenuItem.Text = "Gestionar permisos";
            this.gestionarPermisosToolStripMenuItem.Click += new System.EventHandler(this.gestionarPermisosToolStripMenuItem_Click);
            // 
            // verBitacoraToolStripMenuItem
            // 
            this.verBitacoraToolStripMenuItem.Name = "verBitacoraToolStripMenuItem";
            this.verBitacoraToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.verBitacoraToolStripMenuItem.Tag = "12";
            this.verBitacoraToolStripMenuItem.Text = "Ver bitacora";
            this.verBitacoraToolStripMenuItem.Click += new System.EventHandler(this.verBitacoraToolStripMenuItem_Click);
            // 
            // verHistorialToolStripMenuItem
            // 
            this.verHistorialToolStripMenuItem.Name = "verHistorialToolStripMenuItem";
            this.verHistorialToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.verHistorialToolStripMenuItem.Tag = "25";
            this.verHistorialToolStripMenuItem.Text = "Ver historial";
            this.verHistorialToolStripMenuItem.Click += new System.EventHandler(this.verHistorialToolStripMenuItem_Click);
            // 
            // organizacionesToolStripMenuItem
            // 
            this.organizacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarOrganizacionesToolStripMenuItem,
            this.asociarUsuarioToolStripMenuItem});
            this.organizacionesToolStripMenuItem.Name = "organizacionesToolStripMenuItem";
            this.organizacionesToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.organizacionesToolStripMenuItem.Tag = "89";
            this.organizacionesToolStripMenuItem.Text = "Organizaciones";
            // 
            // gestionarOrganizacionesToolStripMenuItem
            // 
            this.gestionarOrganizacionesToolStripMenuItem.Name = "gestionarOrganizacionesToolStripMenuItem";
            this.gestionarOrganizacionesToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.gestionarOrganizacionesToolStripMenuItem.Tag = "96";
            this.gestionarOrganizacionesToolStripMenuItem.Text = "Gestionar organizaciones";
            this.gestionarOrganizacionesToolStripMenuItem.Click += new System.EventHandler(this.gestionarOrganizacionesToolStripMenuItem_Click);
            // 
            // asociarUsuarioToolStripMenuItem
            // 
            this.asociarUsuarioToolStripMenuItem.Name = "asociarUsuarioToolStripMenuItem";
            this.asociarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.asociarUsuarioToolStripMenuItem.Tag = "97";
            this.asociarUsuarioToolStripMenuItem.Text = "Asociar usuario";
            this.asociarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.asociarUsuarioToolStripMenuItem_Click);
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarIdiomasToolStripMenuItem,
            this.cerrarSessionToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.opcionesToolStripMenuItem.Tag = "13";
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // gestionarIdiomasToolStripMenuItem
            // 
            this.gestionarIdiomasToolStripMenuItem.Name = "gestionarIdiomasToolStripMenuItem";
            this.gestionarIdiomasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.gestionarIdiomasToolStripMenuItem.Tag = "14";
            this.gestionarIdiomasToolStripMenuItem.Text = "Gestionar idiomas";
            this.gestionarIdiomasToolStripMenuItem.Click += new System.EventHandler(this.gestionarIdiomasToolStripMenuItem_Click);
            // 
            // cerrarSessionToolStripMenuItem
            // 
            this.cerrarSessionToolStripMenuItem.Name = "cerrarSessionToolStripMenuItem";
            this.cerrarSessionToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cerrarSessionToolStripMenuItem.Tag = "21";
            this.cerrarSessionToolStripMenuItem.Text = "Cerrar sesion";
            this.cerrarSessionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSessionToolStripMenuItem_Click);
            // 
            // MenuAdmin2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MenuAdmin2";
            this.Text = "MenuAdmin2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarPermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verBitacoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verHistorialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem organizacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarOrganizacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asociarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarIdiomasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSessionToolStripMenuItem;
    }
}