using BE;
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
using System.Windows.Documents;
using System.Windows.Forms;

namespace UI.UI_Negocio
{
    public partial class FormAgregarEquipo : Form, IObserver
    {
        public List<Participante> participantes;
        private List<User> users;
        public Natacion eve;
        private BLL_User bllUser;
        BLL_Traductor traductor = new BLL_Traductor();

        private void TraducirForm(IIdioma idioma = null)
        {
            try
            {
                var traducciones = traductor.ObtenerTraducciones(idioma);

                foreach (Control control in this.Controls)
                {

                    if (control is System.Windows.Forms.Button)
                    {
                        System.Windows.Forms.Button boton = (System.Windows.Forms.Button)control;
                        if (boton.Tag != null && traducciones.ContainsKey(boton.Tag.ToString()))
                            boton.Text = traducciones[boton.Tag.ToString()].texto;
                    }
                    else if (control is Label)
                    {
                        Label label = (Label)control;
                        if (label.Tag != null && traducciones.ContainsKey(label.Tag.ToString()))
                            label.Text = traducciones[label.Tag.ToString()].texto;

                    }

                }

            }
            catch (Exception ex)
            {
                var bitacora = new Bitacora();
                bitacora.Detalle = ex.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);

                MessageBox.Show(ex.Message);
            }
        }

        public void Notify(Idioma idioma)
        {
            TraducirForm(Session.IdiomaActual);
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Participante obj = (Participante)listBox1.Items[e.Index];
                string displayText = $"{obj.Usuario.Apellido} {obj.Usuario.Nombre} - Edad: {obj.Usuario.Edad()}";

                Font font = new Font("Lucida Sans Unicode", 10);
                Brush brush = SystemBrushes.WindowText;
                e.DrawBackground();
                e.Graphics.DrawString(displayText, font, brush, e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
        }
        private void CargarListbox()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = participantes;
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
            listBox1.DrawItem += listBox1_DrawItem;
            listBox1.SelectedIndex = -1;
        }
        private void CargarUsers()
        {
            users = bllUser.GetAllByPermiso(1036);

            User flag = users.Find(objeto => objeto.Id == Session.GetInstance.Usuario.Id);
            if (flag != null)
            {
                users.Remove(flag);
            }
        }

        public FormAgregarEquipo(Natacion e)
        {
            InitializeComponent();
            participantes = new List<Participante>();
            bllUser = new BLL_User();
            btnEliminar.Enabled = false;
            eve = e;

            Session._publisherIdioma.Subscribe(this);
            TraducirForm(Session.IdiomaActual);
            CargarUsers();
        }
        private void FormAgregarEquipo_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            List<User> list = new List<User>(users);

            if (participantes.Count>0)
            {
                foreach (var item in participantes)
                {
                    User flag2 = list.Find(objeto => objeto.Id == item.Usuario.Id);
                    if (flag2 != null)
                    {
                        list.Remove(flag2);
                    }
                }
            }

            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "NombreApellido";
            comboBox1.ValueMember = "Id";

            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.SelectedItem = null;


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
                        this.OnLoad(null);
                    }
                }
                else { MessageBox.Show("Debe seleccionar un usuario para agregarlo al equipo"); }
                
            }
            catch (Exception ex)
            {MessageBox.Show(ex.Message);}
            
        }

        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Participante p = (Participante)listBox1.SelectedItem;
                participantes.Remove(p);
                if (participantes.Count > 0) { btnEliminar.Enabled = true; }
                else { btnEliminar.Enabled = false; btnAgregar.Enabled = true; }

                CargarListbox();
                this.OnLoad(null);
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
