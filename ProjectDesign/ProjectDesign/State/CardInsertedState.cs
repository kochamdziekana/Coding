using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class CardInsertedState : State
    {
        public CardInsertedState(Context context) : base(context)
        {

        }
        public override void EjectCard()
        {
            Console.WriteLine("Card ejected.");
            // _context -> NoCardState
            _context.ChangeState(new NoCardState(_context));
        }

        public override void InsertCard()
        {
            Console.WriteLine("Card already inserted.");
        }

        public override void InsertPin(int pin)
        {
            if(pin == 5555) // random number
            {
                Console.WriteLine("Correct PIN inserted.");
                // _context -> PinInsertedState
                _context.ChangeState(new PinInsertedState(_context));
            }
            else
            {
                Console.WriteLine("Incorrect PIN inserted.");
                EjectCard();
            }
        }

        public override void WithdrawCash(int amount)
        {
            Console.WriteLine("Insert PIN first.");
        }
    }
}
