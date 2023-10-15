using BE;
using BLL;
using Services;
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
    public partial class User_BuscarEvento : Form
    {
        public List<Evento> listEventos;
        public BLL_Evento bllEvento;
        private Evento eventoSeleccionado;
        private Natacion eventoDeporte;
        
        public User_BuscarEvento()
        {
            InitializeComponent();
            bllEvento = new BLL_Evento();
            flowLayoutPanel1.VerticalScroll.Visible = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.AutoScroll = true;

        }

        private void MostrarEvento(Evento evento)
        {
            eventoSeleccionado = evento;
            eventoDeporte = (Natacion)evento.Deporte;

            Natacion nata = (Natacion)evento.Deporte;
            gboxInformacion.Visible = true;

            lblTitulo.Text = evento.nombre;
            lblDesc.Text = evento.Descripcion;
            lblNomOrg.Text = evento.Organizacion.Nombre;
            lblContactoOrg.Text = evento.Organizacion.Email;
            lblDireccion.Text = nata.Pileta.Direccion;
            lblEquipo.Text = nata.cantidad_integrantes_equipo.ToString();
            if (nata.MetrosTotales != 0)
            {
                lblDistancia.Text = nata.MetrosTotales.ToString() + " Mts";
            }
            else
            {
                lblDistancia.Text = nata.TiempoTotal.ToString() + " min";
            }
            lblCoste.Text = "$ " + evento.ValorInscripcion.ToString();
            
        }

        private void CargarEventos()
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

                if (listEventos.Count > 0)
                {


                    foreach (Evento evento in listEventos)
                    {
                        User_EventoDisplay eDisp = new User_EventoDisplay(evento);
                        eDisp.clickHandler += (sender, e) =>
                        {
                            MostrarEvento(eDisp.MiEvento);

                        };
                        flowLayoutPanel1.Controls.Add(eDisp);
                    }
                }
                else
                {
                    MessageBox.Show("Por el momento no tiene eventos publicados", "Sin eventos disponibles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void User_BuscarEvento_Load(object sender, EventArgs e)
        {
            listEventos =  bllEvento.GetAll();
            CargarEventos();

            gboxInformacion.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (eventoDeporte.cantidad_integrantes_equipo > 1)
                {

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message);
            }
            

        }
    }
}
