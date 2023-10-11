using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.UI_Negocio;

namespace UI
{
    public partial class Org_EventoDisplay : UserControl
    {
        public event EventHandler ImagenClickeada;


        public Evento MiEvento;
        Color on = Color.FromArgb(86, 88, 99);
        Color off = Color.FromArgb(45, 48, 71);

        public Org_EventoDisplay(Evento evento)
        {
            InitializeComponent();
            this.MiEvento = evento;
        }

        private void Org_EventoDisplay_Load(object sender, EventArgs e)
        {

        }

        public void SetEvento(string Nombre, DateTime fecha, byte[] foto = null)
        {
            lblNombre.Text = Nombre;
            lblFecha.Text = fecha.ToShortDateString();
            if (foto != null)
            {
                using (MemoryStream stream = new MemoryStream(foto))
                {
                    Image imagen = Image.FromStream(stream);

                    pictureBox1.Image = imagen;
                }
            }
        }

        #region(Hovers)
        private void Org_EventoDisplay_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = on;
        }

        private void Org_EventoDisplay_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = off;
        }

        private void lblNombre_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = on;
        }

        private void lblNombre_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = off;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = on;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = off;
        }

        private void lblFecha_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = on;
        }

        private void lblFecha_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = off;
        }
        #endregion

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void Org_EventoDisplay_Click(object sender, EventArgs e)
        {
            ImagenClickeada?.Invoke(this, EventArgs.Empty);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ImagenClickeada?.Invoke(this, EventArgs.Empty);
        }
    }
}
