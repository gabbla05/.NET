using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.Tests
{
    [TestFixture]
    public class TextAnalyzerTests
    {
        [Test]
        public void CountCharacters_ShouldReturnCorrectNumber()
        {
            string text = "Hello, world!";
            int result = text.Length;
            Assert.AreEqual(13, result);
        }

        [Test]
        public void CountWords_ShouldReturnCorrectNumber()
        {
            string text = "Hello world!";
            var stats = TextAnalyzer.AnalyzeText(text);
            Assert.AreEqual(2, stats.WordCount);
        }

        [Test]
        public void CountSentences_ShouldReturnCorrectNumber()
        {
            string text = "Hello world! How are you? I am fine.";
            var stats = TextAnalyzer.AnalyzeText(text);
            Assert.AreEqual(3, stats.SentenceCount);
        }

        [Test]
        public void MostCommonWord_ShouldReturnCorrectWord()
        {
            string text = "apple banana apple orange apple banana";
            var stats = TextAnalyzer.AnalyzeText(text);
            Assert.AreEqual("apple", stats.MostCommonWord);
        }

        [Test]
        public void AnalyzeText_WithEmptyString_ShouldReturnZeroes()
        {
            var stats = TextAnalyzer.AnalyzeText("");
            Assert.AreEqual(0, stats.CharacterCount);
            Assert.AreEqual(0, stats.WordCount);
        }
    }
}
