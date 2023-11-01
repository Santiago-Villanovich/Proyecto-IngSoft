using BE;
using System;
using System.Collections;
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

            gboxMetros.Visible = false;
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

        private void CargarDataGVEquipos(List<Equipo> equipos)
        {
            datagvEquipos.DataSource = equipos;
            datagvEquipos.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn columnaPropiedad = new DataGridViewTextBoxColumn();
            columnaPropiedad.DataPropertyName = "nombre";
            columnaPropiedad.HeaderText = "Nombre";
            columnaPropiedad.Width = 225;
            columnaPropiedad.ReadOnly = true;
            datagvEquipos.Columns.Add(columnaPropiedad);

            DataGridViewCheckBoxColumn columnaCheckBox = new DataGridViewCheckBoxColumn();
            columnaCheckBox.HeaderText = "Estado";
            columnaCheckBox.Width = 75;
            columnaCheckBox.ReadOnly = true;
            datagvEquipos.Columns.Add(columnaCheckBox);
        }
        private void CargarDatagridParticipantes(Equipo eq)
        {
            lblNombreEquipo.Text = eq.Nombre.ToString();

            datagvParticipantes.Columns.Clear();
            datagvParticipantes.Rows.Clear();

            DataGridViewTextBoxColumn columTxt;

            datagvParticipantes.Columns.Add(new DataGridViewTextBoxColumn()
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

                this.datagvParticipantes.Columns.Add(columTxt);

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

            CargarDataGVEquipos(equiposCategoriaActual);
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datagvEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (!(bool)datagvEquipos.Rows[e.RowIndex].Cells[1].Value)
                {
                    equipoActual = (Equipo)datagvEquipos.CurrentRow.DataBoundItem;
                    lblNombreEquipo.Text = equipoActual.Nombre;
                    CargarDatagridParticipantes(equipoActual);
                    gboxMetros.Visible = true;
                }
                
            }
        }


        private void GuardarEquipo_Click(object sender, EventArgs e)
        {

            if (ActEq != CantEq - 1)
            {
                ActEq += 1;
                equipoActual = equiposCategoriaActual[ActEq];
                //CargarDatagrid(equipoActual);
            }
        }

    }
}
