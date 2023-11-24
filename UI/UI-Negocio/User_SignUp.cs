using BE;
using BLL;
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
using Services.Multilanguage;
using Services.SecurityAndValidation;

namespace UI.UI_Negocio
{
    public partial class User_SignUp : Form
    {
        BLL_Traductor traductor;

        private void TraducirForm(IIdioma idioma = null)
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

        public User_SignUp()
        {
            InitializeComponent();

            dtNacimiento.MaxDate = DateTime.Now;

            traductor = new BLL_Traductor();
            cmbIdiomas.DataSource = traductor.ObtenerIdiomas();
            cmbIdiomas.DisplayMember = "nombre";
            cmbIdiomas.ValueMember = "Id";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            User usuario = new User();


            try
            {
                #region(ErrorProvider)
                errorProvider1.Clear();
                errorProvider1.SetError(txtNombreSign, "");
                errorProvider1.SetError(txtApellidoSign, "");
                errorProvider1.SetError(txtDniSign, "");
                errorProvider1.SetError(txtClaveSign, "");
                errorProvider1.SetError(txtTelefono, "");
                errorProvider1.SetError(txtEmail, "");
                errorProvider1.SetError(dtNacimiento, "");

                bool errorFlag = false;
                if (!RegexValidation.validarNombre(txtNombreSign.Text))
                {
                    errorFlag = true;
                    errorProvider1.SetError(txtNombreSign, "El campo es obligatorio");
                }
                if (!RegexValidation.validarNombre(txtApellidoSign.Text))
                {
                    errorFlag = true;
                    errorProvider1.SetError(txtApellidoSign, "El campo es obligatorio");
                }
                if (!RegexValidation.validarDni(txtDniSign.Text))
                {
                    errorFlag = true;
                    errorProvider1.SetError(txtDniSign, "El campo es obligatorio");
                }
                if (!RegexValidation.validarPassword(txtClaveSign.Text))
                {
                    errorFlag = true;
                    errorProvider1.SetError(txtClaveSign, "El campo es obligatorio");
                }
                if (!RegexValidation.validarTelefono(txtTelefono.Text))
                {
                    errorFlag = true;
                    errorProvider1.SetError(txtTelefono, "El campo es obligatorio");
                }
                if (!RegexValidation.validarEmail(txtEmail.Text))
                {
                    errorFlag = true;
                    errorProvider1.SetError(txtEmail, "El campo es obligatorio");
                }
                if (dtNacimiento.Value == null)
                {
                    errorFlag = true;
                    errorProvider1.SetError(dtNacimiento, "El campo es obligatorio");
                }
                #endregion

                if (!errorFlag)
                {
                    //registro al usuario

                    usuario.Nombre = txtNombreSign.Text;
                    usuario.Apellido = txtApellidoSign.Text;
                    usuario.DNI = Convert.ToInt32(txtDniSign.Text);
                    usuario.Clave = txtClaveSign.Text;
                    usuario.Telefono = txtTelefono.Text;
                    usuario.Email = txtEmail.Text;
                    usuario.FechaNacimiento = dtNacimiento.Value;

                    BLL_User _User = new BLL_User();
                    _User.Register(usuario);

                    
                    User_Menu menu = new User_Menu();
                    this.Hide();
                    menu.Show();
                    
                    
                }

            }
            catch (Exception ex)
            {
                /*var bitacora = new Bitacora();
                bitacora.Detalle = ex.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);*/
                MessageBox.Show(ex.Message);
            }
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        public bool ojoLog;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (ojoLog == true)
            {
                txtClaveSign.UseSystemPasswordChar = true;
                ojoLog = false;
            }
            else if (ojoLog == false)
            {
                txtClaveSign.UseSystemPasswordChar = false;
                ojoLog = true;
            }
        }

        private void cmbIdiomas_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Idioma idioma = (Idioma)cmbIdiomas.SelectedItem;
            TraducirForm(idioma);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart();
        }
    }
}
