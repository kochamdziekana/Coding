using System;
using System.Collections.Generic;
using System.Linq;

namespace Strategy
{
    public class Program // enkapsulacja poszczególnych algorytmów, tutaj różnych algorytmów wyznaczania drogi, duża rozszerzalność kodu :--)
    {
        public static void Main(string[] args)
        {
            //var strategy = new BikeStrategy();
            var strategy = new CarStrategy();
            //var strategy = new WalkStrategy();

            var map = new Map(strategy);

            var start = new Coordinate();
            var end = new Coordinate();

            map.CreateRoute(start, end);
        }

    }
}