using System;
using System.Collections.Generic;
using System.Linq;

namespace Observer
{
    public class Program // wzorzec tworzący mechanizm powiadamiający obiekty o zmianach w obserwowanym obiekcie
    {
        public static void Main(string[] args)
        {
            Subscriber sub1 = new Subscriber("sub1");
            Subscriber sub2 = new Subscriber("sub2");

            var publisher = new Publisher();

            publisher.Subscribe(sub1);
            publisher.Subscribe(sub2);

            publisher.Notify("test message");

            publisher.Unsubscribe(sub1);

            publisher.Notify("test message 2");
        }

    }
}