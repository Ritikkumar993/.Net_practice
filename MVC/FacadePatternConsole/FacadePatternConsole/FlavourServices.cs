using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePatternConsole
{
    public class FlavourServices
    {
        public string GetFlavor()
        {
            Console.WriteLine("Getting your favorite flavor...");
            return "Vanilla";
        }
    }
}
