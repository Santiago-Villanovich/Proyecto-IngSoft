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
        Color on = Color.FromArgb(86, 88, 99);
        Color off = Color.FromArgb(45, 48, 71);

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
    }
}
