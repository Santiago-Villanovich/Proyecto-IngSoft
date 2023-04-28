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

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                new BLLuser().Login(Convert.ToInt32(txtDniLog.Text), txtClaveLog.Text);
                var session = Session.GetInstance;
                if (session.Usuario != null)
                {
                    MenuAdmin menu = new MenuAdmin();
                    this.Hide();
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al iniciar sesion");
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
            RegexValidation re = new RegexValidation();

            try
            {
                //registro al usuario
                if (re.validarNombre(txtNombreSign.Text) && re.validarNombre(txtApellidoSign.Text) && re.validarDni(txtDniSign.Text) && re.validarPassword(txtClaveSign.Text))
                {
                    usuario.Nombre = txtNombreSign.Text;
                    usuario.Apellido = txtApellidoSign.Text;
                    usuario.DNI = Convert.ToInt32(txtDniSign.Text);
                    usuario.Clave = txtClaveSign.Text;
                }
                else
                {
                    MessageBox.Show("Error");
                }

                BLLuser _User = new BLLuser();
                _User.Insert(usuario);

                //genero el login
                new BLLuser().Login(Convert.ToInt32(txtDniSign.Text), txtClaveSign.Text);
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

        
    }
}
