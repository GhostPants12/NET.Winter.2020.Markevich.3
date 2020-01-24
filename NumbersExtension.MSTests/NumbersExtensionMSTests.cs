using Microsoft.VisualStudio.TestTools.UnitTesting;
using static NumbersExtension.NumbersExtension;
using System;

namespace NumbersExtension.MSTests
{
    [TestClass]
    public class NumbersExtensionMSTests
    {
        #region InsertNumberIntoAnotherTests

        [TestMethod]
        public void InsertNumberIntoAnother_WithValidParameters_Result1600()
        {
            int numberSource = 0;
            int numberIn = 1480;
            int i = 3;
            int j = 10;
            int expectedResult = 1600;

            int functionResult = InsertNumberIntoAnother(numberSource, numberIn, i, j);

            Assert.AreEqual(expectedResult, functionResult);
        }

        [TestMethod]
        public void InsertNumberIntoAnother_WithValidParameters_Result554203816()
        {
            int numberSource = 554216104;
            int numberIn = 4460559;
            int i = 11;
            int j = 18;
            int expectedResult = 554203816;

            int functionResult = InsertNumberIntoAnother(numberSource, numberIn, i, j);

            Assert.AreEqual(expectedResult, functionResult);
        }
        [DataTestMethod]
        [DataRow(24, 15, 2, 33)]
        [DataRow(256, 968, -2, 16)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumberIntoAnother_ArgumentIsOutOfRange_ThrowArgumentOutOfRangeException(int a, int b, int c, int d) =>
            InsertNumberIntoAnother(a, b, c, d);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumberIntoAnother_IIsHigherThanJ_ThrowArgumentException() =>
            InsertNumberIntoAnother(165, 248, 25, 3);

        #endregion

        #region IsPalindromeTests

        [TestMethod]
        public void IsPalindrome_Value909909_ExpectedTrue()
        {
            bool expected = true;
            bool result = IsPalindrome(909909);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsPalindrome_Value909999_ExpectedFalse()
        {
            bool expected = false;
            bool result = IsPalindrome(909999);
            Assert.AreEqual(expected, result);
        }

        #endregion
    }
}
