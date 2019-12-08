using System;
using System.Diagnostics;

namespace Task04
{
    /// <summary>
    /// Class for finding greatest common divisor.
    /// </summary>
    public static class GCD
    {
        /// <summary>
        /// Find GCD of two numbers by Euclidian's algorithm.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The greatest common divisor.</returns>
        public static int GCDEuclidian(int a, int b)
        {
            if (a == b)
            {
                return a;
            }

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            a = Math.Abs(a);
            b = Math.Abs(b);

            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return a;
        }

        /// <summary>
        /// Find GCD of two numbers by Euclidian's algorithm.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="time">Elapsed time.</param>
        /// <returns>The greatest common divisor.</returns>
        public static int GCDEuclidian(int a, int b, out long time)
        {
            return FindGCD(GCDEuclidian, out time, a, b);
        }

        /// <summary>
        /// Find GCD of three numbers by Euclidian's algorithm.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <returns>The greatest common divisor.</returns>
        public static int GCDEuclidian(int a, int b, int c)
        {
            return FindGCD(GCDEuclidian, a, b, c);
        }

        /// <summary>
        /// Find GCD of three numbers by Euclidian's algorithm.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <param name="time">Elapsed time.</param>
        /// <returns>Greatest common divisor.</returns>
        public static int GCDEuclidian(int a, int b, int c, out long time)
        {
            return FindGCD(GCDEuclidian, out time, a, b, c);
        }

        /// <summary>
        /// Find GCD of four and more numbers by Euclidian's algorithm.
        /// </summary>
        /// <param name="arr">Numbers.</param>
        /// <returns>The greatest common divisor.</returns>
        public static int GCDEuclidian(params int[] arr)
        {
            return FindGCD(GCDEuclidian, arr);
        }

        /// <summary>
        /// Find GCD of four and more numbers by Euclidian's algorithm.
        /// </summary>
        /// <param name="time">Elapsed time.</param>
        /// <param name="arr">Numbers.</param>
        /// <returns>Greatest common divisor.</returns>
        public static int GCDEuclidian(out long time, params int[] arr)
        {
            return FindGCD(GCDEuclidian, out time, arr);
        }

        /// <summary>
        /// Find GCD of two numbers by binary Euclidian's algorithm.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>Greatest common divisor.</returns>
        public static int GCDEuclidianBinary(int a, int b)
        {
            if (a == b)
            {
                return a;
            }

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            a = Math.Abs(a);
            b = Math.Abs(b);

            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                {
                    return GCDEuclidianBinary(a >> 1, b);
                }
                else
                {
                    return GCDEuclidianBinary(a >> 1, b >> 1) << 1;
                }
            }

            if ((~b & 1) != 0)
            {
                return GCDEuclidianBinary(a, b >> 1);
            }

            if (a > b)
            {
                return GCDEuclidianBinary((a - b) >> 1, b);
            }

            return GCDEuclidianBinary((b - a) >> 1, a);
        }

        /// <summary>
        /// Find GCD of two numbers by binary Euclidian's algorithm.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="time">Elapsed time.</param>
        /// <returns>The greatest common divisor.</returns>
        public static int GCDEuclidianBinary(int a, int b, out long time)
        {
            return FindGCD(GCDEuclidianBinary, out time, a, b);
        }

        /// <summary>
        /// Find GCD of three numbers by binary Euclidian's algorithm.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <returns>The greatest common divisor.</returns>
        public static int GCDEuclidianBinary(int a, int b, int c)
        {
            return FindGCD(GCDEuclidianBinary, a, b, c);
        }

        /// <summary>
        /// Find GCD of three numbers by binary Euclidian's algorithm.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <param name="time">Elapsed time.</param>
        /// <returns>The greatest common divisor.</returns>
        public static int GCDEuclidianBinary(int a, int b, int c, out long time)
        {
            return FindGCD(GCDEuclidianBinary, out time, a, b, c);
        }

        /// <summary>
        /// Find GCD of four and more numbers by binary Euclidian's algorithm.
        /// </summary>
        /// <param name="arr">Numbers.</param>
        /// <returns>The greatest common divisor.</returns>
        public static int GCDEuclidianBinary(params int[] arr)
        {
            return FindGCD(GCDEuclidianBinary, arr);
        }

        /// <summary>
        /// Find GCD of four and more numbers by binary Euclidian's algorithm.
        /// </summary>
        /// <param name="time">Elapsed time.</param>
        /// <param name="arr">Numbers.</param>
        /// <returns>The greatest common divisor.</returns>
        public static int GCDEuclidianBinary(out long time, params int[] arr)
        {
            return FindGCD(GCDEuclidianBinary, out time, arr);
        }

        private static int FindGCD(Func<int, int, int> func, int a, int b, int c)
        {
            return func(func(a, b), c);
        }

        private static int FindGCD(Func<int, int, int> func, params int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            if (arr.Length <= 1)
            {
                throw new ArgumentException("Only 2 and more numbers.");
            }

            int result = arr[0];
            foreach (int i in arr)
            {
                result = func(result, i);
            }

            return result;
        }

        private static int FindGCD(Func<int, int, int> func, out long time, params int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            if (arr.Length <= 1)
            {
                throw new ArgumentException("Only 2 and more numbers.");
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            int result = FindGCD(func, arr);
            time = stopwatch.ElapsedTicks;
            stopwatch.Stop();
            return result;
        }
    }
}
