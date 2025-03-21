using System;
using MyLibrary;
using MyServices;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;


class Program
{
    static void Main()
    {
        int sum = Calculator.Add(10, 23);
        int diff = Calculator.Substract(100, 34);

        //wersja json (2)
        var result = new { Operation = "Add", A = 10, B = 23, Result = sum };

        //konfiguracja kontenera DI
        var serviceProvider = new ServiceCollection().AddSingleton<ILoggerService, ConsoleLogger>().BuildServiceProvider();

        //uzyskanie instancji loggera
        var logger = serviceProvider.GetService<ILoggerService>();
        logger.Log("Aplikacja uruchomiona.");

        Console.WriteLine($"Suma: {sum}"); //1 wersja
        Console.WriteLine($"Roznica: {diff}"); //1 wersja

        //wersja json (2)
        string jsonResult = JsonConvert.SerializeObject(result, Formatting.Indented);
        Console.WriteLine(jsonResult);

        //wersja 3 logger
        logger.Log($"Wynik dodawania: {sum}");
    }
}