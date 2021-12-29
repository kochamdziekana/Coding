using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDesign
{
    internal class Canon : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine("Canon printing " + text);
        }
    }
}
