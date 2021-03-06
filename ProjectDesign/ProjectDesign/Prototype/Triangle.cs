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
            // this.MemberwiseClone(); - płytka kopia, MemberwiseClone jest wbudowana w C# i można ją wywołać na każdym obiekcie
            Triangle cloneBase = (Triangle)this.MemberwiseClone();

            cloneBase.Border = new Border() // dzięki temu tworzymy klona bo tworzymy nowy obiekt powiązany z Circle, tj. Border
            {
                Size = Border.Size,
                Color = Border.Color
            };

            return cloneBase;
        }

        public override void Render()
        {
            Console.WriteLine("Render triangle.");
        }
    }
}
