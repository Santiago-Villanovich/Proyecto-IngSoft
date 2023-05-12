﻿using BE;
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

namespace UI
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            Size = new Size(354, 472);
        }

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

                    var session = Session.GetInstance;
                    if (session.Usuario.isAdmin)
                    {
                        MenuAdmin menu = new MenuAdmin();
                        this.Hide();
                        menu.Show();
                    }
                    else if (!session.Usuario.isAdmin)
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
                if (re.validarNombre(txtNombreSign.Text))
                {
                    errorFlag = true;
                    errorProvider1.SetError(txtNombreSign, "El campo es obligatorio");
                }
                if (re.validarNombre(txtApellidoSign.Text))
                {
                    errorFlag = true;
                    errorProvider1.SetError(txtApellidoSign, "El campo es obligatorio");
                }
                if (re.validarDni(txtDniSign.Text))
                {
                    errorFlag = true;
                    errorProvider1.SetError(txtDniSign, "El campo es obligatorio");
                }
                if (re.validarPassword(txtClaveSign.Text))
                {
                    errorFlag = true;
                    errorProvider1.SetError(txtClaveSign, "El campo es obligatorio");
                }
                #endregion

                if (errorFlag)
                {
                    //registro al usuario

                    usuario.Nombre = txtNombreSign.Text;
                    usuario.Apellido = txtApellidoSign.Text;
                    usuario.DNI = Convert.ToInt32(txtDniSign.Text);
                    usuario.Clave = txtClaveSign.Text;
                    usuario.isAdmin = false;

                    BLL_User _User = new BLL_User();
                    _User.Register(usuario);

                    //genero el login

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

                MessageBox.Show(ex.Message);
            }
        }

        public bool ojoSign;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (ojoSign == true)
            {
                txtClaveLog.UseSystemPasswordChar = true;
                ojoSign = false;
            }
            else if (ojoSign == false)
            {
                txtClaveLog.UseSystemPasswordChar = false;
                ojoSign = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
