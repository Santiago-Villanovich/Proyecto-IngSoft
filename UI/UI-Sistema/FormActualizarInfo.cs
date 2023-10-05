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
using Services;
using BE;
using BLL;
using Services.SecurityAndValidation;

namespace UI
{
    public partial class FormActualizarInfo : Form
    {
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
        public FormActualizarInfo()
        {
            InitializeComponent();
            traductor = new BLL_Traductor();
            usuario = new BLL_User();
            bllDV = new BLL_DigitoVerificador();
            TraducirForm(Session.IdiomaActual);
        }

        BLL_Traductor traductor;
        BLL_User usuario;
        BLL_DigitoVerificador bllDV;


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                User userNew = usuario.Get(Session.GetInstance.Usuario.Id);
                DTO_UserHistory userOld = new DTO_UserHistory()
                {
                    Id = userNew.Id,
                    Nombre = userNew.Nombre,
                    Apellido = HashCrypto.Encriptar(userNew.Apellido),
                    DNI = userNew.DNI,
                    Clave = userNew.Clave
                };

                if (RegexValidation.validarNombre(txtNombre.Text))
                {
                    userNew.Nombre = txtNombre.Text;
                }
                if (RegexValidation.validarNombre(txtApellido.Text))
                {
                    userNew.Apellido = txtApellido.Text;
                }
                if (RegexValidation.validarPassword(txtClave.Text))
                {
                    userNew.Clave = new HashCrypto().GenerarMD5(txtClave.Text);
                }

                userNew.Apellido = HashCrypto.Encriptar(userNew.Apellido);
                userNew.DV = GestorDigitoVerificador.CalcularDV(userNew);
                usuario.Update(userNew);

                usuario.InsertUserHistory(userOld);
                bllDV.InsertDVTabla(usuario.GetAll(),"Users");

                MessageBox.Show("Su informacion se actualizo con exito");
                this.Close();

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
    }
}
