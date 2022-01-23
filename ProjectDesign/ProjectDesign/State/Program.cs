using System;
using System.Collections.Generic;
using System.Linq;

namespace State
{
    public class Program // zmienia zachowanie obiektu przez zmianę stanu (State), obiekt działa w sposób zależny od swojego stanu
    {
        public static void Main(string[] args)
        {
            var context = new Context();

            context.EjectCard();

            context.InsertCard();
            context.InsertPin(4444);

            context.InsertCard();
            context.InsertPin(5555);
            context.WithdrawCash(2000);
            context.InsertCard();

        }
    }


}