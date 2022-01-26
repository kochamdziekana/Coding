using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class HamPizzaDecorator : PizzaDecorator
    {
        public HamPizzaDecorator(IPizza pizza) : base(pizza)
        {
        }

        public override double CalculatePrice()
        {
            return base.CalculatePrice() + 5; // 5 bo uznajemy ze taką ma wartość ta szynka
        }
    }
}
