using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution
{
    public class CityDuck : Duck
    {
        public override void Swim()
        {
            Console.WriteLine("City Duck Swim");
        }

        public override void Quack()
        {
            Console.WriteLine("City Duck Quack");
        }

        public override void Fly()
        {
            Console.WriteLine("City Duck Flies");
        }
    }
}
