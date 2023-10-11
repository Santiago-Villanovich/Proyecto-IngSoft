using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.UI_Negocio
{
    public partial class Org_EventosProgramados : Form
    {
        BLL_Evento bllEvento;
        List<Evento> listEventos;
        public static Evento eventoSeleccionado;



        public Org_EventosProgramados()
        {
            InitializeComponent();
            groupBox1.Visible = false;
            groupBox1.Enabled = false;
            bllEvento = new BLL_Evento();
            flowLayoutPanel1.HorizontalScroll.Visible = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.AutoScroll = true;
        }
        public void MostrarOpciones(Evento evento)
        {
            this.groupBox1.Visible = true;
            this.groupBox1.Enabled = true;

            MessageBox.Show(evento.nombre);

        }
        private void CargarEventos()
        {
            foreach (Evento evento in listEventos)
            {
                Org_EventoDisplay Edisp = new Org_EventoDisplay( evento);
                Edisp.SetEvento(evento.nombre,evento.Fecha,evento.portada);

                flowLayoutPanel1.Controls.Add(Edisp);
            }
            
            
        }

        private void Org_EventosProgramados_Load(object sender, EventArgs e)
        {
            listEventos = bllEvento.GetAllByOrg();
            CargarEventos();
            
        }
    }
}
