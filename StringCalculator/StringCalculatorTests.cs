using NUnit.Framework;

namespace StringCalculator
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void EmptyString_Returns0()
        {
            // Arrange
            StringCalculator stringCalculator = new StringCalculator();

            // Act
            var result = stringCalculator.Add("");

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void AddNumbers_WithCommaDelimiter()
        {
            // Arrange
            StringCalculator stringCalculator = new StringCalculator();

            // Act
            var result = stringCalculator.Add("1,2,3");

            // Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void AddNumbers_WithNewLinesAndDelimiter()
        {
            // Arrange
            StringCalculator stringCalculator = new StringCalculator();

            // Act
            var result = stringCalculator.Add("1\n2,3");

            // Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void AddNumbers_WithNewLinesAndCustomDelimiter()
        {
            // Arrange
            StringCalculator stringCalculator = new StringCalculator();

            // Act
            var result = stringCalculator.Add("//;\n1;2");

            // Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void AddNumbers_WithNewLinesAndAnyDelimiterLength()
        {
            // Arrange
            StringCalculator stringCalculator = new StringCalculator();

            // Act
            var result = stringCalculator.Add("//[***]\n1***2***3");

            // Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void AddNumbers_WithNewLinesAndMultipleDelimiters()
        {
            // Arrange
            StringCalculator stringCalculator = new StringCalculator();

            // Act
            var result = stringCalculator.Add("//[*][%]\n1*2%3");

            // Assert
            Assert.AreEqual(6, result);
        }
    }
}