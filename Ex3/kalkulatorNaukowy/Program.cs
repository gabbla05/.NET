//punkt wejsciowy aplikacji

using kalkulatorNaukowy;

class Program
{
    static void Main(string[] args)
    {
        CalculatorService service = new CalculatorService();
        service.run();
    }
}