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
        public void AddNumbers_WithCommaDelimiter()
        {// Act
            var result = StringCalculator.Add("1,2,3");

            // Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void AddNumbers_WithNewLinesAndDelimiter()
        {
            // Act
            var result = StringCalculator.Add("1\n2,3");

            // Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void AddNumbers_WithNewLinesAndCustomDelimiter()
        {
            // Arrange
            StringCalculator stringCalculator = new StringCalculator();

            // Act
            var result = StringCalculator.Add("//;\n1;2;1001");

            // Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void AddNumbers_WithNewLinesAndAnyDelimiterLength()
        {
            // Act
            var result = StringCalculator.Add("//[***]\n1***2***3");

            // Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void AddNumbers_WithNewLinesAndMultipleDelimiters()
        {
            // Act
            var result = StringCalculator.Add("//[*][%]\n1*2%3");

            // Assert
            Assert.AreEqual(6, result);
        }
    }
}