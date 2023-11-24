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
using UI.UI_Negocio;
using UI.UI_Sistema;

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

        }

        public LogIn()
        {
            InitializeComponent();

            traductor = new BLL_Traductor();
            cmbIdiomas.DataSource = traductor.ObtenerIdiomas();
            cmbIdiomas.DisplayMember = "nombre";
            cmbIdiomas.ValueMember = "Id";
            
        }


        BLL_Traductor traductor;

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                #region(ErrorProvider)
                errorProvider1.Clear();
                errorProvider1.SetError(txtDniLog, "");
                errorProvider1.SetError(txtClaveLog, "");
                bool errorFlag = false;

                if (!RegexValidation.validarDni(txtDniLog.Text))
                {
                    errorFlag = true;
                    errorProvider1.SetError(txtDniLog, "Valor ingresado incorrecto");
                }
                if (!RegexValidation.validarPassword(txtClaveLog.Text))
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


                        if (Session.tiene_permiso(1035))
                        {
                            MenuAdmin2 menu = new MenuAdmin2();
                            this.Hide();
                            menu.Show(); 
                        }
                        else if (Session.tiene_permiso(1036))
                        {
                            User_Menu menu = new User_Menu();
                            this.Hide();
                            menu.Show();
                        }
                        else if (Session.tiene_permiso(1039))
                        {
                            Session.GetInstance.Usuario.Organizacion = new BLL_User().GetUserOrg(Session.GetInstance.Usuario.Id);
                            
                            Org_Menu menu = new Org_Menu();
                            this.Hide();
                            menu.Show();
                        }


                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                /*var bitacora = new Bitacora();
                bitacora.Detalle = ex.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
                MessageBox.Show(ex.Message);*/
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_SignUp form = new User_SignUp();
            form.ShowDialog();
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

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void cmbIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Idioma idioma = (Idioma)cmbIdiomas.SelectedItem;
            TraducirForm(idioma);
        }

        #region(button hover)
        private void btnIngresar_MouseEnter(object sender, EventArgs e)
        {
            btnIngresar.BackColor = Color.FromArgb(236, 125, 24);
            btnIngresar.ForeColor = Color.FromArgb(235, 231, 222);
            btnIngresar.FlatAppearance.BorderColor = Color.FromArgb(236, 125, 24);
        }

        private void btnIngresar_MouseLeave(object sender, EventArgs e)
        {
            btnIngresar.BackColor = Color.FromArgb(45, 48, 71);
            btnIngresar.ForeColor = Color.FromArgb(236, 125, 24);
            btnIngresar.FlatAppearance.BorderColor = Color.FromArgb(236, 125, 24);
        }
        #endregion
    }
}
