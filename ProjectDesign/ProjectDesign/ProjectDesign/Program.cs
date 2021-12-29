using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectDesign
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IPrinter printer = GetPrinter();
            Person person = new Person("Adam");

            System.Console.WriteLine(person.GetName());

            printer.Print("Kox ");

        }

        static IPrinter GetPrinter()
        {
            return new Hp();
        }
    }
}