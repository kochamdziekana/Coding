using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    public class PdfGenerator : Generator
    {
        protected override void GenerateFile()
        {
            Console.WriteLine("Pdf file generated.");
        }

        protected override void GetData()
        {
            Console.WriteLine("Getting data for pdf.");
        }
        protected override void PrepareData()
        {
            Console.WriteLine("Prepare data for pdf.");
        }
    }
}
