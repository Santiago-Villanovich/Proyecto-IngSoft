using ABS;
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
    public partial class FormAgregarIdioma : Form
    {
        public List<Traduccion> TraerListDGV()
        {
            List<Traduccion> lista = new List<Traduccion>();
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells[3].Value != null || dr.Cells[3].Value.ToString() != "")
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
                else
                {
                    MessageBox.Show("ERROR");
                    return null;
                }
            }

            return lista;
        }

        public FormAgregarIdioma()
        {
            InitializeComponent();
            traductor = new BLL_Traductor();
        }

        BLL_Traductor traductor;

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            dataGridView1.DataSource = null;
            List<Traduccion> lista = traductor.GetAllTerminos();

            var usuariosgrid = lista.Select(u => new { Id = u.termino.id, Termino = u.termino.termino, Traduccion = u.texto });
            dataGridView1.DataSource = usuariosgrid.ToList();

            foreach (DataGridViewColumn c in dataGridView1.Columns)
                if (c.Name != "Traduccion") c.ReadOnly = true;

        }

        private void FormAgregarIdioma_Load(object sender, EventArgs e)
        {

        }
    }
}
