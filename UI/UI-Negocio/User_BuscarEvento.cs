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
    public partial class User_BuscarEvento : Form
    {
        public List<Evento> listEventos;
        public BLL_Evento bllEvento;
        private Evento eventoSeleccionado;
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
        }
    }
}
