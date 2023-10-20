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
    }
}
