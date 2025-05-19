using System;
using System.Collections.Concurrent;
using System.Linq;

public class TextAnalyzer
{
    public ConcurrentDictionary<string, int> WordCounts = new ConcurrentDictionary<string, int>();

    public void Analyze(string text)
    {
        var separators = new[] { ' ', '\r', '\n', '\t', '.', ',', ';', ':', '-', '!', '?', '"', '\'', '(', ')', '[', ']', '{', '}' };
        var words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                        .Select(w => w.ToLowerInvariant());

        foreach (var word in words)
        {
            WordCounts.AddOrUpdate(word, 1, (key, count) => count + 1);
        }
    }

    public void PrintTopWords(int count)
    {
        var top = WordCounts.OrderByDescending(kvp => kvp.Value).Take(count);
        int i = 1;
        foreach (var kvp in top)
        {
            Console.WriteLine($"{i++}. {kvp.Key}: {kvp.Value}");
        }
    }
}
