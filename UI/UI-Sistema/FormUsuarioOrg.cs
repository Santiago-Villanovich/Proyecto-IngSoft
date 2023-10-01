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
using BE;

namespace UI.UI_Sistema
{
    public partial class FormUsuarioOrg : Form
    {
        Organizacion org;
        User usuario;
        BLL_Org bll_Org;

        public FormUsuarioOrg()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormUsuarioOrg_Load(object sender, EventArgs e)
        {
            dtgridUsuarios.DataSource = null;
            dtgridUsuarios.DataSource = new BLL_User().GetAll();
            dtgridUsuarios.Columns["DV"].Visible = false;
            dtgridUsuarios.Columns["Clave"].Visible = false;
            dtgridUsuarios.Columns["NombreApellido"].Visible = false;
            dtgridUsuarios.Columns["Organizacion"].Visible = false;

            dtgridOrg.DataSource = null;
            dtgridOrg.DataSource = bll_Org.GetAll();
        }

        private void dtgridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            usuario = (User)dtgridUsuarios.CurrentRow.DataBoundItem;
            lblUsuario.Text = usuario.NombreApellido;
        }

        private void dtgridOrg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            org = (Organizacion)dtgridOrg.CurrentRow.DataBoundItem;
            lblOrg.Text = org.Nombre;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (org != null && usuario != null)
                {
                    if(bll_Org.AsociarUsuario(org, usuario))
                    {
                        MessageBox.Show("El usuario fue asociado exitosamente");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
