using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution
{
    public class RubberDuck : Duck
    {

        public override void Quack()
        {
            Console.WriteLine("Rubber Duck Swim");
        }

        public override void Swim()
        {
            Console.WriteLine("Rubber Duck Quack");
        }

        public override void Fly()  // ta kaczka nie potrafi latać, więc naruszona została zasada Liskov Substitution
        {
            throw new NotImplementedException();
        }
    }
}
