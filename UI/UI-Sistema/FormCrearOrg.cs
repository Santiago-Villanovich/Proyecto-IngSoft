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
using System.Linq.Expressions;

namespace UI.UI_Sistema
{
    public partial class FormCrearOrg : Form
    {
        Organizacion Organizacion;
        RegexValidation re;
        BLL_Org bllOrg;
        
        private void LimpiarControles()
        {
            Organizacion = null;
            txtNombre.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDireccionweb.Text = string.Empty;
            txtCuit.Text = string.Empty;
            dataGridView1.CurrentRow.Selected = false;
        }

        public FormCrearOrg()
        {
            InitializeComponent();
            re = new RegexValidation();
            bllOrg = new BLL_Org();
            Organizacion = null;

            groupBox1.Enabled = false;
            groupBox1.Visible = false;

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
                    errorProvider1.SetError(txtPiletaDir, "");
                    errorProvider1.SetError(numupPiletaCarril, "");


                    bool errorFlag = false;
                    if (!re.validarNombre(txtNombre.Text))
                    {
                        errorFlag = true;
                        errorProvider1.SetError(txtNombre, "El campo es obligatorio");
                    }
                    if (!re.validarCUIT(txtCuit.Text))
                    {
                        errorFlag = true;
                        errorProvider1.SetError(txtCuit, "El campo es obligatorio");
                    }
                    if (!re.validarEmail(txtEmail.Text))
                    {
                        errorFlag = true;
                        errorProvider1.SetError(txtEmail, "El campo es obligatorio");
                    }
                    if (txtDireccionweb.Text == string.Empty) 
                    {
                        errorFlag = true;
                    }
                    if (checkboxPileta.Checked)
                    {
                        if (txtPiletaDir.Text == string.Empty)
                        {
                            errorFlag = true;
                            errorProvider1.SetError(txtPiletaDir, "El campo es obligatorio");
                        }
                        if (numupPiletaCarril.Value > 0)
                        {
                            errorFlag = true;
                        }
                        if (!rb20mts.Checked && !rb25mts.Checked && !rb50mts.Checked)
                        {
                            errorFlag = true;
                            MessageBox.Show("Debe seleccionar el tamaño de la pileta");
                        }
                    }

                    #endregion

                    if (!errorFlag)
                    {
                        Organizacion Org = new Organizacion(txtCuit.Text, txtNombre.Text, txtEmail.Text, txtDireccionweb.Text);
                        Org.PiletaAsociada = null;

                        if (checkboxPileta.Checked) 
                        {
                            Pileta pil = new Pileta();
                            pil.Direccion = txtPiletaDir.Text;
                            pil.Carriles = Convert.ToInt32(numupPiletaCarril.Value);
                            if (rb20mts.Checked)
                            {
                                pil.Metros = 20;
                            }
                            else if (rb25mts.Checked)
                            {
                                pil.Metros = 25;
                            }
                            else
                            {
                                pil.Metros = 50;
                            }

                            Org.PiletaAsociada = pil;
                        }
                        

                        bllOrg.Insert(Org);

                        LimpiarControles();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void FormCrearOrg_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bllOrg.GetAll();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Organizacion = (Organizacion)dataGridView1.CurrentRow.DataBoundItem;
            txtNombre.Text = Organizacion.Nombre;
            txtEmail.Text = Organizacion.Email;
            txtDireccionweb.Text = Organizacion.DireccionWeb;
            txtCuit.Text = Organizacion.CUIT;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }
    }
}
