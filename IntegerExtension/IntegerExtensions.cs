namespace IntegerExtension
{
    using System;

    /// <summary>
    /// An application entry point.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>Function that gets the gcd of two numbers by Euclidean method.</summary>
        /// <param name="firstNumber">The first input number.</param>
        /// <param name="secondNumber">The second input number.</param>
        /// <returns>The return is the gcd of two values.</returns>
        /// <exception cref="ArgumentException">Throws when the values are zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">firstNumber - One of the arguments is int.MinValue.
        /// or
        /// secondNumber - One of the arguments is int.MinValue.</exception>
        public static int GetGcdByEuclidean(int firstNumber, int secondNumber)
        {
            if (firstNumber == 0 && secondNumber == 0)
            {
                throw new ArgumentException("Two values cannot be zero at the same time.");
            }

            return GetEuclideanGcd(firstNumber, secondNumber);
        }

        /// <summary>>Gets the GCD by Euclidean method.</summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <param name="thirdNumber">The third number.</param>
        /// <returns>The gcd of three numbers.</returns>
        /// <exception cref="ArgumentException">Throws when all values are zero.</exception>
        public static int GetGcdByEuclidean(int firstNumber, int secondNumber, int thirdNumber)
        {
            if (firstNumber == 0 && secondNumber == 0 && thirdNumber == 0)
            {
                throw new ArgumentException("All values cannot be zero at the same time.");
            }

            return GetEuclideanGcd(GetEuclideanGcd(firstNumber, secondNumber), thirdNumber);
        }

        /// <summary>Gets the GCD by Euclidean method.</summary>
        /// <param name="mas">  The numbers.</param>
        /// <returns>Returns the gcd of the numbers.</returns>
        /// <exception cref="ArgumentException">Throws when there is only one parameter
        /// or
        /// when all arguments are zero.</exception>
        public static int GetGcdByEuclidean(params int[] mas)
        {
            if (mas.Length == 1)
            {
                throw new ArgumentException("There should be more than one parameter");
            }

            int zeroNumbersCounter = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] == 0)
                {
                    zeroNumbersCounter++;
                }
            }

            if (zeroNumbersCounter == mas.Length)
            {
                throw new ArgumentException("All arguments cannot be zero");
            }

            int bufGcd = GetEuclideanGcd(mas[0], mas[1]);
            for (int i = 2; i < mas.Length; i++)
            {
                bufGcd = GetEuclideanGcd(bufGcd, mas[i]);
            }

            return bufGcd;
        }

        /// <summary>Gets the time needed to get the gcd by Euclidean method.</summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>Returns the number of milliseconds needed to get the gcd by Euclidean method.</returns>
        public static long TimeForEuclidean(int firstNumber, int secondNumber)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            GetGcdByEuclidean(firstNumber, secondNumber);
            startTime.Stop();
            long resultTime = startTime.ElapsedMilliseconds;
            return resultTime;
        }

        /// <summary>Ticks for euclidean method.</summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>The number of ticks needed to get the gcd by Euclidean method.</returns>
        public static long TicksForEuclidean(int firstNumber, int secondNumber)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            GetGcdByEuclidean(firstNumber, secondNumber);
            startTime.Stop();
            long resultTime = startTime.ElapsedTicks;
            return resultTime;
        }

        /// <summary>Gets the time needed to get the gcd by Euclidean method.</summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <param name="thirdNumber">The third number.</param>
        /// <returns>Returns the number of milliseconds needed to get the gcd by Euclidean method.</returns>
        public static long TimeForEuclidean(int firstNumber, int secondNumber, int thirdNumber)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            GetGcdByEuclidean(firstNumber, secondNumber, thirdNumber);
            startTime.Stop();
            long resultTime = startTime.ElapsedMilliseconds;
            return resultTime;
        }

        /// <summary>Ticks for euclidean method.</summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <param name="thirdNumber">The third number.</param>
        /// <returns>The number of ticks needed to get the gcd by Euclidean method.</returns>
        public static long TicksForEuclidean(int firstNumber, int secondNumber, int thirdNumber)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            GetGcdByEuclidean(firstNumber, secondNumber, thirdNumber);
            startTime.Stop();
            long resultTime = startTime.ElapsedTicks;
            return resultTime;
        }

        /// <summary>Gets the time needed to get the gcd by Euclidean method.</summary>
        /// <param name="mas">  The numbers.</param>
        /// <returns>Returns the number of milliseconds needed to get the gcd by Euclidean method.</returns>
        public static long TimeForEuclidean(params int[] mas)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            GetGcdByEuclidean(mas);
            startTime.Stop();
            long resultTime = startTime.ElapsedMilliseconds;
            return resultTime;
        }

        /// <summary>Ticks for euclidean method.</summary>
        /// <param name="mas">  The numbers.</param>
        /// <returns>The number of ticks needed to get the gcd by Euclidean method.</returns>
        public static long TicksForEuclidean(params int[] mas)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            GetGcdByEuclidean(mas);
            startTime.Stop();
            long resultTime = startTime.ElapsedTicks;
            return resultTime;
        }

        /// <summary>Gets the GCD by Stein method.</summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>Returns the gcd of numbers.</returns>
        /// <exception cref="ArgumentException">Two values cannot be zero at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">firstNumber - One of the arguments is int.MinValue.
        /// or
        /// secondNumber - One of the arguments is int.MinValue.</exception>
        public static int GetGcdByStein(int firstNumber, int secondNumber)
        {
            if (firstNumber == 0 && secondNumber == 0)
            {
                throw new ArgumentException("Two values cannot be zero at the same time.");
            }

            return GetSteinGcd(firstNumber, secondNumber);
        }

        /// <summary>>Gets the GCD by Stein method.</summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <param name="thirdNumber">The third number.</param>
        /// <returns>The gcd of three numbers.</returns>
        /// <exception cref="ArgumentException">Throws when all arguments are zero.</exception>
        public static int GetGcdByStein(int firstNumber, int secondNumber, int thirdNumber)
        {
            if (firstNumber == 0 && secondNumber == 0 && thirdNumber == 0)
            {
                throw new ArgumentException("All values cannot be zero");
            }

            return GetSteinGcd(GetSteinGcd(firstNumber, secondNumber), thirdNumber);
        }

        /// <summary>Gets the GCD by Stein method.</summary>
        /// <param name="mas">  The numbers.</param>
        /// <returns>Returns the gcd of the numbers.</returns>
        /// <exception cref="ArgumentException">Throws when there is only one parameter
        /// or
        /// when all arguments are zero.</exception>
        public static int GetGcdByStein(params int[] mas)
        {
            if (mas.Length == 1)
            {
                throw new ArgumentException("There should be more than one parameter");
            }

            int zeroNumbersCounter = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] == 0)
                {
                    zeroNumbersCounter++;
                }
            }

            if (zeroNumbersCounter == mas.Length)
            {
                throw new ArgumentException("All arguments cannot be zero");
            }

            int bufGcd = GetSteinGcd(mas[0], mas[1]);
            for (int i = 2; i < mas.Length; i++)
            {
                bufGcd = GetSteinGcd(bufGcd, mas[i]);
            }

            return bufGcd;
        }

        /// <summary>Gets the time needed to get the gcd by Stein method.</summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>Returns the number of milliseconds needed to get the gcd by Stein method.</returns>
        public static long TimeForStein(int firstNumber, int secondNumber)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            GetGcdByStein(firstNumber, secondNumber);
            startTime.Stop();
            long resultTime = startTime.ElapsedMilliseconds;
            return resultTime;
        }

        /// <summary>Gets the ticks needed to get the gcd by Stein method.</summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>Returns the number of ticks needed to get the gcd by Stein method.</returns>
        public static long TicksForStein(int firstNumber, int secondNumber)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            GetGcdByStein(firstNumber, secondNumber);
            startTime.Stop();
            long resultTime = startTime.ElapsedTicks;
            return resultTime;
        }

        /// <summary>Gets the time needed to get the gcd by Stein method.</summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <param name="thirdNumber">The third number.</param>
        /// <returns>Returns the number of milliseconds needed to get the gcd by Stein method.</returns>
        public static long TimeForStein(int firstNumber, int secondNumber, int thirdNumber)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            GetGcdByStein(firstNumber, secondNumber, thirdNumber);
            startTime.Stop();
            long resultTime = startTime.ElapsedMilliseconds;
            return resultTime;
        }

        /// <summary>Gets the ticks needed to get the gcd by Stein method.</summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <param name="thirdNumber">The third number.</param>
        /// <returns>Returns the number of ticks needed to get the gcd by Stein method.</returns>
        public static long TicksForStein(int firstNumber, int secondNumber, int thirdNumber)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            GetGcdByStein(firstNumber, secondNumber, thirdNumber);
            startTime.Stop();
            long resultTime = startTime.ElapsedTicks;
            return resultTime;
        }

        /// <summary>Gets the time needed to get the gcd by Stein method.</summary>
        /// <param name = "mas" > The numbers.</param>
        /// <returns>Returns the number of milliseconds needed to get the gcd by Stein method.</returns>
        public static long TimeForStein(params int[] mas)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            GetGcdByStein(mas);
            startTime.Stop();
            long resultTime = startTime.ElapsedMilliseconds;
            return resultTime;
        }

        /// <summary>Gets the ticks needed to get the gcd by Stein method.</summary>
        /// <param name = "mas" > The numbers.</param>
        /// <returns>Returns the number of ticks needed to get the gcd by Stein method.</returns>
        public static long TicksForStein(params int[] mas)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            GetGcdByStein(mas);
            startTime.Stop();
            long resultTime = startTime.ElapsedTicks;
            return resultTime;
        }

        private static int GetEuclideanGcd(int firstNumber, int secondNumber)
        {
            if (firstNumber == 0 && secondNumber == 0)
            {
                return 1;
            }

            if (firstNumber == int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(firstNumber), "One of the arguments is int.MinValue.");
            }

            if (secondNumber == int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(secondNumber), "One of the arguments is int.MinValue.");
            }

            if (secondNumber == 0)
            {
                return Math.Abs(firstNumber);
            }

            return GetEuclideanGcd(secondNumber, firstNumber % secondNumber);
        }

        private static int GetSteinGcd(int firstNumber, int secondNumber)
        {
            if (firstNumber == int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(firstNumber), "One of the arguments is int.MinValue.");
            }

            if (secondNumber == int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(secondNumber), "One of the arguments is int.MinValue.");
            }

            int firstNumberAbs = Math.Abs(firstNumber);
            int secondNumberAbs = Math.Abs(secondNumber);
            if (firstNumberAbs == 0)
            {
                return secondNumberAbs;
            }

            if (secondNumberAbs == 0)
            {
                return firstNumberAbs;
            }

            int gcp;
            for (gcp = 0; ((firstNumberAbs | secondNumberAbs) & 1) == 0; ++gcp)
            {
                firstNumberAbs >>= 1;
                secondNumberAbs >>= 1;
            }

            while ((firstNumberAbs & 1) == 0)
            {
                firstNumberAbs >>= 1;
            }

            do
            {
                while ((secondNumberAbs & 1) == 0)
                {
                    secondNumberAbs >>= 1;
                }

                if (firstNumberAbs > secondNumberAbs)
                {
                    int temp = firstNumberAbs;
                    firstNumberAbs = secondNumberAbs;
                    secondNumberAbs = temp;
                }

                secondNumberAbs -= firstNumberAbs;
            }
            while (secondNumberAbs != 0);

            return firstNumberAbs << gcp;
        }
    }
}