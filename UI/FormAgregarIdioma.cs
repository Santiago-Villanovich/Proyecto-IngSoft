using ABS;
using BE;
using BLL;
using Services;
using Services.Multilanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace UI
{
    public partial class FormAgregarIdioma : Form,IObserver
    {
        private void TraducirForm(IIdioma idioma = null)/*IIdioma idioma = null*/
        {
            try
            {
                var traducciones = traductor.ObtenerTraducciones(idioma);

                foreach (Control control in this.groupBox1.Controls)
                {

                    if (control is System.Windows.Forms.Button)
                    {
                        System.Windows.Forms.Button boton = (System.Windows.Forms.Button)control;
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
                foreach (Control control in this.groupBox2.Controls)
                {

                    if (control is System.Windows.Forms.Button)
                    {
                        System.Windows.Forms.Button boton = (System.Windows.Forms.Button)control;
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
                throw;
            }

        }
        public List<Traduccion> TraerListDGV()
        {
            try
            {
                List<Traduccion> lista = new List<Traduccion>();
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {

                    Traduccion traduc = new Traduccion()
                    {
                        texto = dr.Cells["Traduccion"].Value.ToString(),
                        termino = new Termino()
                        {
                            id = Convert.ToInt32(dr.Cells["Id"].Value),
                            termino = dr.Cells["Termino"].Value.ToString()
                        }
                    };

                    lista.Add(traduc);

                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public FormAgregarIdioma()
        {
            InitializeComponent();
            traductor = new BLL_Traductor();

            TraducirForm(Session.IdiomaActual);
        }

        BLL_Traductor traductor;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (new RegexValidation().validarNombre(textBox1.Text))
                {
                    groupBox1.Enabled = false;
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = traductor.GetAllTerminosDTO();
                    dataGridView1.AutoResizeColumns();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[1].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                var bitacora = new Bitacora();
                bitacora.Detalle = ex.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
                throw;
            }


        }

        private void FormAgregarIdioma_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool completo = false;
            try
            {
                
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //if (string.IsNullOrEmpty(row.Cells[2].Value.ToString()))
                    if(row.Cells[2].Value != null || row.Cells[3].Value.ToString() != "")
                    {
                        completo = true;
                    }
                    else { completo = false; break; }

                }

                if (!completo)
                {
                    DialogResult ds = MessageBox.Show(this, "Todas las traducciones deben estar completas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Idioma _idioma = new Idioma()
                    {
                        nombre = textBox1.Text,
                        isDefault = false
                    };
                    traductor.InsertIdioma(_idioma);

                    Idioma IdiomaAux = (Idioma)traductor.GetIdiomaLastAdded();
                    traductor.InsertTraducciones(TraerListDGV(), IdiomaAux);

                    MessageBox.Show("Idioma agregado con exito");
                    this.Close();
                    
                }

            }
            catch (Exception ex)
            {
                var bitacora = new Bitacora();
                bitacora.Detalle = ex.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
                throw;
            }
        }

        public void Notify(Idioma idioma)
        {
            TraducirForm(idioma);
        }
    }
}
