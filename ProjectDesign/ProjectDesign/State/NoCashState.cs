using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class NoCashState : State
    {
        public NoCashState(Context context) : base(context)
        {

        }
        public override void EjectCard()
        {
            Console.WriteLine("Sorry, we are out of cash"); // srednie bo stan jak NoCardState ale bez kasy
        }

        public override void InsertCard()
        {
            Console.WriteLine("Sorry, we are out of cash");
        }

        public override void InsertPin(int pin)
        {
            Console.WriteLine("Sorry, we are out of cash");
        }

        public override void WithdrawCash(int amount)
        {
            Console.WriteLine("Sorry, we are out of cash");
        }
    }
}
