using System;
using System.Collections.Generic;
using System.Linq;

namespace Decorator
{
    public class Program // nakłada obiekty na inne obiekty, coś jak nakładanie dodatków na pizzę
    {
        public static void Main(string[] args)
        {
            var pizzaBase = new MediumPizza();

            var mediumPizzaWithCheese = new CheesePizzaDecorator(pizzaBase);

            Console.WriteLine(mediumPizzaWithCheese.CalculatePrice());

            var mediumPizzaWithHam = new HamPizzaDecorator(mediumPizzaWithCheese);

            Console.WriteLine(mediumPizzaWithHam.CalculatePrice());
        }
    }
}