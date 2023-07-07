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
            List<string> nombreFamilias = new List<string>();
            nombreFamilias.Add("");
            _familias.ForEach(familia =>
            {
                nombreFamilias.Add(familia.Nombre);
            });

            comboBox1.DataSource = nombreFamilias;

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
            try
            {
                if (String.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("El permiso debe tener un nombre ingresado");
                }

                if(radioButton1.Checked && comboBox1.SelectedItem.ToString()== "")
                {
                    MessageBox.Show("Una patente debe estar dentro de una familia");
                }
                Componente c;
                Componente padre = new BLL_Permisos().GetFamiliaPorNombre(comboBox1.SelectedItem.ToString());
                int IdPadre;

                if (padre != null) IdPadre = padre.Id;
                else IdPadre = 0;

                if (radioButton1.Checked)
                {
                    c = new Patente();
                }
                else
                {
                    c = new Familia();
                }

                c.Nombre = textBox1.Text;
                c.es_patente = radioButton1.Checked;

                new BLL_Permisos().AgregarPermiso(c, IdPadre);

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    

            }finally
            {
                treeView1.Nodes.Clear();    
                List<Componente> _familias = new BLL_Permisos().GetFamilias();
                List<string> nombreFamilias = new List<string>();
                nombreFamilias.Add("");
                _familias.ForEach(familia =>
                {
                    nombreFamilias.Add(familia.Nombre);
                });

                comboBox1.DataSource = nombreFamilias;

                foreach (var familia in _familias)
                {
                    _permisos = new BLL_Permisos().GetPermisosFamilia(familia.Id);
                    TreeNode padre = new TreeNode(familia.Nombre);
                    cargarTreeView(_permisos, padre);
                    treeView1.Nodes.Add(padre);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1 == null)
                {
                    MessageBox.Show("Debe seleccionar un permiso");
                    return;
                }
                var selectedPermiso = new BLL_Permisos().GetFamiliaPorNombre(treeView1.SelectedNode.Text);
                
                var permisosFamilia = new BLL_Permisos().GetPermisosFamilia(selectedPermiso.Id);

                new BLL_Permisos().Delete(selectedPermiso);

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                treeView1.Nodes.Clear();
                Permisos_Load(this, null);
            }
            
        }
    }
}
