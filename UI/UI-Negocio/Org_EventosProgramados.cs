using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        private void CargarEventos()
        {
            foreach (Evento evento in listEventos)
            {
                Org_EventoDisplay Edisp = new Org_EventoDisplay( evento);
                Edisp.SetEvento(evento.nombre,evento.Fecha);

                flowLayoutPanel1.Controls.Add(Edisp);
            }
            
            
        }

        private void Org_EventosProgramados_Load(object sender, EventArgs e)
        {
            listEventos = bllEvento.GetAll();
            CargarEventos();
            
        }
    }
}
