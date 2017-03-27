using System;
using Xfinium.Pdf.Graphics;

namespace PdfSignature
{
  class Program
  {
    static void Main(string[] args)
    {
      string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
      path = System.IO.Path.GetDirectoryName(path);
      path = System.IO.Path.Combine(path, "SignatureTest.pdf");

      var pdfdoc = new Xfinium.Pdf.PdfFixedDocument();
      var pdfpage = pdfdoc.Pages.Add();
      var pen = new PdfPen(new PdfRgbColor(0, 0, 0), 3);
      var brush = new PdfBrush(new PdfRgbColor(255, 255, 120));
      pdfpage.Graphics.DrawEllipse(pen, brush, 100, 100, 400, 400, 0);
      brush = new PdfBrush(new PdfRgbColor(255, 255, 255));
      pdfpage.Graphics.DrawEllipse(pen, brush, 200, 250, 30, 30, 0);
      pdfpage.Graphics.DrawEllipse(pen, brush, 370, 250, 30, 30, 0);
      pdfpage.Graphics.DrawArc(pen, 180, 300, 260, 150, 200, 120);
      brush = new PdfBrush(new PdfRgbColor(0, 0, 0));
      pdfpage.Graphics.DrawString("Hello World", new PdfStandardFont(PdfStandardFontFace.Helvetica, 30), brush, 225.0, 550.0);

      // TODO: Figure out what is needed for signing this PDF
      //var signature = new Xfinium.Pdf.Forms.PdfSignatureField("Sign Here");
      //pdfpage.Fields.Add(signature);
      //signature.Widgets[0].VisualRectangle = new PdfVisualRectangle(50, 600, 100, 100);
      

      pdfdoc.Save(path);
    }
  }
}
