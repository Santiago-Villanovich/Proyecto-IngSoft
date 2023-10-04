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
        BLL_User bll_User;
        BLL_Org bll_Org;
        BLL_Permisos bll_Permisos;

        public FormUsuarioOrg()
        {
            InitializeComponent();
            bll_Org = new BLL_Org();
            bll_User = new BLL_User();
            bll_Permisos = new BLL_Permisos();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormUsuarioOrg_Load(object sender, EventArgs e)
        {
            try
            {
                dtgridUsuarios.DataSource = null;
                dtgridUsuarios.DataSource = bll_User.GetAll();
                dtgridUsuarios.Columns["DV"].Visible = false;
                dtgridUsuarios.Columns["Clave"].Visible = false;
                dtgridUsuarios.Columns["NombreApellido"].Visible = false;
                dtgridUsuarios.Columns["Organizacion"].Visible = false;

                dtgridOrg.DataSource = null;
                dtgridOrg.DataSource = bll_Org.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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
                    Familia componente = new Familia() { Id = 1039, Nombre = "Organizacion" };
                    Familia componente2 = new Familia() { Id = 1036, Nombre = "Usuario" };

                    if (bll_User.tiene_permiso(usuario, 1039))
                    {
                        if (bll_Org.AsociarUsuario(org, usuario))
                        {
                            if (bll_User.tiene_permiso(usuario, 1036))
                            {
                                bll_Permisos.SacarPermisoUser(usuario, componente2);
                            }

                            bll_User.AgregarPermiso(componente, usuario);
                            MessageBox.Show("El usuario fue asociado exitosamente");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Este usuario ya esta asociado a una organizacion");
                        return;
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
