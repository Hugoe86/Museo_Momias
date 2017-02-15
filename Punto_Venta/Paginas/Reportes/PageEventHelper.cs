using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace ERP_BASE.Paginas.Reportes
{
    class PageEventHelper : PdfPageEventHelper
    {
        public string Movimiento;

        public override void OnEndPage(PdfWriter writer, iTextSharp.text.Document document)
        {
            float cellHeight = document.TopMargin;
            BaseColor grey = new BaseColor(128, 128, 128);
            Font font = FontFactory.GetFont("Arial", 9, Font.NORMAL, grey);
            Rectangle page = document.PageSize;

            //tbl footer
            PdfPTable footerTbl = new PdfPTable(1);
            PdfPTable headTbl = new PdfPTable(2);

            headTbl.HorizontalAlignment = Element.ALIGN_LEFT;
            headTbl.SpacingBefore = 100f;
            headTbl.TotalWidth = page.Width - document.LeftMargin - document.RightMargin;
            //headTbl.SetWidths(new float[] { 100, 500 });

            PdfPCell c = new PdfPCell(new Phrase(
              "Museo de las Momias de Guanajuato",
              new Font(FontFactory.GetFont("Consolas", 14, Font.BOLD))
            ));
            c.Colspan = 2;
            c.Border = PdfPCell.NO_BORDER;
            c.HorizontalAlignment = Element.ALIGN_CENTER;
            c.VerticalAlignment = Element.ALIGN_MIDDLE;
            headTbl.AddCell(c);

            c = new PdfPCell(new Phrase(
              "Reporte de " + Movimiento,
              new Font(FontFactory.GetFont("Consolas", 12, Font.BOLD))
            ));
            c.Border = PdfPCell.NO_BORDER;
            c.HorizontalAlignment = Element.ALIGN_LEFT;
            c.VerticalAlignment = Element.ALIGN_MIDDLE;
            headTbl.AddCell(c);

            c = new PdfPCell(new Phrase(
              DateTime.Today.ToString("dd-MMM-yyyy"),
              new Font(FontFactory.GetFont("Arial", 11, Font.NORMAL))
            ));
            c.Border = PdfPCell.NO_BORDER;
            c.HorizontalAlignment = Element.ALIGN_RIGHT;
            c.VerticalAlignment = Element.ALIGN_MIDDLE;
            headTbl.AddCell(c);

            headTbl.WriteSelectedRows(
              0, -1,  // first/last row; -1 flags all write all rows
              document.LeftMargin,      // left offset
                // ** bottom** yPos of the table
              page.Height,// - cellHeight + headTbl.TotalHeight,
              writer.DirectContent
            );

            footerTbl.TotalWidth = document.PageSize.Width;

            //page number
            Chunk myFooter = new Chunk("Página " + (document.PageNumber), FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 8, grey));
            PdfPCell footer = new PdfPCell(new Phrase(myFooter));
            
            //footer.BackgroundColor = BaseColor.GRAY;
            footer.Border = Rectangle.NO_BORDER;
            footer.HorizontalAlignment = Element.ALIGN_RIGHT;
            footerTbl.AddCell(footer);

            //this is for the position of the footer ... im my case is "+80"
            footerTbl.WriteSelectedRows(0, -1, -10, (document.BottomMargin), writer.DirectContent);
        }
    }
}
