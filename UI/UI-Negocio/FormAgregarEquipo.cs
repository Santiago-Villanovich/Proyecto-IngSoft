using BE;
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

namespace UI.UI_Negocio
{
    public partial class FormAgregarEquipo : Form
    {
        public List<Participante> participantes;
        public Natacion eve;
        public string Nombre;

        private BLL_User bllUser;

        private void CargarListbox()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = participantes;
        }

        public FormAgregarEquipo(Natacion e)
        {
            InitializeComponent();
            participantes = new List<Participante>();
            bllUser = new BLL_User();
            btnEliminar.Enabled = false;
            eve = e;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (comboBox1.SelectedItem != null)
                {
                    if (participantes.Count <= eve.cantidad_integrantes_equipo-1)
                    {
                        Participante aux = new Participante((User)comboBox1.SelectedItem);

                        participantes.Add(aux);

                        if (participantes.Count == eve.cantidad_integrantes_equipo-1)
                        {
                            btnAgregar.Enabled = false;
                        }

                        CargarListbox();
                    }
                }
                else { MessageBox.Show("Debe seleccionar un usuario para agregarlo al equipo"); }
                
            }
            catch (Exception ex)
            {MessageBox.Show(ex.Message);}
            
        }

        private void FormAgregarEquipo_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            List<User> list = bllUser.GetAllByPermiso(1036);
            User flag = list.Find(objeto => objeto.Id == Session.GetInstance.Usuario.Id);
            if (flag != null)
            {
                list.Remove(flag);
            }

            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "NombreApellido";
            comboBox1.ValueMember = "Id";

            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.SelectedItem = null;


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Participante p = (Participante)comboBox1.SelectedItem;
                participantes.Remove(p);
                if (participantes.Count > 0) { btnEliminar.Enabled = true; }
                else { btnEliminar.Enabled = false; }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                btnEliminar.Enabled = true;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(listBox1,"");
            if (participantes.Count == eve.cantidad_integrantes_equipo -1) { this.DialogResult = DialogResult.OK; }
            else { errorProvider1.SetError(listBox1, $"Faltan {(eve.cantidad_integrantes_equipo - 1) - participantes.Count} integrantes"); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
