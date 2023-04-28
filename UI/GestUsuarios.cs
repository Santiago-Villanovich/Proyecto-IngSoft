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
    public partial class GestUsuarios : Form
    {
        public GestUsuarios()
        {
            InitializeComponent();
            dataGridView1.DataSource = null;
        }

        private void GestUsuarios_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = new BLLuser().GetAll();
        }

        private void btnDarPermisos_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
        }

        private void btnSacarPermisos_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
