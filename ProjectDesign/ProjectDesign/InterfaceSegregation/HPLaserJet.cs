using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    public class HPLaserJet : IPrinter, IFaxContent, IScanner
    {
        public void Fax(string content)
        {
            Console.WriteLine("HP laser jet fax");
        }

        public void PrintColor(string content)
        {
            Console.WriteLine("HP laser jet printcolor");
        }

        public void PrintGrey(string content)
        {
            Console.WriteLine("HP laser jet printgrey");
        }

        public void Scan(string content)
        {
            Console.WriteLine("HP laser jet scan");
        }
    }
}
