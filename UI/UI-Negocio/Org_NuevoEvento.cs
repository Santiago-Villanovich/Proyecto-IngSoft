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

namespace UI.UI_Negocio
{
    public partial class Org_NuevoEvento : Form
    {
        List<Categoria> categorias;
        public RegexValidation re = new RegexValidation();

        public Org_NuevoEvento()
        {
            InitializeComponent();

            categorias = new List<Categoria>();

            lblNombreCat.Text = "1";

            cboxEstilo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboxEstilo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboxEstilo.DataSource = Enum.GetValues(typeof(Estilos));

            dateTimePicker1.MinDate = DateTime.Now;
        }

        private void Org_NuevoEvento_Load(object sender, EventArgs e)
        {
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
                categorias.Add(
                    new Categoria(
                        (categorias.Count+1).ToString(),
                        Convert.ToInt32(numupEdadMin.Value),
                        Convert.ToInt32(numupEdadMax.Value)
                    ));

                numupEdadMin.Minimum = numupEdadMax.Value + 1;
                numupEdadMin.Enabled = false;
                lblNombreCat.Text = (categorias.Count + 1).ToString();

                this.OnLoad(null);
                
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
                    
                    lblNombreCat.Text = (categorias.Count).ToString();
                    categorias.RemoveAt(categorias.Count - 1);

                    if (categorias.Count == 0)
                    {
                        numupEdadMin.Enabled = true;
                        numupEdadMin.Minimum= 0;
                        numupEdadMin.Value = 0;
                        lblNombreCat.Text = (categorias.Count + 1).ToString();
                    }
                    else
                    {
                        var aux = categorias.Last();
                        numupEdadMin.Minimum = aux.EdadFin;
                        numupEdadMin.Value = aux.EdadFin;
                    }


                    this.OnLoad(null);
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

                bool errorFlag = false;

                if (richtextDetalleEvento.Text == string.Empty)
                {
                    errorProvider1.SetError(richtextDetalleEvento, "Debe escribir una descripcion");
                    return;
                }
                if (cboxPileta.SelectedItem == null)
                {
                    errorProvider1.SetError(cboxPileta, "Debe seleccionar una pileta para el evento");
                    return;
                }
                if (rbNataTiempo.Checked == true && txtTiempo)
                {
                    errorProvider1.SetError(cboxPileta, "Debe seleccionar una pileta para el evento");
                    return;
                }

                #endregion

                if (rbNataMetros.Checked)
                {

                }
                else if (rbNataTiempo.Checked)
                {

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
