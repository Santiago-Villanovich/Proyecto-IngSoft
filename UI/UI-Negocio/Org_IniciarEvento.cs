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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Services;
using Services.Multilanguage;

namespace UI.UI_Negocio
{
    public partial class Org_IniciarEvento : Form, IObserver
    {
        public Evento eventoIniciado;
        public Evento eventoDisplay;
        BLL_Traductor traductor = new BLL_Traductor();
        List<Evento> eventos;
        DateTime hoy;

        private void TraducirForm(IIdioma idioma = null)
        {
            try
            {
                var traducciones = traductor.ObtenerTraducciones(idioma);

                foreach (Control control in this.Controls)
                {
                    if (control.Tag != null && traducciones.ContainsKey(control.Tag.ToString()))
                        control.Text = traducciones[control.Tag.ToString()].texto;
                }
                foreach (Control control in this.groupBox1.Controls)
                {
                    if (control.Tag != null && traducciones.ContainsKey(control.Tag.ToString()))
                        control.Text = traducciones[control.Tag.ToString()].texto;
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

        public Org_IniciarEvento()
        {
            InitializeComponent();
            eventos = new BLL_Evento().GetAllByOrg_estado(4);
            hoy = DateTime.Now;
            groupBox1.Visible = false;
            CargarEventos(hoy);

            TraducirForm(Session.IdiomaActual);
            Session._publisherIdioma.Subscribe(this);
        }
        public void MostrarInscriptos(Evento eve)
        {
            treeView1.Nodes.Clear();

            foreach (var categoria in eve.Categorias)
            {
                TreeNode categoriaNode = new TreeNode(categoria.ToString());

                if (categoria.equipos.Count >0)
                {
                    foreach (var equipo in categoria.equipos)
                    {
                        TreeNode equipoNode = new TreeNode(equipo.Nombre);
                        categoriaNode.Nodes.Add(equipoNode);
                    }
                    TreeNode equipoNode2 = new TreeNode("");
                    categoriaNode.Nodes.Add(equipoNode2);
                }
                else
                {
                    TreeNode equipoNode = new TreeNode("Sin equipos inscriptos");
                    categoriaNode.Nodes.Add(equipoNode);
                    TreeNode equipoNode2 = new TreeNode("");
                    categoriaNode.Nodes.Add(equipoNode2);
                }
                

                treeView1.Nodes.Add(categoriaNode);
            }

            treeView1.ExpandAll();
            groupBox1.Visible = true;
        }

        public event EventHandler mostrarIniciar;
        private void CargarEventos(DateTime fecha)
        {
            try
            {
                if (flowLayoutPanel1.Controls.Count > 0)
                {
                    foreach (Control control in flowLayoutPanel1.Controls)
                    {
                        control.Dispose();
                    }
                    flowLayoutPanel1.Controls.Clear();
                }
                if (flowLayoutPanel2.Controls.Count > 0)
                {
                    foreach (Control control in flowLayoutPanel2.Controls)
                    {
                        control.Dispose();
                    }
                    flowLayoutPanel2.Controls.Clear();
                }

                if (eventos.Count > 0)
                {
                    Evento ev = eventos.Find(obj => obj.Fecha.Date == fecha.Date);
                    List<Evento> eventosProx = eventos.FindAll(obj => obj.Fecha.Date > fecha.Date);

                    if (ev != null) 
                    {
                        Org_EventoDisplay_Cerrado Edisp = new Org_EventoDisplay_Cerrado(ev);
                        Edisp.SetEvento(fecha,ev);

                        flowLayoutPanel1.Controls.Add(Edisp);
                        Edisp.iniciarClick += (sender, e) =>
                        {
                            eventoIniciado = Edisp.MiEvento;
                            mostrarIniciar?.Invoke(this, EventArgs.Empty);

                            //new BLL_Evento().UpdateEstado(Edisp.MiEvento,6);
                        };
                        Edisp.verClick += (sender, e) =>
                        {
                            eventoDisplay = Edisp.MiEvento;
                            MostrarInscriptos(eventoDisplay);
                        };
                    }
                    else
                    {
                        Label label = new Label();
                        label.Text = "No hay eventos proximos";
                        label.AutoSize = true;
                        label.Padding = new Padding(30, 40, 30, 5);
                        label.Font = new System.Drawing.Font("Lucida Sans Unicode", 12);

                        flowLayoutPanel2.Controls.Add(label);
                    }

                    if (eventosProx.Count > 0)
                    {
                        Org_EventoDisplay_Cerrado Edisp = new Org_EventoDisplay_Cerrado(ev);
                        Edisp.SetEvento(fecha, ev);

                        flowLayoutPanel2.Controls.Add(Edisp);
                        Edisp.verClick += (sender, e) =>
                        {
                            eventoDisplay = Edisp.MiEvento;
                            MostrarInscriptos(eventoDisplay);
                        };
                    }
                    else
                    {
                        Label label = new Label();
                        label.Text = "No hay eventos proximos";
                        label.AutoSize = true;
                        label.Padding = new Padding(30, 40, 30, 5); 
                        label.Font = new System.Drawing.Font("Lucida Sans Unicode", 12);

                        flowLayoutPanel2.Controls.Add(label);
                    }

                }
                else
                {
                    lblEventoProximos.Text = "Sin eventos disponibles";
                    MessageBox.Show("Por el momento no tiene eventos publicados", "Sin eventos disponibles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDescargarPDF_Click(object sender, EventArgs e)
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
                    doc.AddTitle($"Listado categorias - {eventoDisplay.nombre}");
                    doc.AddCreator("GoComp");
                    doc.Add(new Paragraph("CATEGORIAS DEL EVENTO"));

                    iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8);

                    foreach (Categoria cat in eventoDisplay.Categorias)
                    {
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph($"CATEGORIA: {cat.Nombre} - De {cat.EdadInicio} a {cat.EdadFin}"));

                        if (cat.equipos.Count > 0)
                        {
                            foreach (var eq in cat.equipos)
                            {
                                doc.Add(Chunk.NEWLINE);
                                doc.Add(new Paragraph($"Equipo: {eq.Nombre}"));
                                doc.Add(new Paragraph($"Participantes:"));
                                foreach (var part in eq.Participantes)
                                {
                                    doc.Add(new Paragraph($"    • {part.Usuario.Apellido} {part.Usuario.Nombre} - {part.Usuario.Edad()} años"));
                                }
                            }
                        }
                        else
                        {
                            doc.Add(Chunk.NEWLINE);
                            doc.Add(new Paragraph($"Sin equipos inscriptos"));

                        }

                    }

                    doc.Close();

                    MessageBox.Show("Se guardo el PDF correctamente. Ruta de acceso: " + DocumentoLoc);
                }
            }
        }
    }
}
