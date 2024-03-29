﻿using BE;
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
        private void LimpiarGroupbox()
        {
            checkboxPileta.Checked = false;
            txtPiletaDir.Text = string.Empty;
            numupPiletaCarril.Value= 0;
            rb20mts.Checked = false;
            rb25mts.Checked = false;
            rb50mts.Checked = false;
        }

        public FormCrearOrg()
        {
            InitializeComponent();
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
                    if (!RegexValidation.validarNombre(txtNombre.Text))
                    {
                        errorFlag = true;
                        errorProvider1.SetError(txtNombre, "El campo es obligatorio");
                    }
                    if (!RegexValidation.validarCUIT(txtCuit.Text))
                    {
                        errorFlag = true;
                        errorProvider1.SetError(txtCuit, "El campo es obligatorio");
                    }
                    if (!RegexValidation.validarEmail(txtEmail.Text))
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
            try
            {
                Organizacion = (Organizacion)dataGridView1.CurrentRow.DataBoundItem;
                txtNombre.Text = Organizacion.Nombre;
                txtEmail.Text = Organizacion.Email;
                txtDireccionweb.Text = Organizacion.DireccionWeb;
                txtCuit.Text = Organizacion.CUIT;
                if (Organizacion.PiletaAsociada != null)
                {
                    checkboxPileta.Enabled = true;
                    checkboxPileta.Checked = true;
                    txtPiletaDir.Text = Organizacion.PiletaAsociada.Direccion;
                    numupPiletaCarril.Value = Convert.ToDecimal(Organizacion.PiletaAsociada.Carriles);
                    switch (Organizacion.PiletaAsociada.Metros)
                    {
                        case 20: rb20mts.Checked = true; break;
                        case 25: rb25mts.Checked = true; break;
                        case 50: rb50mts.Checked = true; break;
                        default:
                            break;
                    }

                    groupBox1.Enabled = false;
                }
                else
                {
                    LimpiarGroupbox();
                    checkboxPileta.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            LimpiarGroupbox();
            checkboxPileta.Enabled = true;
        }

        private void checkboxPileta_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxPileta.Checked)
            {
                groupBox1.Visible = true;
                if (Organizacion != null)
                {
                    if (Organizacion.PiletaAsociada != null)
                    {
                        groupBox1.Enabled = false;
                    }
                }
                else
                {
                    groupBox1.Enabled = true;
                }
                
            }
            else
            {
                groupBox1.Visible = false;
                groupBox1.Enabled = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
