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

namespace UI.UI_Negocio
{
    public partial class Org_EventoIniciado : Form
    {
        public Evento EventoHoy;
        public Org_EventoIniciado(Evento ev)
        {
            InitializeComponent();
            EventoHoy = ev;
            CargarDatagrid(ev.Categorias[1].equipos[0]);
        }

        private void CargarDatagrid(Equipo eq)
        {
            DataGridTextBoxColumn columTxt;
            foreach (var part in eq.Participantes)
            {
                columTxt = new DataGridTextBoxColumn();
                columTxt.HeaderText = part.Usuario.NombreApellido.ToString();

            }
        }
    }
}
