using BE;
using BLL;
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
using UI.UI_Negocio;
using static Org.BouncyCastle.Crypto.Digests.SkeinEngine;

namespace UI
{
    public partial class Org_Menu : Form
    {
        BLL_Evento bllEvento;
        public Org_Menu()
        {
            InitializeComponent();
            this.Size = new Size(1200, 650);
            this.MinimumSize = new Size(1200, 650);
            bllEvento = new BLL_Evento();
        }

        private void CargarMenuContenedor(object formHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }
            Form frm = formHijo as Form;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(frm);
            this.panelContenedor.Tag = frm;

            if (frm is Org_IniciarEvento orgIniciarEventoForm)
            {
                orgIniciarEventoForm.mostrarIniciar += (sender, e) => MostrarEventoIniciado(orgIniciarEventoForm.eventoIniciado);
            }
            frm.Show();
        }


        private void MostrarEventoIniciado(Evento ev)
        {
            CargarMenuContenedor(new Org_EventoIniciado(ev));
        }

        private void btnNuevoEvento_Click(object sender, EventArgs e)
        {
            CargarMenuContenedor(new Org_NuevoEvento());
        }

        private void btnIniciarEvento_Click(object psender, EventArgs ea)
        {
            CargarMenuContenedor(new Org_IniciarEvento());
            this.Size = new Size(650, 650);
            this.MinimumSize = new Size(650, 650);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Session.Logout();
            this.Close();
            Application.Restart();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormConfiguracion form = new FormConfiguracion();
            form.ShowDialog();
        }

        private void btnEventosProgramados_Click(object sender, EventArgs e)
        {
            CargarMenuContenedor(new Org_EventosProgramados());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CargarMenuContenedor(new Org_Inicio());
        }
    }
}
