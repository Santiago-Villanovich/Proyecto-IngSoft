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
            int contador = 0;
            string Documento = saveFileDialog.FileName + ".pdf";
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(Documento, FileMode.Create));
            doc.Open();
            doc.Add(new Paragraph("Lista de viajes"));
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8);


            foreach (var viaje in viajes)
            {
                contador++;
                AgregarTitulo(doc, "viaje " + contador);
                doc.Add(new Paragraph($"ID del Viaje: {viaje.id}", fuente));

            }
            doc.Close();

            return doc;
        }*/
        
    }
}
