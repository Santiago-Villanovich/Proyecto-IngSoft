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

namespace UI.UI_Negocio
{
    public partial class Org_EventoIniciado : Form
    {
        public Evento EventoHoy;
        private Natacion EventoNatacion;

        //Defino variables de uso actual
        private List<Equipo> equiposCategoriaActual;
        int equipoIndex = 0;
        private Categoria categoriaActual;
        private Equipo equipoActual;

        //Defino listas segun los estados
        private List<Categoria> categoriasIniciales;
        private List<Categoria> categoriasCompletadas;
        public Org_EventoIniciado(Evento ev)
        {
            InitializeComponent();
            EventoHoy = ev;
            EventoNatacion = (Natacion)ev.Deporte;
            categoriasIniciales = ev.Categorias.Where(categoria => categoria.equipos.Count > 0).ToList();
            categoriasCompletadas = new List<Categoria>();

            CargarComboCat();
        }
        private void Org_EventoIniciado_Load(object sender, EventArgs e)
        {

        }

        private void CargarComboCat()
        {
            cboxCategoriaElegir.DataSource = null;
            cboxCategoriaElegir.DataSource = categoriasIniciales;
            cboxCategoriaElegir.DisplayMember = "Nombre";
            cboxCategoriaElegir.ValueMember = "Nombre";
        }

        private void CargarDatagrid(Equipo eq)
        {
            lblNombreEquipo.Text = eq.Nombre.ToString();

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            DataGridViewTextBoxColumn columTxt;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "pasada",
                HeaderText = "Num. Pasada"
            });

            foreach (var part in eq.Participantes)
            {
                columTxt = new DataGridViewTextBoxColumn()
                {
                    Name = part.Usuario.Id.ToString(),
                    HeaderText = part.Usuario.NombreApellido
                };

                this.dataGridView1.Columns.Add(columTxt);

            }
        }


        public int CantEq;
        public int ActEq = 0;
        private void btnIniciarCategoria_Click(object sender, EventArgs e)
        {
            cboxCategoriaElegir.Enabled = false;
            btnIniciarCategoria.Enabled = false;
            categoriaActual = (Categoria)cboxCategoriaElegir.SelectedItem;
            
            equiposCategoriaActual = categoriaActual.equipos;
            CantEq = equiposCategoriaActual.Count;

            equipoActual = equiposCategoriaActual[0];
            CargarDatagrid(equipoActual);
            
        }


        
        private void GuardarEquipo_Click(object sender, EventArgs e)
        {
            
            if (ActEq != CantEq -1)
            {
                ActEq += 1;
                equipoActual = equiposCategoriaActual[ActEq];
                CargarDatagrid(equipoActual);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
