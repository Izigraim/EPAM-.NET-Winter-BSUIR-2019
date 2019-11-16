using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    class Program
    {
        /// <summary>
        /// FindNthRoot method. Calculate the root of the n-th degree of the number by
        /// Newton's method with a given accurancy.
        /// </summary>
        /// <param name="a">Number.</param>
        /// <param name="n">Degree.</param>
        /// <param name="eps">Accurancy.</param>
        /// <returns>If something wrong return null.
        /// If all works correct return the root.</returns>
        public static double? FindNthRoot(double a, double n, double eps)
        {
            if (a < 0 && (n % 2 == 0)) return null;

            double x0 = 1;
            double x1 = (1 / n) * ((n - 1) * x0 + a / Math.Pow(x0, (int)n - 1));

            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = (1 / n) * ((n - 1) * x0 + a / Math.Pow(x0, (int)n - 1));
            }
            return x1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("{0:0.##}",FindNthRoot(1, 5, 0.0001));
            Console.WriteLine("{0:0.##}",FindNthRoot(-8, 3, 0.0001));
            Console.WriteLine("{0:0.##}",FindNthRoot(0.001, 3, 0.0001));
            Console.WriteLine("{0:0.##}",FindNthRoot(0.04100625, 4, 0.0001));
            Console.WriteLine("{0:0.##}",FindNthRoot(8, 3, 0.0001));
            Console.WriteLine("{0:0.##}",FindNthRoot(0.0279936, 7, 0.0001));
            Console.WriteLine("{0:0.##}",FindNthRoot(0.0081, 4, 0.1));
        }
    }
}
