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

namespace UI
{
    public partial class FormBitacoras : Form
    {
        public FormBitacoras()
        {
            InitializeComponent();
        }

        private void FormBitacoras_Load(object sender, EventArgs e)
        {
            var bitacoras = new BLL_Bitacora().GetAllBU();
            dataGridView1.DataSource = bitacoras;
        }
    }
}
