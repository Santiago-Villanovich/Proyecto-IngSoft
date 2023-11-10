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

namespace UI
{
    public partial class Org_EventoDisplay_Cerrado : UserControl
    {
        public Evento MiEvento;
        Color on = Color.FromArgb(86, 88, 99);
        Color off = Color.FromArgb(45, 48, 71);

        public Org_EventoDisplay_Cerrado(Evento evento)
        {
            InitializeComponent();

            this.MiEvento = evento;
            btnIniciar.Visible = false;
        }

        public void SetEvento(Evento evento, DateTime fecha)
        {
            lblNombre.Text = evento.nombre;
            if (evento.Fecha.ToShortDateString() == fecha.ToShortDateString()) {
                lblFecha.Text = "Hoy";
                btnIniciar.Visible = true;
            }
            else
            {
                lblFecha.Text = evento.Fecha.ToShortDateString();
            }

            if (evento.portada != null)
            {
                using (MemoryStream stream = new MemoryStream(evento.portada))
                {
                    Image imagen = Image.FromStream(stream);

                    pictureBox1.Image = imagen;
                }
            }
        }

        public event EventHandler iniciarClick;
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            iniciarClick?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler verClick;
        private void Org_EventoDisplay_Cerrado_Click(object sender, EventArgs e)
        {
            verClick?.Invoke(this, EventArgs.Empty);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            verClick?.Invoke(this, EventArgs.Empty);
        }

        private void Org_EventoDisplay_Cerrado_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = on;
        }

        private void Org_EventoDisplay_Cerrado_MouseLeave(object sender, EventArgs e)
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

        
    }
}
