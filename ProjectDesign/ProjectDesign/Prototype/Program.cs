using System;
using System.Collections.Generic;
using System.Linq;

namespace Prototype
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Circle circle = new Circle()
            {
                Radius = 5,
                X = 1,
                Y = 2,
                Border = new Border()
                {
                    Color = "Red",
                    Size = "2px"
                }
            };
        
            Circle circle2 = (Circle)circle.Clone();

            bool referenceEquals = ReferenceEquals(circle, circle2);

            Console.WriteLine($"ReferenceEquals: {referenceEquals}.");

            bool borderReferenceEquals = ReferenceEquals(circle.Border, circle2.Border);
            Console.WriteLine($"BorderReferenceEquals: {referenceEquals}.");

        }

    }
}