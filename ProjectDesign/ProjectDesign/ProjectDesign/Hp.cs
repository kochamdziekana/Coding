using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDesign
{
    internal class Hp : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine("Hp printing " + text);
        }
    }
}
