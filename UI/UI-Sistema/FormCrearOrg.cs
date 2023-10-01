using BE;
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
using BLL;

namespace UI.UI_Sistema
{
    public partial class FormCrearOrg : Form
    {
        Organizacion Organizacion;
        RegexValidation re;
        BLL_Org bllOrg;
        

        public FormCrearOrg()
        {
            InitializeComponent();
            re = new RegexValidation();
            bllOrg = new BLL_Org();

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Organizacion == null)
                {
                    #region(ErrorProvider)
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtNombre, "");
                    errorProvider1.SetError(txtCuit, "");
                    errorProvider1.SetError(txtDireccionweb, "");
                    errorProvider1.SetError(txtEmail, "");

                    bool errorFlag = false;
                    if (!re.validarNombre(txtNombre.Text))
                    {
                        errorFlag = true;
                        errorProvider1.SetError(txtNombre, "El campo es obligatorio");
                    }
                    if (!re.validarNombre(txtCuit.Text))
                    {
                        errorFlag = true;
                        errorProvider1.SetError(txtCuit, "El campo es obligatorio");
                    }
                    if (!re.validarDni(txtEmail.Text))
                    {
                        errorFlag = true;
                        errorProvider1.SetError(txtEmail, "El campo es obligatorio");
                    }

                    #endregion

                    if (!errorFlag)
                    {
                        Organizacion Org = new Organizacion(txtCuit.Text, txtNombre.Text, txtEmail.Text, txtDireccionweb.Text);
                        bllOrg.Insert(Org);

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
