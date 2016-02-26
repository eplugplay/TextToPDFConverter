using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TextToPDFConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            //The input text file "TextFile.txt"
            string filePath = data.GenerateTextData();

            // Create a new PdfWriter
            PdfWriter pdfWriter =
               new PdfWriter(842.0f, 1190.0f, 10.0f, 10.0f);

            if (filePath.Length > 0)
            {
                //Write to a PDF file
                pdfWriter.Write(filePath);
            }
        }
    }
}
