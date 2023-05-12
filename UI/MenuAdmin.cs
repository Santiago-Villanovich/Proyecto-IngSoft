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

namespace UI
{
    public partial class MenuAdmin : Form, IObserver
    {
        public string IdiomaActual {get; set;}
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
            FormBitacoras form = new FormBitacoras();
            form.MdiParent = this;
            form.Show();
        }

        private void MenuAdmin_Load(object sender, EventArgs e)
        {
            Session._publisherIdioma.Subscribe(this);
            IdiomaActual = Session.IdiomaActual;
            label1.Text = IdiomaActual;
        }

        public void Notify(string idioma)
        {
            IdiomaActual = idioma;
            label1.Text = IdiomaActual;
        }
    }
}
