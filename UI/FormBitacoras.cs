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
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class FormBitacoras : Form, IObserver
    {
        public void InitializeComboBoxs()
        {
            cboxUsuario.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboxUsuario.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboxTipo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboxTipo.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboxUsuario.DataSource = bllUsr.GetAll();
            cboxUsuario.ValueMember = "Id";
            cboxUsuario.DisplayMember = "NombreApellido";

            cboxTipo.DataSource = bllBit.GetAllBT();
            cboxTipo.ValueMember = "Id";
            cboxTipo.DisplayMember = "Descripcion";

            cboxUsuario.SelectedItem = null;
            cboxTipo.SelectedItem = null;
        }
        public void InitializeDTPicker()
        {
            dtDesde.MinDate = new DateTime(2023, 1, 1);
            dtDesde.Checked = false;
            dtHasta.MinDate = new DateTime(2023, 1, 1);
            dtHasta.Checked = false;
        }

        public FormBitacoras()
        {
            InitializeComponent();
            bllBit = new BLL_Bitacora();
            bllUsr = new BLL_User();

            InitializeComboBoxs();
            InitializeDTPicker();

            //dataGridView1.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            pageNumber = 1;
        }

        BLL_Bitacora bllBit;
        BLL_User bllUsr;
        private Idioma IdiomaActual;
        private int pageNumber;


        public void Notify(Idioma idioma)
        {
            IdiomaActual = idioma;
        }

        private void FormBitacoras_Load(object sender, EventArgs e)
        {
            Session._publisherIdioma.Subscribe(this);
            IdiomaActual = Session.IdiomaActual;
        }


        DateTime? fromDate = null;
        DateTime? toDate = null;
        int? usr = null;
        int? type = null;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (dtDesde.Checked)
                {
                    fromDate = dtDesde.Value;
                }

                if (dtHasta.Checked)
                {
                    toDate = dtHasta.Value;
                }
                
                if (cboxUsuario.SelectedItem != null)
                {
                    User aux = (User)cboxUsuario.SelectedItem;
                    usr = aux.Id;
                }

                if (cboxTipo.SelectedItem != null)
                {
                    BitacoraTipo aux = (BitacoraTipo)cboxTipo.SelectedItem;
                    type = aux.Id;
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bllBit.GetAllBU(usr,fromDate,toDate,type,pageNumber);
                lblPageNumber.Text = pageNumber.ToString();
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            pageNumber++;
            lblPageNumber.Text = pageNumber.ToString();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bllBit.GetAllBU(usr, fromDate, toDate, type, pageNumber);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (pageNumber>1)
            {
                pageNumber--;
                lblPageNumber.Text = pageNumber.ToString();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bllBit.GetAllBU(usr, fromDate, toDate, type, pageNumber);
            }
            
        }
    }
}
