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
using ABS;
using Services.Multilanguage;

namespace UI
{
    public partial class MenuAdmin : Form, IObserver
    {
        private Idioma IdiomaActual { get; set; }
        private void TraducirForm(IIdioma idioma = null)
        {

            var traducciones = traductor.ObtenerTraducciones(idioma);

            if (administrarToolStripMenuItem.Tag != null && traducciones.ContainsKey(administrarToolStripMenuItem.Tag.ToString()))
                administrarToolStripMenuItem.Text = traducciones[administrarToolStripMenuItem.Tag.ToString()].texto;

            if (gestionarUsuariosToolStripMenuItem.Tag != null && traducciones.ContainsKey(gestionarUsuariosToolStripMenuItem.Tag.ToString()))
                gestionarUsuariosToolStripMenuItem.Text = traducciones[gestionarUsuariosToolStripMenuItem.Tag.ToString()].texto;

            if (verBitacoraToolStripMenuItem.Tag != null && traducciones.ContainsKey(verBitacoraToolStripMenuItem.Tag.ToString()))
                verBitacoraToolStripMenuItem.Text = traducciones[verBitacoraToolStripMenuItem.Tag.ToString()].texto;

            if (opcionesToolStripMenuItem.Tag != null && traducciones.ContainsKey(opcionesToolStripMenuItem.Tag.ToString()))
                opcionesToolStripMenuItem.Text = traducciones[opcionesToolStripMenuItem.Tag.ToString()].texto;

            if (configuracionToolStripMenuItem.Tag != null && traducciones.ContainsKey(configuracionToolStripMenuItem.Tag.ToString()))
                configuracionToolStripMenuItem.Text = traducciones[configuracionToolStripMenuItem.Tag.ToString()].texto;
        }
        public MenuAdmin()
        {
            InitializeComponent();
            traductor = new BLL_Traductor();

            Session.IdiomaActual = (Idioma)traductor.ObtenerIdiomaDefault();
            IdiomaActual = Session.IdiomaActual;
            TraducirForm(IdiomaActual);
        }

        BLL_Traductor traductor;

        private void MenuAdmin_Load(object sender, EventArgs e)
        {
            Session._publisherIdioma.Subscribe(this);
            IdiomaActual = Session.IdiomaActual;

        }

        public void Notify(Idioma idioma)
        {
            TraducirForm(idioma);
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

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConfiguracion menu = new FormConfiguracion();
            menu.MdiParent = this;
            menu.Show();
        }

    }
}
