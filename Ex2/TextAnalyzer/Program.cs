using System;

namespace TextAnalyzer
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Podaj tekst do analizy:");
            string inputText = Console.ReadLine();

            var stats = TextAnalyzer.AnalyzeText(inputText);

            Console.WriteLine($"Liczba znaków (ze spacjami): {stats.CharacterCount}");
            Console.WriteLine($"Liczba znaków (bez spacji): {stats.CharacterCountWithoutSpaces}");
            Console.WriteLine($"Liczba liter: {stats.LetterCount}");
            Console.WriteLine($"Liczba cyfr: {stats.DigitCount}");
            Console.WriteLine($"Liczba znaków interpunkcyjnych: {stats.PunctuationCount}");
            Console.WriteLine($"Liczba słów: {stats.WordCount}");
            Console.WriteLine($"Liczba unikalnych słów: {stats.UniqueWordCount}");
            Console.WriteLine($"Najczęściej występujące słowo: {stats.MostCommonWord}");
            Console.WriteLine($"Średnia długość słowa: {stats.AverageWordLength}");
            Console.WriteLine($"Najdłuższe słowo: {stats.LongestWord}");
            Console.WriteLine($"Najkrótsze słowo: {stats.ShortestWord}");
            Console.WriteLine($"Liczba zdań: {stats.SentenceCount}");
            Console.WriteLine($"Średnia liczba słów na zdanie: {stats.AverageWordsPerSentence}");
            Console.WriteLine($"Najdłuższe zdanie (w liczbie słów): {stats.LongestSentence}");
        }
    }
}
