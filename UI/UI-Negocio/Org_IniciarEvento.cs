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

namespace UI.UI_Negocio
{
    public partial class Org_IniciarEvento : Form
    {
        public Evento eventoIniciado;
        public Evento eventoDisplay;

        List<Evento> eventos;
        DateTime hoy;

        public Org_IniciarEvento()
        {
            InitializeComponent();
            eventos = new BLL_Evento().GetAllByOrg_estado(4);
            hoy = DateTime.Now;
            treeView1.Visible = false;
            btnDescargarPDF.Visible = false;
            CargarEventos(hoy);

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
            treeView1.Visible = true;
            btnDescargarPDF.Visible = true;
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

                if (eventos.Count > 0)
                {
                    Evento ev = eventos.Find(obj => obj.Fecha.Date == fecha.Date);

                    if (ev != null) 
                    {
                        Org_EventoDisplay_Cerrado Edisp = new Org_EventoDisplay_Cerrado(ev);
                        Edisp.SetEvento(ev,fecha);
                        

                        flowLayoutPanel1.Controls.Add(Edisp);
                        lblTitulo.Text = "El Evento de hoy";
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
                        foreach (Evento evento in eventos)
                        {
                            Org_EventoDisplay_Cerrado Edisp = new Org_EventoDisplay_Cerrado(evento);
                            Edisp.SetEvento(evento, fecha);

                            flowLayoutPanel1.Controls.Add(Edisp);
                        }
                        lblTitulo.Text = "Eventos proximos";
                    }
                    
                }
                else
                {
                    lblTitulo.Text = "Sin eventos disponibles";
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
