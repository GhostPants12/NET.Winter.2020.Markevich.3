using System;
using NUnit.Framework;
using static IntegerExtension.IntegerExtensions;

namespace IntegerExtension.Tests
{
    public class IntegerExtensionsTests
    {
        #region EuclideanTests
        [TestCase(3, 15, ExpectedResult = 3)]
        [TestCase(18, 0, ExpectedResult = 18)]
        [TestCase(-7, -7, ExpectedResult = 7)]
        public static int GetGcdByEuclidean_With2ValidParameters(int firstNumber, int secondNumber) => GetGcdByEuclidean(firstNumber, secondNumber);

        [TestCase(100, 60, 40, ExpectedResult = 20)]
        [TestCase(5, 5, 5, ExpectedResult = 5)]
        [TestCase(100, 60, 16, ExpectedResult = 4)]
        [TestCase(100, -100, -50, ExpectedResult = 50)]
        [TestCase(1, 2, 3, ExpectedResult = 1)]
        [TestCase(-1, -2, -3, ExpectedResult = 1)]
        [TestCase(3, -3, 3, ExpectedResult = 3)]
        [TestCase(15, 5, 45, ExpectedResult = 5)]
        public static int GetGcdByEuclidean_With3ValidParameters(int firstNumber, int secondNumber, int thirdNumber) => GetGcdByEuclidean(firstNumber, secondNumber, thirdNumber);

        [TestCase(1, 1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue)]
        [TestCase(1, 0, 0, 1, 0)]
        [TestCase(1, 123413, 943578, 123413, 943578, 943578, int.MaxValue)]
        public void GetGcdByEuclidean_WithManyValidParameters(int expectedResult, params int[] vs)
        {
            int result = GetGcdByEuclidean(vs);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, 2, 3, 4, 5, int.MinValue)]
        public void GetGcdByEuclidean_WithMinValueParameter_ThrowsOutOfRangeException(params int[] vs) => 
            Assert.Throws<ArgumentOutOfRangeException>(() => GetGcdByEuclidean(vs));

        [TestCase(0, 0, 0, 0, 0, 0)]
        public void GetGcdByEuclidean_WithAllZeroParameters_ThrowsArgumentException(params int[] vs) =>
            Assert.Throws<ArgumentException>(() => GetGcdByEuclidean(vs));
        #endregion

        #region SteinTests
        [TestCase(3, 15, ExpectedResult = 3)]
        [TestCase(18, 0, ExpectedResult = 18)]
        [TestCase(-7, -7, ExpectedResult = 7)]
        public static int GetGcdByStein_With2ValidParameters(int firstNumber, int secondNumber) => GetGcdByStein(firstNumber, secondNumber);

        [TestCase(100, 60, 40, ExpectedResult = 20)]
        [TestCase(5, 5, 5, ExpectedResult = 5)]
        [TestCase(100, 60, 16, ExpectedResult = 4)]
        [TestCase(100, -100, -50, ExpectedResult = 50)]
        [TestCase(1, 2, 3, ExpectedResult = 1)]
        [TestCase(-1, -2, -3, ExpectedResult = 1)]
        [TestCase(3, -3, 3, ExpectedResult = 3)]
        [TestCase(15, 5, 45, ExpectedResult = 5)]
        public static int GetGcdByStein_With3ValidParameters(int firstNumber, int secondNumber, int thirdNumber) => GetGcdByStein(firstNumber, secondNumber, thirdNumber);

        [TestCase(1, 1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue)]
        [TestCase(1, 0, 0, 1, 0)]
        [TestCase(1, 123413, 943578, 123413, 943578, 943578, int.MaxValue)]
        public void GetGcdByStein_WithManyValidParameters(int expectedResult, params int[] vs)
        {
            int result = GetGcdByStein(vs);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, 2, 3, 4, 5, int.MinValue)]
        public void GetGcdByStein_WithMinValueParameter_ThrowsOutOfRangeException(params int[] vs) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => GetGcdByStein(vs));

        [TestCase(0, 0, 0, 0, 0, 0)]
        public void GetGcdByStein_WithAllZeroParameters_ThrowsArgumentException(params int[] vs) =>
            Assert.Throws<ArgumentException>(() => GetGcdByStein(vs));
        #endregion

        #region TimeTests
        [TestCase(213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue)]
        public void SteinTicksExists_WithAllValidParameters(params int[] vs)
        {
            long steinTicks = TicksForStein(vs);
            Assert.AreNotEqual(0, steinTicks);
        }

        [TestCase(213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue)]
        public void EuclideanTicksExists_WithAllValidParameters(params int[] vs)
        {
            long euclideanTicks = TicksForEuclidean(vs);
            Assert.AreNotEqual(0, euclideanTicks);
        }
        #endregion

        #region SpeedTests
        [TestCase(213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue)]
        [TestCase(123413, 943578, 123413, 943578, 943578, int.MaxValue)]
        public void SteinIsFaster_WithManyParameters(params int[] vs)
        {
            long steinTime = TimeForStein(vs);
            long steinTicks = TicksForStein(vs);
            long euclideanTime = TimeForEuclidean(vs);
            long euclideanTicks = TicksForEuclidean(vs);
            Assert.AreEqual(true, (steinTime <= euclideanTime && steinTicks < euclideanTicks));
        }

        [TestCase(213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue)]
        [TestCase(123413, 943578, 123413, 943578, 943578, int.MaxValue)]
        public void EuclideanIsFaster_WithManyParameters(params int[] vs)
        {
            long steinTime = TimeForStein(vs);
            long steinTicks = TicksForStein(vs);
            long euclideanTime = TimeForEuclidean(vs);
            long euclideanTicks = TicksForEuclidean(vs);
            Assert.AreEqual(true, (euclideanTime <= steinTime && euclideanTicks < steinTicks));
        }
        #endregion
    }
}