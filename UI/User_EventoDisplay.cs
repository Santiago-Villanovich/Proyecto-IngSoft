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
    public partial class User_EventoDisplay : UserControl
    {
        public Evento MiEvento;
        Color naranja = Color.FromArgb(236, 125, 24);
        Color crema = Color.FromArgb(235, 231, 222);

        public User_EventoDisplay(Evento e)
        {

            InitializeComponent();
            MiEvento = e;
            SetDisplay();
        }

        public void SetDisplay()
        {
            lblNombre.Text = MiEvento.nombre;
            lblFecha.Text = MiEvento.Fecha.ToShortDateString();
            lblCoste.Text = "$ " + MiEvento.ValorInscripcion.ToString();
            if (MiEvento.portada != null)
            {
                using (MemoryStream stream = new MemoryStream(MiEvento.portada))
                {
                    Image imagen = Image.FromStream(stream);

                    pictureBox1.Image = imagen;
                }
            }
        }

        public event EventHandler clickHandler;

        public void User_EventoDisplay_Click(object sender, EventArgs e)
        {
            clickHandler?.Invoke(this, EventArgs.Empty);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            clickHandler?.Invoke(this, EventArgs.Empty);
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {
            clickHandler?.Invoke(this, EventArgs.Empty);
        }

        #region(hovers)
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = naranja;
            lblNombre.ForeColor = crema; 
            lblFecha.ForeColor = crema;
            lblCoste.ForeColor = crema;
        }
        private void lblNombre_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = crema;
            lblNombre.ForeColor = Color.Black;
            lblFecha.ForeColor = Color.Black;
            lblCoste.ForeColor = Color.Black;
        }
        #endregion


    }
}
