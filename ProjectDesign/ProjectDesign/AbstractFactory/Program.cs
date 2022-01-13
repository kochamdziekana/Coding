using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractFactory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new Application(new WindowsFactory());

            app.RenderUI();

            var app2 = new Application(new MacFactory());
            
            app2.RenderUI();
        }

    }
}
// klasa tworząca obiekty abstrakcyjne
// trochę jak abstrakcyjna fabryka dająca tworzyć takie same obiekty dla różnych implementacji