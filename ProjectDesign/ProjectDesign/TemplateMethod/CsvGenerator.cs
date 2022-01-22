using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    public class CsvGenerator : Generator
    {
        protected override void GenerateFile()
        {
            Console.WriteLine("Csv file generated.");
        }

        protected override void PrepareData()
        {
            Console.WriteLine("Prepare data for csv.");
        }
    }
}
