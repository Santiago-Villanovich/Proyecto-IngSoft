using BE;
using BLL;
using Services;
using Services.Multilanguage;
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
    public partial class GestUsuarios : Form, IObserver
    {
        private Idioma IdiomaActual;
        private void TraducirForm(IIdioma idioma = null)/*IIdioma idioma = null*/
        {

            var traducciones = traductor.ObtenerTraducciones(idioma);

            foreach (Control control in this.Controls)
            {

                if (control is Button)
                {
                    Button boton = (Button)control;
                    if (boton.Tag != null && traducciones.ContainsKey(boton.Tag.ToString()))
                        boton.Text = traducciones[boton.Tag.ToString()].texto;
                }
                else if (control is Label)
                {
                    Label label = (Label)control;
                    if (label.Tag != null && traducciones.ContainsKey(label.Tag.ToString()))
                        label.Text = traducciones[label.Tag.ToString()].texto;

                }

            }
        }
        public GestUsuarios()
        {
            InitializeComponent();
            dataGridView1.DataSource = null;
            traductor = new BLL_Traductor();

            Session._publisherIdioma.Subscribe(this);
            TraducirForm(Session.IdiomaActual);
        }

        BLL_Traductor traductor;
        private void GestUsuarios_Load(object sender, EventArgs e)
        {
            /*IdiomaActual = Session.IdiomaActual;
            Session._publisherIdioma.Subscribe(this);*/
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = new BLL_User().GetAll();
            List<Componente> componentes = new BLL_Permisos().GetAllComponentes();
            dataGridView2.DataSource = componentes;
            
        }

        private void btnDarPermisos_Click(object sender, EventArgs e)
        {
            
            try
            {
                if(dataGridView2.CurrentRow.DataBoundItem == null || dataGridView1.CurrentRow.DataBoundItem == null)
                {
                    MessageBox.Show("Debe seleccionar item");
                    return;
                }

                Componente seleccionado = (Componente)dataGridView2.CurrentRow.DataBoundItem;
                User user = (User)dataGridView1.CurrentRow.DataBoundItem;


                if (new BLL_User().AgregarPermiso(seleccionado, user))
                {
                    MessageBox.Show("Se agrego permiso correctamente");
                }else
                {
                    MessageBox.Show("Ocurrio un error al agregar permiso");
                }
            }catch(Exception)
            {
                throw;
            }
        }

        private void btnSacarPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                User user = (User)dataGridView1.CurrentRow.DataBoundItem;
                Componente permiso = (Componente)dataGridView3.CurrentRow.DataBoundItem;

                new BLL_Permisos().SacarPermisoUser(user, permiso);

                MessageBox.Show("El permiso se removio correctamente");

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataGridView3.DataSource = null;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                if (dataGridView1.CurrentRow.DataBoundItem == null) MessageBox.Show("Seleccione un usuario");
                var user = (User)dataGridView1.CurrentRow.DataBoundItem;
                txtNombre.Text = user.Nombre.ToString();
                txtApellido.Text = user.Apellido.ToString();
                txtDNI.Text = user.DNI.ToString();
                List<Familia> permisosUser = new BLL_Permisos().GetPermisosUser(user);


                dataGridView3.DataSource = null;
                dataGridView3.DataSource = permisosUser;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var user = (User)dataGridView1.CurrentRow.DataBoundItem;
           
            if (new BLL_User().Delete(user))
            {
                MessageBox.Show("El usuario se elimino correctamente");
            }
            else {
                MessageBox.Show("Ocurrio un error al eliminar el usuario");
            }
        }

        public void Notify(Idioma idioma)
        {
            TraducirForm(idioma);
        }


    }
}
