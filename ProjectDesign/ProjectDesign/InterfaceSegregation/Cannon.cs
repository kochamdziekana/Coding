using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    internal class Cannon : IPrinter, IFaxContent    // uznajemy, że nie skanuje
    {
        public void PrintGrey(string content)
        {
            Console.WriteLine("Cannon print grey");
        }

        public void PrintColor(string content)
        {
            Console.WriteLine("Cannon print color");
        }

        public void Scan(string content)
        {
            Console.WriteLine("Cannon print grey");
        }

        public void Fax(string content)
        {
            Console.WriteLine("Cannon fax");
        }
    }
}
