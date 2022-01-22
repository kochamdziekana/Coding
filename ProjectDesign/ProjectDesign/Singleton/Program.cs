using System;
using System.Collections.Generic;
using System.Linq;

namespace Singleton // łamie zasady pojedynczej odpowiedzialności i opne/close, ale da się obejść plus wartościowe 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // var cfg = new Configuration();   niedostępny konstruktor
            var cfg = Configuration.GetInstance();
            var cfg2 = Configuration.GetInstance();

            if (ReferenceEquals(cfg, cfg2))
            {
                Console.WriteLine("Configuration is a singleton.");
            }
        }
    }
}