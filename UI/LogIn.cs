using BE;
using BLL;
using Services;
using Services.Multilanguage;
using Services.SecurityAndValidation;
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
    public partial class LogIn : Form
    {
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

            foreach (Control control in this.groupBox1.Controls)
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

        public LogIn()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            Size = new Size(354, 472);

            traductor = new BLL_Traductor();
            cmbIdiomas.DataSource = traductor.ObtenerIdiomas();
            cmbIdiomas.DisplayMember = "nombre";
            cmbIdiomas.ValueMember = "Id";
            
        }


        BLL_Traductor traductor;
        public RegexValidation re = new RegexValidation();

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                #region(ErrorProvider)
                errorProvider1.Clear();
                errorProvider1.SetError(txtDniLog, "");
                errorProvider1.SetError(txtDniLog, "");
                bool errorFlag = false;

                if (!re.validarDni(txtDniLog.Text))
                {
                    errorFlag = true;
                    errorProvider1.SetError(txtDniLog, "Valor ingresado incorrecto");
                }
                if (!re.validarPassword(txtClaveLog.Text))
                {
                    errorFlag = true;
                    errorProvider1.SetError(txtClaveLog, "Valor ingresado incorrecto");
                }
                #endregion

                if (!errorFlag)
                {
                    new BLL_User().Login(Convert.ToInt32(txtDniLog.Text), txtClaveLog.Text);

                    if (Session.GetInstance == null)
                    {
                       MessageBox.Show(this, "Usuario no registrado, verifique los datos o registrese", "Usuario Invalido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Session.IdiomaActual = (Idioma)cmbIdiomas.SelectedItem;
                        if (Session.tiene_permiso(1))
                        {
                            MenuAdmin menu = new MenuAdmin();
                            this.Hide();
                            menu.Show();
                        }
                        else if (!Session.GetInstance.Usuario.isAdmin)
                        {
                            MenuAdmin menu = new MenuAdmin();
                            this.Hide();
                            menu.Show();
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

        private void label5_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox1.Visible = true;
            Size = new Size(738, 472);
        }

        public bool ojoLog;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ojoLog == true)
            {
                txtClaveLog.UseSystemPasswordChar = true;
                ojoLog = false;
            }
            else if (ojoLog == false)
            {
                txtClaveLog.UseSystemPasswordChar = false;
                ojoLog = true;
            }
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

                bool errorFlag = false;
                if (!re.validarNombre(txtNombreSign.Text))
                {
                    errorFlag = true;
                    errorProvider1.SetError(txtNombreSign, "El campo es obligatorio");
                }
                if (!re.validarNombre(txtApellidoSign.Text))
                {
                    errorFlag = true;
                    errorProvider1.SetError(txtApellidoSign, "El campo es obligatorio");
                }
                if (!re.validarDni(txtDniSign.Text))
                {
                    errorFlag = true;
                    errorProvider1.SetError(txtDniSign, "El campo es obligatorio");
                }
                if (!re.validarPassword(txtClaveSign.Text))
                {
                    errorFlag = true;
                    errorProvider1.SetError(txtClaveSign, "El campo es obligatorio");
                }
                #endregion

                if (!errorFlag)
                {
                    //registro al usuario

                    usuario.Nombre = txtNombreSign.Text;
                    usuario.Apellido = txtApellidoSign.Text;
                    usuario.DNI = Convert.ToInt32(txtDniSign.Text);
                    usuario.Clave = txtClaveSign.Text;
                    usuario.isAdmin = false;

                    BLL_User _User = new BLL_User();

                    _User.Register(usuario);

                    //verifico el login
                    var session = Session.GetInstance;
                    if (session.Usuario != null)
                    {
                        Menu menu = new Menu();
                        this.Hide();
                        menu.Show();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al iniciar sesion");
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

        public bool ojoSign;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (ojoSign == true)
            {
                txtClaveSign.UseSystemPasswordChar = true;
                ojoSign = false;
            }
            else if (ojoSign == false)
            {
                txtClaveSign.UseSystemPasswordChar = false;
                ojoSign = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void cmbIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Idioma idioma = (Idioma)cmbIdiomas.SelectedItem;
            TraducirForm(idioma);
        }
    }
}
