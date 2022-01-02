using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class ShapeFactory
    {
        public Shape CreateShape(ShapeType shapeType)
        {
            switch (shapeType)
            {
                case (ShapeType.Circle):
                    return new Circle();
                    break;
                case (ShapeType.Rectangle):
                    return new Rectangle();
                    break;
                case (ShapeType.Triangle):
                    return new Triangle();
                    break;
                default:
                    throw new Exception($"Shape type {shapeType} is not handled.");
            }
        }
    }
}
