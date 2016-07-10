using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class CreditCardGenerator
    {
        // Generates random numbers
        private Random rng = new Random();

        public string generateCreditCard()
        {
            string num = "";
            num += rng.Next(1000, 9000).ToString();
            num += rng.Next(1000, 9000).ToString();
            num += rng.Next(1000, 9000).ToString();
            num += rng.Next(1000, 9000).ToString();
            return num;
        }
    }
}
