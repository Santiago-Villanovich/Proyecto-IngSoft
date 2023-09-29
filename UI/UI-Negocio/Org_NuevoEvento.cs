using BE;
using BLL;
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

        public Org_NuevoEvento()
        {
            InitializeComponent();

            categorias = new List<Categoria>();

            lblNombreCat.Text = "1";

            cboxEstilo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboxEstilo.AutoCompleteSource = AutoCompleteSource.ListItems;

            //cboxEstilo.DataSource = bllUsr.GetAll();
            cboxEstilo.ValueMember = "Id";
            cboxEstilo.DisplayMember = "NombreApellido";

        }

        private void Org_NuevoEvento_Load(object sender, EventArgs e)
        {
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
    }
}
