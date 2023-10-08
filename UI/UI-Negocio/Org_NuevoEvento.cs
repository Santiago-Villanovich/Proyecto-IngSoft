﻿using BE;
using BLL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.UI_Negocio
{
    public partial class Org_NuevoEvento : Form
    {
        List<Categoria> categorias;
        Evento evento;
        BLL_Evento bllEvento;

        private bool ValidarNomCategoria(string nom)
        {
            if (nom != null && nom != string.Empty)
            {
                if (categorias.Count > 0)
                {
                    foreach (Categoria c in categorias)
                    {
                        if (c.Nombre == nom)
                        {
                            return false;
                        }
                    }

                    return true;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public Org_NuevoEvento()
        {
            InitializeComponent();

            categorias = new List<Categoria>();
            bllEvento = new BLL_Evento();


            cboxEstilo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboxEstilo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboxEstilo.DataSource = Enum.GetValues(typeof(Estilos));

            dateTimePicker1.MinDate = DateTime.Now;

            txtMetros.Visible = false;
            txtTiempo.Visible = false;
        }

        private void Org_NuevoEvento_Load(object sender, EventArgs e)
        {
            txtCategoria.Text = string.Empty;

            cboxPileta.DataSource = null;
            cboxPileta.DataSource = new BLL_Pileta().GetAll();
            cboxPileta.ValueMember = "id";
            cboxPileta.DisplayMember = "direccion";

            if (Session.GetInstance.Usuario.Organizacion != null)
            {
                cboxPileta.Enabled = false;
                cboxPileta.SelectedValue = Session.GetInstance.Usuario.Organizacion.PiletaAsociada.id;
            }

            listboxCategorias.DataSource = null;
            listboxCategorias.DisplayMember = "str";
            listboxCategorias.ValueMember = "nombre";
            if (categorias.Count > 0)
            {
                listboxCategorias.DataSource = categorias;
            }
        }

        private void btnAgregarCat_Click(object sender, EventArgs e)
        {
            try
            {
                if(ValidarNomCategoria(txtCategoria.Text))
                {
                    categorias.Add(
                    new Categoria(
                        txtCategoria.Text,
                        Convert.ToInt32(numupEdadMin.Value),
                        Convert.ToInt32(numupEdadMax.Value)
                    ));

                    numupEdadMin.Minimum = numupEdadMax.Value + 1;
                    numupEdadMin.Enabled = false;

                    this.OnLoad(null);
                }
                
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void numupEdadMin_ValueChanged(object sender, EventArgs e)
        {
            
            numupEdadMax.Minimum = numupEdadMin.Value + 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (categorias.Count > 0)
                {
                    
                    categorias.RemoveAt(categorias.Count - 1);

                    if (categorias.Count == 0)
                    {
                        numupEdadMin.Enabled = true;
                        numupEdadMin.Minimum= 0;
                        numupEdadMin.Value = 0;
                    }
                    else
                    {
                        var aux = categorias.Last();
                        numupEdadMin.Minimum = aux.EdadFin;
                        numupEdadMin.Value = aux.EdadFin;
                    }


                    this.OnLoad(null);
                }
                else
                {
                    MessageBox.Show("Debe ingresar un nombre de categoria valido");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {
            try
            {
                #region(ErrorProvider)
                errorProvider1.Clear();
                errorProvider1.SetError(richtextDetalleEvento, "");
                errorProvider1.SetError(cboxPileta, "");
                errorProvider1.SetError(txtTiempo, "");
                errorProvider1.SetError(txtMetros, "");
                errorProvider1.SetError(numupCupos, "");

                bool errorFlag = false;

                if (richtextDetalleEvento.Text == string.Empty)
                {
                    errorProvider1.SetError(richtextDetalleEvento, "Debe escribir una descripcion");
                    errorFlag = true;
                }
                if (cboxPileta.SelectedItem == null)
                {
                    errorProvider1.SetError(cboxPileta, "Debe seleccionar una pileta para el evento");
                    errorFlag = true;
                }
                if (rbNataTiempo.Checked == true && !RegexValidation.validarNum(txtTiempo.Text))
                {
                    errorProvider1.SetError(txtTiempo, "Debe definir los minutos totales");
                    errorFlag = true;
                }
                if (rbNataMetros.Checked == true && !RegexValidation.validarNum(txtMetros.Text))
                {
                    errorProvider1.SetError(txtMetros, "Debe definir los metros totales");
                    errorFlag = true;
                }
                if (numupCupos.Value == 0)
                {
                    errorProvider1.SetError(numupCupos, "Debe definir el total de cupos");
                    errorFlag = true;
                }
                if (categorias.Count == 0)
                {
                    errorFlag = true;
                    MessageBox.Show("Debe definir las categorias para publicar un evento");
                    return;
                }

                #endregion
                
                if (!errorFlag)
                {
                    evento = new Evento();
                    evento.Organizacion = Session.GetInstance.Usuario.Organizacion;
                    evento.Descripcion = richtextDetalleEvento.Text;
                    evento.Fecha = dateTimePicker1.Value;
                    evento.ValorInscripcion = Convert.ToDouble(numupCoste.Value);
                    evento.Categorias = categorias;
                    evento.cupo = Convert.ToInt32(numupCupos.Value);


                    if (rbNataMetros.Checked)
                    {
                        Natacion_PostaMetros postaM = new Natacion_PostaMetros()
                        {
                            MetrosTotales = Convert.ToInt32(txtMetros.Text),
                            Estilo = cboxEstilo.Text,
                            Elementos = checkElementos.Checked,
                            Pileta = (Pileta)cboxPileta.SelectedItem,
                            cantidad_integrantes_equipo =Convert.ToInt32(numupParticipantes.Value)
                        };

                        postaM.id_deporte = new BLL_DeporteNatacion().InsertPostaMetros(postaM);
                        evento.Deporte = postaM;

                    }
                    else if (rbNataTiempo.Checked)
                    {
                        Natacion_PostaTiempo postaT = new Natacion_PostaTiempo()
                        {
                            TiempoTotal = Convert.ToInt32(txtTiempo.Text),
                            Estilo = cboxEstilo.Text,
                            Elementos = checkElementos.Checked,
                            Pileta = (Pileta)cboxPileta.SelectedItem,
                            cantidad_integrantes_equipo = Convert.ToInt32(numupParticipantes.Value)
                        };

                        postaT.id_deporte = new BLL_DeporteNatacion().InsertPostaTiempo(postaT);
                        evento.Deporte = postaT;
                    }

                    if (bllEvento.Insert(evento))
                    {
                        MessageBox.Show("Se registro el evento exitosamente, podra verlo en el apartado de 'Eventos Programados' ");
                    }
                    
                }
                else
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void rbNataTiempo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNataTiempo.Checked)
            {
                txtTiempo.Visible = true;
                txtTiempo.Enabled = true;
            }
            else
            {
                txtTiempo.Visible = false;
                txtTiempo.Enabled = false;
            }
        }

        private void rbNataMetros_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNataMetros.Checked)
            {
                txtMetros.Visible = true;
                txtMetros.Enabled = true;
            }
            else
            {
                txtMetros.Visible = false;
                txtMetros.Enabled = false;
            }
        }
    }
}
