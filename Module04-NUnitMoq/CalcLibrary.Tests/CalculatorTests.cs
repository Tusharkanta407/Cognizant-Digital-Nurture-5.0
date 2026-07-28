using NUnit.Framework;
using CalcLibrary;
using System;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Init()
        {
            _calculator = new Calculator();
            Console.WriteLine("Setup Executed: Calculator instance re-initialized.");
        }

        [TearDown]
        public void Cleanup()
        {
            _calculator = null;
            Console.WriteLine("TearDown Executed: Resources cleared.");
        }

        [Test]
        public void Add_WhenCalledWithSimpleValues_ReturnsCorrectSum()
        {
            double result = _calculator.Add(10, 20);
            Assert.That(result, Is.EqualTo(30));
        }

        [TestCase(5.5, 4.5, 10.0)]
        [TestCase(-1.0, -1.0, -2.0)]
        [TestCase(0.0, 0.0, 0.0)]
        public void Add_ParameterizedTests_ReturnsExpectedResult(double a, double b, double expected)
        {
            double result = _calculator.Add(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Ignore("Demonstrating the Ignore attribute requested in objectives.")]
        [Test]
        public void Add_SkippedTestExample()
        {
            Assert.Fail("This test shouldn't run.");
        }
    }
}