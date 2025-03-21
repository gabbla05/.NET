using kalkulatorNaukowy;
using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class CalculatorTests
{
    private Calculator calculator;

    [SetUp]
    public void Setup()
    {
        calculator = new Calculator();
    }

    [Test]
    public void Add_ReturnsCorrectResult()
    {
        Assert.AreEqual(5, calculator.add(2, 3));
    }

    [Test]
    public void Subtract_ReturnsCorrectResult()
    {
        Assert.AreEqual(1, calculator.subtract(5, 4));
    }

    [Test]
    public void Multiply_ReturnsCorrectResult()
    {
        Assert.AreEqual(20, calculator.multiply(5, 4));
    }

    [Test]
    public void Divide_ReturnsCorrectResult()
    {
        Assert.AreEqual(2, calculator.divide(10, 5));
    }

    [Test]
    public void Divide_ByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => calculator.divide(10, 0));
    }

    [Test]
    public void SumSequence_ReturnsCorrectResult()
    {
        var numbers = new List<double> { 1, 2, 3, 4 };
        Assert.AreEqual(10, calculator.sumSequence(numbers));
    }

    [Test]
    public void Average_ReturnsCorrectResult()
    {
        var numbers = new List<double> { 2, 4, 6, 8 };
        Assert.AreEqual(5, calculator.average(numbers));
    }

    [Test]
    public void Max_ReturnsCorrectResult()
    {
        var numbers = new List<double> { 3, 5, 7, 2 };
        Assert.AreEqual(7, calculator.max(numbers));
    }

    [Test]
    public void Min_ReturnsCorrectResult()
    {
        var numbers = new List<double> { 3, 5, 7, 2 };
        Assert.AreEqual(2, calculator.min(numbers));
    }
}
