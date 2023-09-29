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

namespace UI
{
    public partial class Org_Menu : Form
    {
        public Org_Menu()
        {
            InitializeComponent();
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
            frm.Show();
        }

        private void btnNuevoEvento_Click(object sender, EventArgs e)
        {
            CargarMenuContenedor(new Org_NuevoEvento());
            this.Size = new Size(1200,650);
        }

        private void btnIniciarEvento_Click(object sender, EventArgs e)
        {

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
    }
}
