using ABS;
using BE;
using BLL;
using Services;
using Services.Multilanguage;
using System;
using System.Collections;
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
                foreach (Control control in this.groupBox3.Controls)
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
            List<Traduccion> lista = new List<Traduccion>();

            try
            {
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

            return lista;
        }

        public FormAgregarIdioma()
        {
            InitializeComponent();
            this.Size = new Size(392,569);
            groupBox3.Location = new Point(8, 46);
            groupBox3.Visible = false;
            groupBox3.Enabled = false;

            traductor = new BLL_Traductor();
            comboBox1.DataSource = traductor.ObtenerIdiomas();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
            TraducirForm(Session.IdiomaActual);

            rbAgregar.Checked = true;
        }

        BLL_Traductor traductor;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (new RegexValidation().validarNombre(textBox1.Text))
                {
                    rbAgregar.Enabled = false;
                    rbModificar.Enabled = false;
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

                MessageBox.Show(ex.Message);
            }


        }

        private void FormAgregarIdioma_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {

                /*foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if(row.Cells[2].Value != null || row.Cells[3].Value.ToString() != "")
                    {
                        completo = true;
                    }
                    else { completo = false; break; }

                }*/
                if (rbAgregar.Checked == true)
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
                else if (rbModificar.Checked == true)
                {
                    Idioma IdiomaAux = (Idioma)comboBox1.SelectedItem;
                    traductor.UpdateTraducciones(TraerListDGV(), IdiomaAux);

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

                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem != null)
                {
                    Idioma idiom = (Idioma)comboBox1.SelectedItem;
                    rbAgregar.Enabled = false;
                    rbModificar.Enabled = false;
                    groupBox3.Enabled = false;

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = traductor.GetAllTerminosDTO(idiom);
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

                MessageBox.Show(ex.Message);
            }

        }

        public void Notify(Idioma idioma)
        {
            TraducirForm(idioma);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void rbAgregar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgregar.Checked)
            {
                groupBox1.Enabled = true;
                groupBox1.Visible = true;
                groupBox3.Visible = false;
                groupBox3.Enabled = false;

            }
            
        }

        private void rbModificar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbModificar.Checked)
            {
                groupBox3.Visible = true;
                groupBox3.Enabled = true;
                groupBox1.Enabled = false;
                groupBox1.Visible = false;
            }
            
        }

        
    }
}
