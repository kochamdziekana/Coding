using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Triangle : Shape
    {
        public override Shape Clone()
        {
            this.MemberwiseClone(); // płytka kopia, MemberwiseClone jest wbudowana w C# i można ją wywołać na każdym obiekcie
            return (Triangle)this.MemberwiseClone();
        }

        public override void Render()
        {
            Console.WriteLine("Render triangle.");
        }
    }
}
