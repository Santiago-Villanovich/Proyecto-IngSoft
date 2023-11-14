using BE;
using BLL;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace UI.UI_Negocio
{
    public partial class Org_EventoIniciado : Form
    {
        public Evento EventoHoy;
        private Natacion EventoNatacion;

        //Defino variables de uso actual
        private List<Equipo> equiposCategoriaActual;
        private Categoria categoriaActual;
        private Equipo equipoActual;

        //Defino listas segun los estados
        private List<Categoria> categoriasIniciales;
        private List<Categoria> categoriasCompletadas;

        private BLL_Evento bllEvento = new BLL_Evento();

        public Org_EventoIniciado(Evento ev)
        {
            InitializeComponent();
            EventoHoy = ev;
            EventoNatacion = (Natacion)ev.Deporte;
            categoriasIniciales = ev.Categorias.Where(categoria => categoria.equipos.Count > 0).ToList();
            categoriasCompletadas = new List<Categoria>();

        }
        private void Org_EventoIniciado_Load(object sender, EventArgs e)
        {
            gboxParticipantes.Visible = false;
            cboxCategoriaElegir.Enabled = true;
            btnIniciarCategoria.Enabled = true;
            btnGuardarCategoria.Enabled = false;

            datagvEquipos.DataSource = null;
            CargarComboCat();
        }

        public static TimeSpan ParseCustomTimeSpan(string input)
        {
            if (RegexValidation.validarTiempo(input))
            {
                string[] parts = input.Split(':');

                int hours = int.Parse(parts[0]);
                int minutes = int.Parse(parts[1]);
                int seconds = int.Parse(parts[2]);

                return new TimeSpan(0, hours, minutes, seconds);
            }
            else
            {
                throw new FormatException("Formato invalido de tiempo. Respete el siguiente formato hh:mm:ss, por ejemplo: 00:01:12");

            }
        }

        private void CargarComboCat()
        {
            cboxCategoriaElegir.DataSource = null;
            if (categoriasIniciales.Count > 0)
            {
                cboxCategoriaElegir.DataSource = categoriasIniciales;
                cboxCategoriaElegir.DisplayMember = "Nombre";
                cboxCategoriaElegir.ValueMember = "Nombre";
            }
            
        }

        private void CargarDataGVEquipos(List<Equipo> equipos)
        {
            datagvEquipos.DataSource = null;
            datagvEquipos.DataSource = equipos;
            datagvEquipos.AutoGenerateColumns = false;

            datagvEquipos.Columns["Id"].Visible = false;
            datagvEquipos.Columns["Categoria"].Visible = false;
            datagvEquipos.Columns["TiempoTotal"].Visible = false;
            datagvEquipos.Columns["MetrosTotal"].Visible = false;
            datagvEquipos.Columns["PosicionGeneral"].Visible = false;
            datagvEquipos.Columns["PosicionCategoria"].Visible = false;

            datagvEquipos.Columns["Nombre"].ReadOnly = true;
            datagvEquipos.Columns["Nombre"].Width = 135;

            string nombreColumna = "Estado";

            if (!datagvEquipos.Columns.Contains(nombreColumna))
            {
                DataGridViewCheckBoxColumn columnaCheckBox = new DataGridViewCheckBoxColumn();
                columnaCheckBox.HeaderText = "Estado";
                columnaCheckBox.Name = nombreColumna;
                columnaCheckBox.Width = 75;
                columnaCheckBox.ReadOnly = true;
                datagvEquipos.Columns.Add(columnaCheckBox);
            }
        }

        private void CargarGBoxParticipantes(Equipo eq)
        {
            lblNombreEquipoTiempo.Text = eq.Nombre.ToString();

            datagvParticipantes.Columns.Clear();
            datagvParticipantes.Rows.Clear();

            DataGridViewTextBoxColumn columTxt;
            DataGridViewCellStyle Style = new DataGridViewCellStyle()
            {
                Font = new System.Drawing.Font("Microsoft Sans Serif", 8),
                ForeColor = Color.Black
            };

            datagvParticipantes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "pasada",
                HeaderText = "Num. Pasada",
                DefaultCellStyle = Style,
                ReadOnly = true

            });

            foreach (var part in eq.Participantes)
            {
                columTxt = new DataGridViewTextBoxColumn
                {
                    Name = part.Usuario.Id.ToString(),
                    HeaderText = part.Usuario.NombreApellido,
                    DefaultCellStyle = Style
                };

                this.datagvParticipantes.Columns.Add(columTxt);
            }
        }

        private void cambiarEstadoEquipo(Equipo eq)
        {
            foreach (DataGridViewRow row in datagvEquipos.Rows)
            {
                if ((Guid)row.Cells["Id"].Value == eq.Id)
                {
                    row.Cells["Estado"].Value = true;
                    break;
                }
            }
        }

        private void DescargarPDF(Categoria categoria)
        {
            OpenFileDialog file = new OpenFileDialog();

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string DocumentoLoc = saveFileDialog.FileName + ".pdf";
                    Document doc = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(DocumentoLoc, FileMode.Create));
                    doc.Open();
                    doc.AddTitle($"Listado posiciones generales y categoria - {EventoHoy.nombre}");
                    doc.AddCreator("GoComp");
                    doc.Add(new Paragraph($"Listado posiciones generales y categoria - {EventoHoy.nombre}"));
                    doc.Add(Chunk.NEWLINE);

                    iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8);

                    int totalColum = 2 + EventoNatacion.cantidad_integrantes_equipo;

                    PdfPTable tblPrueba = new PdfPTable(totalColum);
                    tblPrueba.WidthPercentage = 100;


                    // TITULO DE LAS COLUMNAS
                    PdfPCell clPoscGeneral = new PdfPCell(new Phrase("Posc.General"));
                    clPoscGeneral.BorderWidth = 0;
                    clPoscGeneral.BorderWidthBottom = 0.75f;

                    PdfPCell clPoscCat = new PdfPCell(new Phrase("Posc.Categoria"));
                    clPoscCat.BorderWidth = 0;
                    clPoscCat.BorderWidthBottom = 0.75f;

                    PdfPCell clEquipo = new PdfPCell(new Phrase("Equipo"));
                    clEquipo.BorderWidth = 0;
                    clEquipo.BorderWidthBottom = 0.75f;

                    PdfPCell clLogrado = new PdfPCell(new Phrase("Rendimiento"));
                    clLogrado.BorderWidth = 0;
                    clLogrado.BorderWidthBottom = 0.75f;

                    tblPrueba.AddCell(clPoscGeneral);
                    tblPrueba.AddCell(clPoscCat);
                    tblPrueba.AddCell(clEquipo);
                    tblPrueba.AddCell(clLogrado);

                    //CARGO DATOS
                    foreach (Equipo eq in categoria.equipos)
                    {
                        clPoscGeneral = new PdfPCell(new Phrase($"{eq.PosicionGeneral}"));
                        clPoscGeneral.BorderWidth = 0;

                        clPoscCat = new PdfPCell(new Phrase($"{eq.PosicionCategoria}"));
                        clPoscCat.BorderWidth = 0;

                        clEquipo = new PdfPCell(new Phrase($"{eq.Nombre}"));
                        clEquipo.BorderWidth = 0;

                        if (EventoNatacion.MetrosTotales == 0)
                        {
                            clLogrado = new PdfPCell(new Phrase($"{eq.MetrosTotal} Mts"));
                            clLogrado.BorderWidth = 0;
                        }
                        else
                        {
                            clLogrado = new PdfPCell(new Phrase($"{eq.TiempoTotal}"));
                            clLogrado.BorderWidth = 0;
                        }

                        tblPrueba.AddCell(clPoscGeneral);
                        tblPrueba.AddCell(clPoscCat);
                        tblPrueba.AddCell(clEquipo);
                        tblPrueba.AddCell(clLogrado);

                    }

                    doc.Add(tblPrueba);
                    doc.Close();

                    MessageBox.Show("Se guardo el PDF correctamente. Ruta de acceso: " + DocumentoLoc);
                }
            }
        }

        public int CantEq;
        public int ActEq = 0;
        private void btnIniciarCategoria_Click(object sender, EventArgs e)
        {
            cboxCategoriaElegir.Enabled = false;
            btnIniciarCategoria.Enabled = false;
            btnGuardarCategoria.Enabled = true;
            categoriaActual = (Categoria)cboxCategoriaElegir.SelectedItem;

            equiposCategoriaActual = categoriaActual.equipos;
            CantEq = equiposCategoriaActual.Count;

            CargarDataGVEquipos(equiposCategoriaActual);

        }

        DataGridViewRow ActualRow;
        private void datagvEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ActualRow = datagvEquipos.Rows[e.RowIndex];
                DataGridViewCheckBoxCell checkboxCell = ActualRow.Cells["Estado"] as DataGridViewCheckBoxCell;
                if (checkboxCell.Value == null)
                {
                    checkboxCell.Value = false;
                }

                bool cbValue = (bool)checkboxCell.Value;

                if (!cbValue)
                {
                    equipoActual = (Equipo)ActualRow.DataBoundItem;

                    if (EventoNatacion.MetrosTotales == 0)
                    {
                        CargarGBoxParticipantes(equipoActual);
                        datagvParticipantes.Rows.Add();
                        datagvParticipantes.AllowUserToAddRows = false;
                        gboxParticipantes.Visible = true;

                    }
                    else
                    {
                        CargarGBoxParticipantes(equipoActual);
                        gboxParticipantes.Visible = true;

                    }
                }
            }
        }

        private void GuardarEquipo_Click(object sender, EventArgs e)
        {
            try
            {
                List<TimeSpan> timeList;

                //VALIDO SI HAY VALORES EN LA TABLA
                bool hayValores = datagvParticipantes.Rows
                                    .Cast<DataGridViewRow>()
                                    .Any(row =>
                                    {
                                        var cell1 = row.Cells[1].Value;
                                        var cell2 = row.Cells[2].Value;
                                        return cell1 != null && !string.IsNullOrWhiteSpace(cell1.ToString()) ||
                                               cell2 != null && !string.IsNullOrWhiteSpace(cell2.ToString());
                                    });

                if (!hayValores)
                {
                    MessageBox.Show("No se registraron valores en la tabla, para guardar un equipo debe completar los campos.", "Sin valores ingresados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    //RECORRO COLUMNA
                    for (int columnIndex = 1; columnIndex < datagvParticipantes.Columns.Count; columnIndex++)
                    {
                        timeList = new List<TimeSpan>(); //SETEO LISTA DE TIEMPOS DE LA COLUMNA
                        int idParticipante = int.Parse(datagvParticipantes.Columns[columnIndex].Name);

                        foreach (DataGridViewRow row in datagvParticipantes.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string cellValue = row.Cells[columnIndex].Value as string;

                                if (EventoNatacion.MetrosTotales == 0)
                                {
                                    if (RegexValidation.validarNum(cellValue))
                                    {
                                        foreach (var p in equipoActual.Participantes)
                                        {
                                            if (p.Usuario.Id == idParticipante)
                                            {
                                                p.MetrosLogrados = Convert.ToInt32(cellValue);
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    TimeSpan time = ParseCustomTimeSpan(cellValue);
                                    timeList.Add(time);

                                }
                            }
                        }

                        //AGREGO LOS TIEMPOS AL PARTICIPANTE DEL EQUIPOACTUAL
                        foreach (var p in equipoActual.Participantes)
                        {
                            if (p.Usuario.Id == idParticipante)
                            {
                                p.Tiempos = timeList;
                                break;
                            }
                        }
                    }

                    foreach (var equipo in categoriaActual.equipos)
                    {
                        if (equipo.Id == equipoActual.Id)
                        {
                            equipo.Participantes = equipoActual.Participantes;
                            equipo.CalcularTiempoTotal();
                            equipo.CalcularMetrosTotal();
                            break;
                        }
                    }

                    cambiarEstadoEquipo(equipoActual);
                    gboxParticipantes.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void datagvParticipantes_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                datagvParticipantes.Rows[e.RowIndex].Cells[0].Value = 1;
            }
            else
            {
                datagvParticipantes.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1);
            }
        }

        private void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                bool isComplete = true;

                foreach (DataGridViewRow row in datagvEquipos.Rows)
                {
                    DataGridViewCheckBoxCell checkCell = row.Cells["Estado"] as DataGridViewCheckBoxCell;

                    if (!(bool)checkCell.Value)
                    {
                        isComplete = false;
                        break;
                    }
                }

                if (isComplete)
                {
                    BLL_Categoria bllCat = new BLL_Categoria();
                    Categoria CatAux = bllCat.CalcularPosicionCategoriaNatacion(categoriaActual, EventoNatacion);
                    bllCat.GuardarCategoriaPosiciones(CatAux);
                    bllCat.GuardarLogrado(CatAux,EventoNatacion);

                    categoriasCompletadas.Add(CatAux);

                    categoriasIniciales.RemoveAll(cat => cat.id == categoriaActual.id);
                    if (categoriasIniciales.Count > 0)
                    {
                        this.OnLoad(null);
                    }
                    else
                    {
                        categoriaActual = bllCat.CalcularPosicionGeneralNatacion(categoriasCompletadas,EventoNatacion);
                        bllCat.GuardarCategoriaPosiciones(categoriaActual);

                        string mensaje = $"Se completaron todas las categorias del evento.\nPresione 'Yes' si desea descargar un pdf con las posiciones generales del evento.\nPresione 'No' caso contrario.";
                        DialogResult result = MessageBox.Show(mensaje, "Categorias finalizadas", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            DescargarPDF(categoriaActual);
                            this.OnLoad(null);
                        }
                        else
                        {
                            this.OnLoad(null );
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Para terminar una categoria deben estar todos los equipos completos", "Categoria incompleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
