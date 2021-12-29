using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectDesign
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Person person = new Person("Adam");

            System.Console.WriteLine(person.GetName());

        }
    }
}