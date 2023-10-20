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
using BLL;

namespace UI.UI_Negocio
{
    public partial class Org_IniciarEvento : Form
    {
        public Evento eventoIniciado;
        List<Evento> eventos;
        DateTime hoy;

        public Org_IniciarEvento()
        {
            InitializeComponent();
            eventos = new BLL_Evento().GetAllByOrg_estado(4);
            hoy = DateTime.Now;
            CargarEventos(hoy);

        }

        public event EventHandler mostrarIniciar;
        private void CargarEventos(DateTime fecha)
        {
            try
            {
                if (flowLayoutPanel1.Controls.Count > 0)
                {
                    foreach (Control control in flowLayoutPanel1.Controls)
                    {
                        control.Dispose();
                    }
                    flowLayoutPanel1.Controls.Clear();
                }

                if (eventos.Count > 0)
                {
                    Evento ev = eventos.Find(obj => obj.Fecha.Date == fecha.Date);

                    if (ev != null) 
                    {
                        Org_EventoDisplay_Cerrado Edisp = new Org_EventoDisplay_Cerrado(ev);
                        Edisp.SetEvento(ev,fecha);
                        

                        flowLayoutPanel1.Controls.Add(Edisp);
                        lblTitulo.Text = "El Evento de hoy";
                        Edisp.iniciarClick += (sender, e) =>
                        {
                            eventoIniciado = Edisp.MiEvento;
                            mostrarIniciar?.Invoke(this, EventArgs.Empty);

                            //new BLL_Evento().UpdateEstado(Edisp.MiEvento,6);
                           
                        };
                    }
                    else
                    {
                        foreach (Evento evento in eventos)
                        {
                            Org_EventoDisplay_Cerrado Edisp = new Org_EventoDisplay_Cerrado(evento);
                            Edisp.SetEvento(evento, fecha);

                            flowLayoutPanel1.Controls.Add(Edisp);
                        }
                        lblTitulo.Text = "Eventos proximos";
                    }
                    
                }
                else
                {
                    lblTitulo.Text = "Sin eventos disponibles";
                    MessageBox.Show("Por el momento no tiene eventos publicados", "Sin eventos disponibles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
