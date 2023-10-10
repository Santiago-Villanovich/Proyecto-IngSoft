using BE;
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
    public partial class Org_EventoDisplay : UserControl
    {
        public Evento MiEvento;

        public Org_EventoDisplay(Evento evento)
        {
            InitializeComponent();
            this.MiEvento = evento;
        }

        private void Org_EventoDisplay_Load(object sender, EventArgs e)
        {

        }

        public void SetEvento(string Nombre, DateTime fecha, int metros, string foto = null)
        {
            lblNombre.Text = Nombre;
            lblFecha.Text = fecha.ToShortDateString();
            lblMetrosTiempo.Text = metros.ToString();
        }
    }
}
