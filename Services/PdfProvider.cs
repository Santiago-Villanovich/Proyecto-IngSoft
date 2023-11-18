using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System.Windows.Controls;

namespace Services
{
    public class PdfProvider
    {
        public PdfProvider() { }

        /*public Document generarPDF()
        {
            string DocumentoLoc = saveFileDialog.FileName + ".pdf";
                    Document doc = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(DocumentoLoc, FileMode.Create));
                    doc.Open();
                    doc.Add(new Paragraph("CATEGORIAS DEL EVENTO"));

                    iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8);

                    foreach (Categoria cat in ev.Categorias)
                    {
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph($"CATEGORIA: {cat.Nombre} - De {cat.EdadInicio} a {cat.EdadFin}"));
                        doc.Add(new Paragraph($"Equipos:"));

                        if (cat.equipos.Count > 0)
                        {
                            foreach (var eq in cat.equipos)
                            {
                                doc.Add(Chunk.NEWLINE);
                                doc.Add(new Paragraph($"Nombre equipo:{eq.Nombre}:"));
                                foreach (var part in eq.Participantes)
                                {
                                    doc.Add(new Paragraph($"Participante: {part.Usuario.Apellido} {part.Usuario.Nombre} - {part.Usuario.Edad()} años"));
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
        }*/

    }
}
