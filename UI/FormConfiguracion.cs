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

        private void TraducirForm(IIdioma idioma = null)/*IIdioma idioma = null*/
        {
            try
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
        public FormConfiguracion()
        {
            InitializeComponent();
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            Session.Logout();
            this.Close();
            Application.Restart();
            //Application.Run(new LogIn());
        }




        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var idioma1 = (Idioma)comboBox1.SelectedItem;

                Session.CambiarIdioma(idioma1);
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

        private void button3_Click(object sender, EventArgs e)
        {
            FormAgregarIdioma formu = new FormAgregarIdioma();
            formu.Show();
        }

        private void btnCambiarClave_Click(object sender, EventArgs e)
        {
            FormActualizarInfo formu = new FormActualizarInfo();
            formu.Show();
        }
    }
}
