using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        private void gestionarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestUsuarios menu = new GestUsuarios();
            menu.MdiParent = this;
            menu.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.Logout();
            LogIn form = new LogIn();
            this.Close();
            form.Show();
        }

        private void verBitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBitacoras menu = new FormBitacoras();
            menu.MdiParent = this;
            menu.Show();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPermisos menu = new FormPermisos();
            menu.MdiParent = this;
            menu.Show();
        }
    }
}
