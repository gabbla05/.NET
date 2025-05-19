using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static readonly string[] BookUrls = new[]
    {
        "https://www.gutenberg.org/files/84/84-0.txt",
        "https://www.gutenberg.org/files/11/11-0.txt",
        "https://www.gutenberg.org/files/1661/1661-0.txt",
        "https://www.gutenberg.org/files/2701/2701-0.txt"
    };

    static async Task Main(string[] args)
    {
        var downloader = new Downloader();
        var analyzer = new TextAnalyzer();

        var downloadStopwatch = Stopwatch.StartNew();

        var tasks = BookUrls.Select(url => downloader.DownloadAsync(url)).ToArray();
        var texts = await Task.WhenAll(tasks);

        downloadStopwatch.Stop();
        Console.WriteLine($"Czas pobierania: {downloadStopwatch.Elapsed.TotalSeconds:F2} sekundy");

        var processStopwatch = Stopwatch.StartNew();

        Parallel.ForEach(texts, text =>
        {
            analyzer.Analyze(text);
        });

        processStopwatch.Stop();
        Console.WriteLine($"Czas przetwarzania: {processStopwatch.Elapsed.TotalSeconds:F2} sekundy");

        Console.WriteLine("Najczęstsze słowa:");
        analyzer.PrintTopWords(10);
    }
}
