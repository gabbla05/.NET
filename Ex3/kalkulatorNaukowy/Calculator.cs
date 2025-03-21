//implementacja podstawowych operacji - dodwanie, odejmowanie, mnozenie, dzielenie
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkulatorNaukowy
{
    public class Calculator
    {
        public double add(double a, double b) => a + b;
        public double subtract(double a, double b) => a - b;
        public double multiply(double a, double b) => a * b;
        public double divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("nie mozna dzielic przez 0.");
            return a / b;
        }

        public double sumSequence(IEnumerable<double> numbers) => numbers.Sum();
        public double average(IEnumerable<double> numbers) => numbers.Any() ? numbers.Average() : 0;
        public double max(IEnumerable<double> numbers) => numbers.Max();
        public double min(IEnumerable<double> numbers) => numbers.Min();
    }
}
