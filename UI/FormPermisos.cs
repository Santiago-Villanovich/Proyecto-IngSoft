using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace UI
{
    public partial class FormPermisos : Form
    {
        List<Componente> _permisos = new List<Componente>();
        public FormPermisos()
        {
            InitializeComponent();
        }

        private void Permisos_Load(object sender, EventArgs e)
        {

            List<Componente> _familias = new BLL_Permisos().GetFamilias();
            comboBox1.DataSource= _familias;

            foreach (var familia in _familias)
            {
                _permisos = new BLL_Permisos().GetPermisosFamilia(familia.Id);
                TreeNode padre = new TreeNode(familia.Nombre);
                cargarTreeView(_permisos, padre);
                treeView1.Nodes.Add(padre);
            }

        }

        public void cargarTreeView(IList<Componente> list, TreeNode parent)
        {
            foreach (var item in list)
            {
                TreeNode newNode = new TreeNode(item.Nombre);
                parent.Nodes.Add(newNode);
                if (item.Hijos != null && item.Hijos.Count != 0) cargarTreeView(item.Hijos, newNode);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new BLL_Permisos().GetAllPermisos();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Componente c;
            Componente padre = new BLL_Permisos().GetFamiliaPorNombre(comboBox1.SelectedItem.ToString());
            if (radioButton1.Checked)
            {
                c = new Patente();
            }else
            {
                c = new Familia();
            }

            c.Nombre = textBox1.Text;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedPermiso = new BLL_Permisos().GetFamiliaPorNombre(treeView1.SelectedNode.Text);
            var permisosFamilia = new BLL_Permisos().GetPermisosFamilia(selectedPermiso.Id);
            if (permisosFamilia.Count > 0)
            {
                MessageBox.Show("No se puede eliminar este permiso porque tiene hijos");
            }
        }
    }
}
