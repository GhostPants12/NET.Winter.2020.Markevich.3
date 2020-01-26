namespace ArrayExtension
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An application entry point.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>Finds the index of the "balance" element.</summary>
        /// <param name="arr">The array.</param>
        /// <returns>Returns index of element if it exists or null.</returns>
        /// <exception cref="System.ArgumentNullException">Argument is null.</exception>
        /// <exception cref="System.ArgumentException">Array is empty.</exception>
        public static int? FindBalanceIndex(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Argument is null.");
            }

            if (arr.Length == 0)
            {
                throw new ArgumentException("Array is empty.");
            }

            if (arr.Length < 3)
            {
                return null;
            }

            long sumBeforeElement;
            long sumAfterElement;
            for (int i = 1; i < arr.Length - 1; i++)
            {
                sumBeforeElement = 0;
                for (int j = 0; j <= i - 1; j++)
                {
                    sumBeforeElement += arr[j];
                }

                sumAfterElement = 0;
                for (int j = i + 1; j <= arr.Length - 1; j++)
                {
                    sumAfterElement += arr[j];
                }

                if (sumBeforeElement == sumAfterElement)
                {
                    return i;
                }
            }

            return null;
        }

        /// <summary>Filters the array by key.</summary>
        /// <param name="arr">The array.</param>
        /// <param name="key">The key.</param>
        /// <returns>Sorted array.</returns>
        /// <exception cref="ArgumentNullException">Array is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">key - Key is out of range.</exception>
        /// <exception cref="ArgumentException">Array is empty.</exception>
        public static int[] FilterArrayByKey(int[] arr, int key)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Array is null.");
            }

            if (key < 0 || key > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(key), "Key is out of range");
            }

            if (arr.Length == 0)
            {
                throw new ArgumentException("Array is empty");
            }

            int buf;
            List<int> outList = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                buf = arr[i];
                if (Validate(buf, key))
                {
                    outList.Add(buf);
                }
            }

            return outList.ToArray();
        }

        /// <summary>Finds the maximum element of an array.</summary>
        /// <param name="arr">The array.</param>
        /// <returns>Maximum element of the array.</returns>
        /// <exception cref="ArgumentNullException">Argument is null.</exception>
        /// <exception cref="ArgumentException">Array is empty.</exception>
        public static int FindMaximumElement(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Argument is null.");
            }

            if (arr.Length == 0)
            {
                throw new ArgumentException("Array is empty.");
            }

            return MaximumInRange(arr, 0, arr.Length - 1);
        }

        private static int MaximumInRange(int[] arr, int leftNumber, int rightNumber)
        {
            if (leftNumber == rightNumber)
            {
                return arr[rightNumber];
            }
            else
            {
                int leftBuff = MaximumInRange(arr, leftNumber, (leftNumber + rightNumber) / 2);
                int rightBuff = MaximumInRange(arr, ((leftNumber + rightNumber) / 2) + 1, rightNumber);

                return Math.Max(leftBuff, rightBuff);
            }
        }

        private static bool Validate(int number, int key)
        {
            do
            {
                if (Math.Abs(number % 10) == key)
                {
                    return true;
                }

                number /= 10;
            }
            while (number != 0);
            return false;
        }
    }
}
