using NUnit.Framework;
using System;
using System.Linq;
using static ArrayExtension.ArrayExtension;

namespace ArrayExtension.Tests
{
    public class ArrayExtensionTests
    {
        #region FindBalanceIndexTests
        [TestCase(new int[10] { 10, 1, 2, 2, 1, 1, 1, 1, 1, 1 }, ExpectedResult = 1)]
        [TestCase(new int[5] { 1, 2, 3, 4, 6 }, ExpectedResult = 3)]
        [TestCase(new int[2] { 0, 0 }, ExpectedResult = null)]
        [TestCase(new int[3] { 0, 0, 0 }, ExpectedResult = 1)]
        [TestCase(new int[1] { 1 }, ExpectedResult = null)]
        [TestCase(new int[3] { 0,0,1 }, ExpectedResult = null)]
        [TestCase(new int[3] { int.MaxValue, int.MaxValue, int.MaxValue}, ExpectedResult =1 )]
        public int? FindBalanceIndex_WithAllValidParameters(int[] arr) =>
            FindBalanceIndex(arr);
        #endregion

        #region FindMaximumElementTests
        [TestCase(new int[5] { 1, 2, 3, 4, 5 }, ExpectedResult = 5)]
        [TestCase(new int[3] { 99999998, 99999999, 100000000 }, ExpectedResult = 100000000)]
        [TestCase(new int[10] { -1,2,-3,4,-5,6,-7,8,-9,10}, ExpectedResult =10)]
        public static int FindMaximumElement_WithAllValidParameters(int[] arr)
        {
            return FindMaximumElement(arr);
        }
        #endregion

        #region FilterArrayByKeyTests
        [TestCase(new[] { 2212332, 1405644, -1236674 }, 0, ExpectedResult = new[] { 1405644 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, 2, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7243, 10017 }, 7, ExpectedResult = new[] { -27, 173, 371132, 7556, 7243, 10017 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, 9, ExpectedResult = new int[0])]
        [TestCase(new[] { 15, 25, 60, 74, 189, int.MinValue, 32}, 2, ExpectedResult = new[] { 25, int.MinValue, 32 })]
        public static int[] FilterArrayBykey_WithAllValidParameters(int[] arr, int key) =>
            FilterArrayByKey(arr, key);
        public static void FilterArrayByKey_WithEmptyArray()=>Assert.Throws<ArgumentException>(() 
            => ArrayExtension.FilterArrayByKey(new int[0], 0));
        public static void FilterArrayByKey_WithNegativeKey() => Assert.Throws<ArgumentOutOfRangeException>(()
              => ArrayExtension.FilterArrayByKey(new int[] { 1, 2 }, -1));
        public static void FilterArrayByKey_KeyMoreThan9() => Assert.Throws<ArgumentOutOfRangeException>(()
              => ArrayExtension.FilterArrayByKey(new int[] { 1, 2 }, 100));
        public static void FilterArrayByKey_WithNullArray() => Assert.Throws<ArgumentNullException>(()
              => ArrayExtension.FilterArrayByKey(null, 0));
        #endregion
    }
}