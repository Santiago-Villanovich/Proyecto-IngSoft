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
    }
}
