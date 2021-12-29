using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDesign
{
    class Person
    {
        private string Name { get; set; }

        public Person()
        {
            Name = "Noname";
        }

        public Person(string name)
        {
            Name = name;
        }

        public string GetName() { return Name; }

    }
}
