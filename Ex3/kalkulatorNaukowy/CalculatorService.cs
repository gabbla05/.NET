//interakcja z uzytkownikiem
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkulatorNaukowy
{
    public class CalculatorService
    {
        private readonly ScientificCalculator scientificCalculator;

        public CalculatorService()
        {
            scientificCalculator = new ScientificCalculator();
        }

        public void run()
        {
            Console.WriteLine("Kalkulator naukowy");
            Console.WriteLine("Wybierz operacje: +, -, *, /, ^, sqrt, log, sum, avg, max, min");
            string operation = Console.ReadLine();

            if (operation == "sum" || operation == "avg" || operation == "max" || operation == "min")
            {
                Console.WriteLine("Podaj liczby oddzielone spacja: ");
                var numbers = Console.ReadLine()
                                 .Split(' ')
                                 .Select(double.Parse)
                                 .ToList();
                switch (operation)
                {
                    case "sum": Console.WriteLine($"Suma: {scientificCalculator.GetBasicCalculator().sumSequence(numbers)}"); break;
                    case "avg": Console.WriteLine($"Średnia: {scientificCalculator.GetBasicCalculator().average(numbers)}"); break;
                    case "max": Console.WriteLine($"Maksimum: {scientificCalculator.GetBasicCalculator().max(numbers)}"); break;
                    case "min": Console.WriteLine($"Minimum: {scientificCalculator.GetBasicCalculator().min(numbers)}"); break;
                }
            }
            else
            {
                Console.WriteLine("Podaj pierwszą liczbę:");
                double a = double.Parse(Console.ReadLine());

                double b = 0;
                if (operation != "sqrt" && operation != "log")
                {
                    Console.WriteLine("Podaj drugą liczbę:");
                    b = double.Parse(Console.ReadLine());
                }

                try
                {
                    double result = operation switch
                    {
                        "+" => scientificCalculator.GetBasicCalculator().add(a, b),
                        "-" => scientificCalculator.GetBasicCalculator().subtract(a, b),
                        "*" => scientificCalculator.GetBasicCalculator().multiply(a, b),
                        "/" => scientificCalculator.GetBasicCalculator().divide(a, b),
                        "^" => scientificCalculator.power(a, b),
                        "sqrt" => scientificCalculator.squareRoot(a),
                        "log" => scientificCalculator.log(a),
                        _ => throw new InvalidOperationException("Nieznana operacja.")
                    };

                    Console.WriteLine($"Wynik: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd: {ex.Message}");
                }
            }
        }
    }
}
