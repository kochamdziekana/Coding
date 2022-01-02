using System;
using System.Collections.Generic;
using System.Linq;

namespace Factory
{
    public class Program
    {
        public static void Main(string[] args)
        {
          var shapeFactory = new ShapeFactory();

            var circle = shapeFactory.CreateShape(ShapeType.Circle);

            circle.Render();
            // triangle tak samo, co jest zresztą logiczne
        }   // klasa Program to klient

    }
}

// fabryka udostępnia wspólny interfejs do tworzenia klas bazowych
// Circle,Rectangle,Triangle -> Shape
// ShapeFactory tworzy obiekt Shape zależnie od wybranego rodzaju
// Kilent fabryki wykorzystuje fabrykę do wyświetlania
