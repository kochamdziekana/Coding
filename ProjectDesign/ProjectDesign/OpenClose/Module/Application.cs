using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClose.Module
{
    public class Application
    {

        public void Render(List<Shape> shapes)
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                //ShapeType type = shapes[i].ShapeType;
                //switch (type)
                //{
                //    case(ShapeType.Rectangle):
                //        RenderRectangle((Rectangle)shapes[i]);
                //        return;
                //
                //    case(ShapeType.Circle):
                //        RenderCircle((Circle)shapes[i]);
                //        return;
                //}

                shapes[i].Render(); // nie trzeba zmieniać nic w aplikacji, wystarczy dodać klasę dziedziczącą po Shape
            }
        }

        //public void RenderRectangle(Rectangle rectangle)
        //{
        //    Console.WriteLine("Render rectangle...");
        //}
        //
        //public void RenderCircle(Circle circle)
        //{
        //    Console.WriteLine("Render circle..");
        //}
    }
}
