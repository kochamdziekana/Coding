using System;
using System.Collections.Generic;
using System.Linq;

namespace TemplateMethod
{
    public class Program // metoda abstrakcyjna która może być wykorzystywana przez różne klasy
    {
        public static void Main(string[] args)
        {
            var pdfGenerator = new PdfGenerator();         
            var excelGenerator = new ExcelGenerator();     
            var csvGenerator = new CsvGenerator();         
                                                           
            pdfGenerator.GenerateReport();                 
            excelGenerator.GenerateReport();               
            csvGenerator.GenerateReport();                 
        }
    }


}