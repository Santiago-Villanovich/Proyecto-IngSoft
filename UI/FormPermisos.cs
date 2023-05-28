using BE;
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
           
            _permisos = new BLL_Permisos().GetFamilia(1);
            TreeNode padre = new TreeNode(_permisos[0].Nombre);
            cargarTreeView(_permisos[0].Hijos, padre);
            treeView1.Nodes.Add(padre);
           
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
    }
}
