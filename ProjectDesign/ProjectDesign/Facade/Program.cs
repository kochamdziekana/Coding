using System;
using System.Collections.Generic;
using System.Linq;

namespace Facade
{
    public class Program // łączy klasy wewnętrzne korzysta z różnych obiektów nie odsłaniając przy okazji wnętrza
    {   // np udostępnienie interfejsu bez potrzeby pokazywania wszystkich kroków algorytmów w nim zawartych
        public static void Main(string[] args)
        {
            ScanFacade facade = new ScanFacade();

            facade.Scan("Joe Mama");
        }
    }
}