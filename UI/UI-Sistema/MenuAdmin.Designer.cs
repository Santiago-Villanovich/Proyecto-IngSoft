namespace UI
{
    partial class MenuAdmin
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
            this.gestionarOrganizacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaOrganizacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asociarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verBitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verHistorialDeCambiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarOrganizacionToolStripMenuItem,
            this.administrarToolStripMenuItem,
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(913, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gestionarOrganizacionToolStripMenuItem
            // 
            this.gestionarOrganizacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaOrganizacionToolStripMenuItem,
            this.asociarUsuarioToolStripMenuItem});
            this.gestionarOrganizacionToolStripMenuItem.Name = "gestionarOrganizacionToolStripMenuItem";
            this.gestionarOrganizacionToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.gestionarOrganizacionToolStripMenuItem.Text = "Organizaciones";
            this.gestionarOrganizacionToolStripMenuItem.Click += new System.EventHandler(this.registrarOrganizacionToolStripMenuItem_Click);
            // 
            // nuevaOrganizacionToolStripMenuItem
            // 
            this.nuevaOrganizacionToolStripMenuItem.Name = "nuevaOrganizacionToolStripMenuItem";
            this.nuevaOrganizacionToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.nuevaOrganizacionToolStripMenuItem.Text = "Gestionar Organizacion";
            this.nuevaOrganizacionToolStripMenuItem.Click += new System.EventHandler(this.nuevaOrganizacionToolStripMenuItem_Click);
            // 
            // asociarUsuarioToolStripMenuItem
            // 
            this.asociarUsuarioToolStripMenuItem.Name = "asociarUsuarioToolStripMenuItem";
            this.asociarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.asociarUsuarioToolStripMenuItem.Text = "Asociar Usuario";
            this.asociarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.asociarUsuarioToolStripMenuItem_Click);
            // 
            // administrarToolStripMenuItem
            // 
            this.administrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarUsuariosToolStripMenuItem,
            this.permisosToolStripMenuItem,
            this.verBitacoraToolStripMenuItem,
            this.verHistorialDeCambiosToolStripMenuItem});
            this.administrarToolStripMenuItem.Name = "administrarToolStripMenuItem";
            this.administrarToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.administrarToolStripMenuItem.Tag = "10";
            this.administrarToolStripMenuItem.Text = "Administrar";
            this.administrarToolStripMenuItem.Click += new System.EventHandler(this.administrarToolStripMenuItem_Click);
            // 
            // gestionarUsuariosToolStripMenuItem
            // 
            this.gestionarUsuariosToolStripMenuItem.Name = "gestionarUsuariosToolStripMenuItem";
            this.gestionarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.gestionarUsuariosToolStripMenuItem.Tag = "11";
            this.gestionarUsuariosToolStripMenuItem.Text = "Gestionar Usuarios";
            this.gestionarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.gestionarUsuariosToolStripMenuItem_Click);
            // 
            // permisosToolStripMenuItem
            // 
            this.permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            this.permisosToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.permisosToolStripMenuItem.Tag = "24";
            this.permisosToolStripMenuItem.Text = "Permisos";
            this.permisosToolStripMenuItem.Click += new System.EventHandler(this.permisosToolStripMenuItem_Click);
            // 
            // verBitacoraToolStripMenuItem
            // 
            this.verBitacoraToolStripMenuItem.Name = "verBitacoraToolStripMenuItem";
            this.verBitacoraToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.verBitacoraToolStripMenuItem.Tag = "12";
            this.verBitacoraToolStripMenuItem.Text = "Ver Bitacora";
            this.verBitacoraToolStripMenuItem.Click += new System.EventHandler(this.verBitacoraToolStripMenuItem_Click);
            // 
            // verHistorialDeCambiosToolStripMenuItem
            // 
            this.verHistorialDeCambiosToolStripMenuItem.Name = "verHistorialDeCambiosToolStripMenuItem";
            this.verHistorialDeCambiosToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.verHistorialDeCambiosToolStripMenuItem.Text = "Ver Historial de cambios";
            this.verHistorialDeCambiosToolStripMenuItem.Click += new System.EventHandler(this.verHistorialDeCambiosToolStripMenuItem_Click);
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuracionToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.opcionesToolStripMenuItem.Tag = "13";
            this.opcionesToolStripMenuItem.Text = "Opciones";
            this.opcionesToolStripMenuItem.Click += new System.EventHandler(this.opcionesToolStripMenuItem_Click);
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.configuracionToolStripMenuItem.Tag = "14";
            this.configuracionToolStripMenuItem.Text = "Gestionar idiomas";
            this.configuracionToolStripMenuItem.Click += new System.EventHandler(this.configuracionToolStripMenuItem_Click);
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // MenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(913, 444);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuAdmin";
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuAdmin_FormClosed);
            this.Load += new System.EventHandler(this.MenuAdmin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verBitacoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verHistorialDeCambiosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarOrganizacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaOrganizacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asociarUsuarioToolStripMenuItem;
    }
}