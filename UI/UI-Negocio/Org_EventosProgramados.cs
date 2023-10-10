using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.UI_Negocio
{
    public partial class Org_EventosProgramados : Form
    {
        BLL_Evento bllEvento;
        List<Evento> listEventos;
        public Org_EventosProgramados()
        {
            InitializeComponent();
            bllEvento = new BLL_Evento();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Org_EventosProgramados_Load(object sender, EventArgs e)
        {

        }
    }
}
