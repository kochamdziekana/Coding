using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Rectangle : Shape
    {
        public override Shape Clone()
        {
            Rectangle cloneBase = (Rectangle)this.MemberwiseClone();

            cloneBase.Border = new Border() // dzięki temu tworzymy klona bo tworzymy nowy obiekt powiązany z Circle, tj. Border
            {
                Size = Border.Size,
                Color = Border.Color
            };

            return cloneBase;
        }

        public override void Render()
        {
            Console.WriteLine("Render rectangle.");
        }
    }
}
