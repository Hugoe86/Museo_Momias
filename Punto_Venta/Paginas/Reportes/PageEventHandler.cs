using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ERP_BASE.Paginas.Reportes
{
    /// <summary>
    /// Descripción breve de PageEventHandler
    /// </summary>
    public class PageEventHandler : PdfPageEventHelper
    {
        public String Parametros { get; set; }
        public String Usuario_Creo { get; set; }
        public String Tipo_Reporte { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public int Anio_Inicio { get; set; }
        public int Anio_Fin { get; set; }
        public float Posicion_Encabezado { get; set; }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            // cell height 
            float cellHeight = document.TopMargin;
            // PDF document size      
            Rectangle page = document.PageSize;

            Font fnt = new Font(FontFactory.GetFont("Arial", 8,
                iTextSharp.text.Font.NORMAL));

            // create two column table
            PdfPTable head = new PdfPTable(1);
            head.HorizontalAlignment = Element.ALIGN_LEFT;
            head.SpacingBefore = 100f;
            head.TotalWidth = page.Width - document.LeftMargin - document.RightMargin;
            head.SetWidths(new float[] { 600 });

            PdfPCell c;
            c = new PdfPCell(new Phrase(
              "Tesorería Municipal",
              new Font(FontFactory.GetFont("Arial", 7, Font.BOLDITALIC))
            ));
            c.Border = PdfPCell.NO_BORDER;
            c.HorizontalAlignment = Element.ALIGN_CENTER;
            c.VerticalAlignment = Element.ALIGN_MIDDLE;
            //c.FixedHeight = 100;
            head.AddCell(c);

            c.Phrase = new Phrase("Dirección de Ingresos",
                new Font(FontFactory.GetFont("Arial", 8, Font.ITALIC)));
            head.AddCell(c);

            c.Phrase = new Phrase("Museo de las Momias de Guanajuato",
                new Font(FontFactory.GetFont("Arial Narrow", 8, Font.BOLDITALIC)));
            head.AddCell(c);

            if (Fecha_Inicio != DateTime.MinValue &&
                Fecha_Fin != DateTime.MinValue)
            {
                c.Phrase = new Phrase("Periodo del " + Fecha_Inicio.ToLongDateString() +
                    " al " + Fecha_Fin.ToLongDateString(),
                    new Font(FontFactory.GetFont("Arial Narrow", 8, Font.BOLD)));
                head.AddCell(c);
            }

            if (Anio_Inicio != 0 && Anio_Fin != 0)
            {
                c.Phrase = new Phrase("Periodo del " + Anio_Inicio.ToString() +
                    " al " + Anio_Fin.ToString(),
                    new Font(FontFactory.GetFont("Arial Narrow", 8, Font.BOLD)));
                head.AddCell(c);
            }

            if (!string.IsNullOrEmpty(this.Tipo_Reporte))
            {
                c.Phrase = new Phrase(this.Tipo_Reporte,
                    new Font(FontFactory.GetFont("Arial", 8, Font.BOLD)));
                head.AddCell(c);
            }

            if (!string.IsNullOrEmpty(this.Parametros))
            {
                c.Phrase = new Phrase(this.Parametros,
                    new Font(FontFactory.GetFont("Arial", 8, Font.BOLD)));
                head.AddCell(c);
            }

            c.Phrase = new Phrase(" ",
                new Font(FontFactory.GetFont("Arial Narrow", 8, Font.BOLDITALIC)));
            head.AddCell(c);

            head.WriteSelectedRows(
              0, -1,  // first/last row; -1 flags all write all rows
              document.LeftMargin,      // left offset
                // ** bottom** yPos of the table
              Posicion_Encabezado,
              writer.DirectContent
            );

            PdfPTable foot = new PdfPTable(2);
            Font fnt_footer = new Font(FontFactory.GetFont("Arial", 7, Font.BOLD));

            foot.TotalWidth = page.Width - document.LeftMargin - document.RightMargin;

            foot.AddCell(new PdfPCell(new Phrase("Usuario Creó: " + Usuario_Creo, fnt_footer))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Border = PdfPCell.NO_BORDER
            });

            foot.AddCell(new PdfPCell(new Phrase(string.Empty, fnt_footer))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Border = PdfPCell.NO_BORDER
            });

            foot.AddCell(new PdfPCell(new Phrase("Fecha Creó: " + DateTime.Now.ToLongDateString(), fnt_footer))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Border = PdfPCell.NO_BORDER
            });

            foot.AddCell(new PdfPCell(new Phrase("Página " +
            document.PageNumber + " de " + document.PageNumber.ToString(), fnt_footer))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Border = PdfPCell.NO_BORDER
            });
            
            foot.WriteSelectedRows(
                0, -1,  // first/last row; -1 flags all write all rows
                document.LeftMargin,      // left offset
                // ** bottom** yPos of the table
                35,
                writer.DirectContent
            );
        }
    }
}