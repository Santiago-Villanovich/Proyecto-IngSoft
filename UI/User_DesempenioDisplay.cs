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
    public partial class User_DesempenioDisplay : UserControl
    {
        public User_DesempenioDisplay(Participante p)
        {
            InitializeComponent();
            CargarDatos(p);
        }

        private void CargarDatos(Participante p)
        {
            lblDiaMes.Text = $"{p.fecha.Day}/{p.fecha.Month}";
            lblAnio.Text = p.fecha.Year.ToString();

            if (p.MetrosLogrados != 0)
            {
                listBox1.Items.Add($"{p.MetrosLogrados} Mts");
            }
            else
            {
                if (p.Tiempos.Count > 0 )
                {
                    foreach (var t in p.Tiempos)
                    {
                        listBox1.Items.Add(t.ToString());
                    }
                }
            }
        }

        private void User_DesempenioDisplay_Load(object sender, EventArgs e)
        {

        }
    }
}
