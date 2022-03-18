using System;
using NUnit.Framework;

namespace StringCalculator
{
    public class Tests
    {
        [Test]
        public void EmptyString_Returns0()
        {
            // Act
            var result = StringCalculator.Add("");

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void NegatvieNumber_ThrowsException()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => StringCalculator.Add("-1,-2"));
        }

        [Test]
        [TestCase("1,2,3", 6)]
        [TestCase("5,18,37", 60)]
        [TestCase("20,20,100", 140)]
        public void AddNumbers_WithCommaDelimiter(string str, int expected)
        {// Act
            var result = StringCalculator.Add(str);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("1\n2,3", 6)]
        [TestCase("1\n4,6", 11)]
        [TestCase("5\n5,5", 15)]
        public void AddNumbers_WithNewLinesAndDelimiter(string str, int expected)
        {
            // Act
            var result = StringCalculator.Add(str);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("//;\n1;2", 3)]
        [TestCase("//^\n1^2^3", 6)]
        [TestCase("//!\n1!2!3!4!5", 15)]
        public void AddNumbers_WithNewLinesAndCustomDelimiter(string str, int expected)
        {
            // Act
            var result = StringCalculator.Add(str);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("//;\n1;2;1001", 3)]
        [TestCase("//;\n10;20;99999999", 30)]
        [TestCase("//;\n1;2;1000;1001", 1003)]
        public void AddNumbers_WithNumberGreaterThan1000_ReturnsCorrectSum(string str, int expected)
        {
            // Act
            var result = StringCalculator.Add(str);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[%*£!!!]\n1%*£!!!1001%*£!!!39%*£!!!11", 51)]
        [TestCase("//[%*£]\n33%*£33%*£33",99)]
        public void AddNumbers_WithNewLinesAndAnyDelimiterLength(string str, int expected)
        {
            // Act
            var result = StringCalculator.Add(str);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[%*£!!!][*][%]\n1%*£!!!2%19", 22)]
        [TestCase("//[%*£!!!][*][%]\n1001%*£!!!2%50", 52)]
        public void AddNumbers_WithNewLinesAndMultipleDelimiters(string str, int expected)
        {
            // Act
            var result = StringCalculator.Add(str);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}