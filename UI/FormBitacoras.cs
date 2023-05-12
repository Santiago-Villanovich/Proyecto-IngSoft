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
    public partial class FormBitacoras : Form, IObserver
    {
        private string IdiomaActual;
        public FormBitacoras()
        {
            InitializeComponent();
        }

        public void Notify(string idioma)
        {
            IdiomaActual = idioma;
            label1.Text = idioma;
        }

        private void FormBitacoras_Load(object sender, EventArgs e)
        {
            Session._publisherIdioma.Subscribe(this);
            IdiomaActual = Session.IdiomaActual;
            label1.Text = IdiomaActual;
            //var bitacoras = new BLL_Bitacora().GetAllBU();
            //dataGridView1.DataSource = bitacoras;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Session.CambiarIdioma(comboBox1.SelectedItem.ToString());
        }
    }
}
