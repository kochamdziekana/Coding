using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution
{
    public class MountainDuck : Duck
    {
        public override void Swim()
        {
            Console.WriteLine("Mountain Duck Swim");
        }

        public override void Quack()
        {
            Console.WriteLine("Mountain Duck Quack");
        }

        public override void Fly()
        {
            Console.WriteLine("Mountain Duck Flies");
        }
    }
}
