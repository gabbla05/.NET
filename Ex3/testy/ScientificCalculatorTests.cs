using kalkulatorNaukowy;
using NUnit.Framework;
using System;

[TestFixture]
public class ScientificCalculatorTests
{
    private ScientificCalculator scientificCalculator;

    [SetUp]
    public void Setup()
    {
        scientificCalculator = new ScientificCalculator();
    }

    [Test]
    public void Power_ReturnsCorrectResult()
    {
        Assert.AreEqual(8, scientificCalculator.power(2, 3));
    }

    [Test]
    public void SquareRoot_ReturnsCorrectResult()
    {
        Assert.AreEqual(3, scientificCalculator.squareRoot(9));
    }

    [Test]
    public void SquareRoot_NegativeNumber_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => scientificCalculator.squareRoot(-9));
    }

    [Test]
    public void Log_ReturnsCorrectResult()
    {
        Assert.AreEqual(Math.Log(10), scientificCalculator.log(10));
    }

    [Test]
    public void Log_NonPositiveNumber_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => scientificCalculator.log(0));
        Assert.Throws<ArgumentException>(() => scientificCalculator.log(-1));
    }
}
