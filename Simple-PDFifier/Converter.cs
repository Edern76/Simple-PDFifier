using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Simple_PDFifier
{
    class Converter
    {
        private static void convertToPng(string input)
        {
            try
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(input);
                Directory.CreateDirectory("temp");
                img.Save("temp/tmp.png");

            }
            catch (Exception ex)
            {
                string toDisplay = ex.ToString();
                MessageBox.Show(toDisplay, "Error !");
                return;
            }
        }

        public static void pdfify(string imgPath, string pdfPath)
        {
            try
            {
                convertToPng(imgPath);
                Document doc = new Document();

                PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));
                doc.Open();
                //doc.Add(new Paragraph("PNG"));

                PdfPTable table = new PdfPTable(1);
                table.WidthPercentage = 100;
                iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(imgPath);
                PdfPCell cell = new PdfPCell(png, true);
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                table.AddCell(cell);

                doc.Add(table);
                doc.Close();

                MessageBox.Show("Convertion succesful. ", "Done !", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                string toDisplay = ex.ToString();
                MessageBox.Show(toDisplay, "Error !");
                return;
            }
        }
    }


    }


