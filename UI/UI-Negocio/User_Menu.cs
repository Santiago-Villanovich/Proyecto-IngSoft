using Syncfusion.WinForms.Input;
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
using UI.UI_Negocio;

namespace UI
{
    public partial class User_Menu : Form
    {
        public User_Menu()
        {
            InitializeComponent();
            CargarMenuContenedor(new User_Inicio());
        }

        private void MenuUser_Load(object sender, EventArgs e)
        {
        }

        private void CargarMenuContenedor(object formHijo)
        {
            if (this.PanelContenedor.Controls.Count>0) 
            {
                this.PanelContenedor.Controls.RemoveAt(0);
            }
            Form frm = formHijo as Form;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(frm);
            this.PanelContenedor.Tag = frm;
            frm.Show();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

        }
    }
}
