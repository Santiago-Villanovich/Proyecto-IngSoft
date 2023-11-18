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
using BLL;
using Services.Multilanguage;
using BE;

namespace UI
{
    public partial class FormConfiguracion : Form, IObserver
    {
        private Idioma IdiomaActual { get; set; }

        public void Notify(Idioma idioma)
        {
            TraducirForm(idioma);
        }

        private void TraducirForm(IIdioma idioma = null)
        {
            try
            {
                var traducciones = traductor.ObtenerTraducciones(idioma);

                foreach (Control control in this.panel1.Controls)
                {

                    if (control.Tag != null && traducciones.ContainsKey(control.Tag.ToString()))
                        control.Text = traducciones[control.Tag.ToString()].texto;

                }
                foreach (Control control in this.panelContenedor.Controls)
                {

                    if (control.Tag != null && traducciones.ContainsKey(control.Tag.ToString()))
                        control.Text = traducciones[control.Tag.ToString()].texto;

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
        private void CargarMenuContenedor(object formHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }
            Form frm = formHijo as Form;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(frm);
            this.panelContenedor.Tag = frm;
            frm.Show();
        }

        public FormConfiguracion()
        {
            InitializeComponent();
            this.MinimumSize = new Size(750,600);
            this.Size = new Size(750, 600);
            traductor = new BLL_Traductor();
            TraducirForm(Session.IdiomaActual);
        }
        
        BLL_Traductor traductor;
        private void FormConfiguracion_Load(object sender, EventArgs e)
        {
            try
            {
                Session._publisherIdioma.Subscribe(this);
                IdiomaActual = Session.IdiomaActual;

                comboBox1.DataSource = traductor.ObtenerIdiomas();
                comboBox1.ValueMember = "Id";
                comboBox1.DisplayMember = "nombre";
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var idioma1 = (Idioma)comboBox1.SelectedItem;
                Session.CambiarIdioma(idioma1);
                TraducirForm(idioma1);
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

        private void btnCambiarClave_Click(object sender, EventArgs e)
        {
            CargarMenuContenedor(new FormActualizarInfo());
        }
    }
}
