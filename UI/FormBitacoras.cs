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

namespace UI
{
    public partial class FormBitacoras : Form, IObserver
    {
        private Idioma IdiomaActual;
        public FormBitacoras()
        {
            InitializeComponent();
        }

        public void Notify(Idioma idioma)
        {
            IdiomaActual = idioma;
        }

        private void FormBitacoras_Load(object sender, EventArgs e)
        {
            Session._publisherIdioma.Subscribe(this);
            IdiomaActual = Session.IdiomaActual;
            var bitacoras = new BLL_Bitacora().GetAllBU();
            dataGridView1.DataSource = bitacoras;
        }

    }
}
