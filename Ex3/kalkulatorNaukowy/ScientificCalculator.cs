//implementacja operacji naukowych przy uzyciu Calculator - potegowanie, pierwiastkowanie, logarytm naturalny
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkulatorNaukowy
{
    public class ScientificCalculator
    {
        private readonly Calculator calculator;

        public ScientificCalculator()
        {
            calculator = new Calculator();
        }

        public double power(double a, double b) => Math.Pow(a, b);
        public double squareRoot(double a)
        {
            if (a < 0)
            {
                throw new ArgumentException("nie mozna pierwiastkowac liczby ujemnej.");
            }
            return Math.Sqrt(a);
        }

        public double log(double a)
        {
            if (a <= 0)
            {
                throw new ArgumentException("logarytm mozna obliczac tylko dla liczb dodatnich.");
            }
            return Math.Log(a);
        }

        public Calculator GetBasicCalculator() => calculator;
    }
}
