using BE;
using Services;
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

        public Evento MiEvento;
        Color on = Color.FromArgb(86, 88, 99);
        Color off = Color.FromArgb(45, 48, 71);

        public Org_EventoDisplay(Evento evento)
        {
            InitializeComponent();
            this.MiEvento = evento;
            editarHandler += btnEditar_Click;
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

        public event EventHandler editarHandler;
        public event EventHandler cancelarHandler;

        private void btnEditar_Click(object sender, EventArgs e)
        {
            editarHandler?.Invoke(this, EventArgs.Empty);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarHandler?.Invoke(this, EventArgs.Empty);
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


        
    }
}
