using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    public class TextAnalyzer
    {
        public static TextStatistics AnalyzeText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new TextStatistics();

            int characterCount = text.Length;
            int characterCountWithoutSpaces = text.Replace(" ", "").Length;
            int letterCount = text.Count(char.IsLetter);
            int digitCount = text.Count(char.IsDigit);
            int punctuationCount = text.Count(char.IsPunctuation);

            string[] words = text.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = words.Length;
            var uniqueWords = words.Distinct().ToList();
            int uniqueWordCount = uniqueWords.Count();

            string mostCommonWord = words.GroupBy(w => w.ToLower())
                                         .OrderByDescending(g => g.Count())
                                         .FirstOrDefault()?.Key;

            double averageWordLength = words.Length > 0 ? words.Average(w => w.Length) : 0;

            string longestWord = words.OrderByDescending(w => w.Length).FirstOrDefault();
            string shortestWord = words.OrderBy(w => w.Length).FirstOrDefault();

            string[] sentences = Regex.Split(text, @"(?<=[.!?])\s+");
            int sentenceCount = sentences.Length;
            double averageWordsPerSentence = sentences.Length > 0 ? sentences.Average(s => s.Split().Length) : 0;
            int longestSentence = sentences.Max(s => s.Split().Length);

            return new TextStatistics
            {
                CharacterCount = characterCount,
                CharacterCountWithoutSpaces = characterCountWithoutSpaces,
                LetterCount = letterCount,
                DigitCount = digitCount,
                PunctuationCount = punctuationCount,
                WordCount = wordCount,
                UniqueWordCount = uniqueWordCount,
                MostCommonWord = mostCommonWord,
                AverageWordLength = averageWordLength,
                LongestWord = longestWord,
                ShortestWord = shortestWord,
                SentenceCount = sentenceCount,
                AverageWordsPerSentence = averageWordsPerSentence,
                LongestSentence = longestSentence
            };
        }
    }
}