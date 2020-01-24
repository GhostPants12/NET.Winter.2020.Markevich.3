using System;
using NUnit.Framework;
using static NumbersExtension.NumbersExtension;

namespace NumbersExtension.Tests
{
    public class NumbersExtensionTests
    {
        #region IsPalindromeTests
        [TestCase(666, ExpectedResult = true)]
        [TestCase(10101, ExpectedResult = true)]
        [TestCase(20292, ExpectedResult = false)]
        [TestCase(505605, ExpectedResult = false)]
        [TestCase(606606, ExpectedResult = true)]
        [TestCase(909909, ExpectedResult = true)]
        public bool IsPalindrome_WithValidParameter(int param) =>
            IsPalindrome(param);

        [Test]
        public void IsPalindrome_NegativeParameter_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => IsPalindrome(-50), "Value cannot be less than zero");

        //171 ms
        [Test]
        [Order(2)]
        [Timeout(500)]
        public void PossiblyVerySlowCode_WithTimeLessThan1000Milliseconds()
        {
            for (int source = 0; source < 1_000_000; source++)
            {
                NumbersExtension.IsPalindrome(source);
            }
        }

        //1 sec
        [Test]
        [Order(1)]
        [Timeout(2_000)]
        public void PossiblyVerySlowCode_WithTimeLessThan25000Milliseconds()
        {
            for (int source = 0; source < 10_000_000; source++)
            {
                NumbersExtension.IsPalindrome(source);
            }
        }
        #endregion

        #region InsertNumberIntoAnotherTests
        [TestCase(2728, 655, 3, 8, ExpectedResult = 2680)]
        [TestCase(554216104, 15, 0, 31, ExpectedResult = 15)]
        [TestCase(-55465467, 345346, 0, 31, ExpectedResult = 345346)]
        [TestCase(554216104, 4460559, 11, 18, ExpectedResult = 554203816)]
        [TestCase(-1, 0, 31, 31, ExpectedResult = 2147483647)]
        [TestCase(-2147483648, 2147483647, 0, 30, ExpectedResult = -1)]
        [TestCase(-2223, 5440, 18, 23, ExpectedResult = -16517295)]
        [TestCase(2147481425, 5440, 18, 23, ExpectedResult = 2130966353)]
        [TestCase(0,1480,3,10,ExpectedResult = 1600)]
        [TestCase(15976,0,5,8,ExpectedResult =15880)]
        [TestCase(4,31,0,0,ExpectedResult =5)]
        [TestCase(63,63,0,0,ExpectedResult =63)]
        public int InsertNumberIntoAnother_WithAllValidParameters(int numberSource, int numberIn, int i, int j) =>
            InsertNumberIntoAnother(numberSource, numberIn, i, j);

        [Test]
        public void InsertNumberIntoAnother_I_GreaterThan_J_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => InsertNumberIntoAnother(256798, 190, 16, 8), "i is greater than j.");

        [TestCase(67, 56, 0, 32)]
        [TestCase(67, 56, 32, 32)]
        public void InsertNumberIntoAnother_Argument_OutOfRange_ThrowArgumentOutOfRangeException(int numberSource, int numberIn, int i, int j) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => InsertNumberIntoAnother(numberSource, numberIn, i, j));
        #endregion

        #region FindNthRootTests
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(4, 2, 0.0000001, 2)]
        [TestCase(0.05,3,0.01,0.368)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRoot_WithAllValidParameters(double number, int rootPower, double accuracy, double expected)
        {
            Assert.AreEqual((Math.Abs(expected - FindNthRoot(number, rootPower, accuracy)) < accuracy), true);
        }

        public static void FindNthRoot_NegativeNumberParameter_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => FindNthRoot(-50,2,0.0001), "Incorrect number");
        public static void FindNthRoot_AccuracyHigherThanEpsilonParameter_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => FindNthRoot(-50, 2, 2), "Accuracy is less or equak to zero or higher than Epsilon");
        public static void FindNthRoot_NegativeRootPowerParameter_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => FindNthRoot(50, -2, 0.0001), "RootPower is less than zero");
        #endregion
    }
}