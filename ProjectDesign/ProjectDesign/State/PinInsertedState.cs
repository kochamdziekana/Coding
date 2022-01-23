using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class PinInsertedState : State
    {
        public PinInsertedState(Context context) : base(context)
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
            Console.WriteLine("Correct PIN already inserted.");
        }

        public override void WithdrawCash(int amount)
        {
            if(amount > _context.Cash)
            {
                Console.WriteLine("The machine doesn't have that amount of money.");
            }
            else
            {
                Console.WriteLine($"You have withdrawn {amount} from the machine.");
                _context.Cash -= amount;

                if(_context.Cash == 0)
                {
                    // _context -> NoCashState
                    _context.ChangeState(new NoCashState(_context));
                }
                else
                {
                    EjectCard();
                }
            }
        }
    }
}
