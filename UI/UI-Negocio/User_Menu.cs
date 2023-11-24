using BE;
using Services;
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
using BLL;
using Services.Multilanguage;

namespace UI
{
    public partial class User_Menu : Form, IObserver
    {
        BLL_Traductor traductor;

        public User_Menu()
        {
            InitializeComponent();
            traductor = new BLL_Traductor();
            Session._publisherIdioma.Subscribe(this);
            CargarMenuContenedor(new User_Inicio());
            TraducirForm(Session.IdiomaActual);
        }

        public void Notify(Idioma idioma)
        {
            TraducirForm(idioma);
        }

        private void TraducirForm(IIdioma idioma = null)
        {
            try
            {
                var traducciones = traductor.ObtenerTraducciones(idioma);

                foreach (Control control in this.NavBar.Controls)
                {

                    if (control.Tag != null && traducciones.ContainsKey(control.Tag.ToString()))
                        control.Text = traducciones[control.Tag.ToString()].texto;

                    if (control is System.Windows.Forms.GroupBox)
                    {
                        foreach (Control cont in control.Controls)
                        {
                            if (cont.Tag != null && traducciones.ContainsKey(cont.Tag.ToString()))
                                cont.Text = traducciones[cont.Tag.ToString()].texto;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                var bitacora = new Bitacora();
                bitacora.Detalle = ex.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);

                MessageBox.Show(ex.Message);
            }
        }

        private void MenuUser_Load(object sender, EventArgs e)
        {
            
        }

        private void CargarMenuContenedor(object formHijo)
        {
            if (this.PanelContenedor.Controls.Count > 0)
            {
                Session._publisherIdioma.Unsuscribe((IObserver)PanelContenedor.Controls[0].Tag);
                this.PanelContenedor.Controls.RemoveAt(0);
            }

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
            CargarMenuContenedor(new User_Desempenio());
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CargarMenuContenedor(new User_Inicio());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormConfiguracion form = new FormConfiguracion();
            form.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Session.Logout();
            this.Close();
            Application.Restart();
        }

        private void btnBuscarEvento_Click(object sender, EventArgs e)
        {
            CargarMenuContenedor(new User_BuscarEvento());
        }

        private void NavBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
