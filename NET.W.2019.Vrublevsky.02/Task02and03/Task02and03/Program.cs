using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02and03
{
    class Program
    {
        /// <summary>
        /// FindNextBiggerNumber method. Takes a positive integer and returns the nearest bigest integer consisting
        /// of the digits of the original number.
        /// Also return the time of finding a given number.
        /// </summary>
        /// <param name="a">Positive integer number.</param>
        /// <param name="sp">Time of finding the number.</param>
        /// <returns>If something works wrong or bigest number doesn't exist return -1.
        /// If all work corrct return nearest bigest number.</returns>
        public static int FindNextBiggerNumber(int a, out TimeSpan sp)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int[] b = a.ToString().Select(c => (int)Char.GetNumericValue(c)).ToArray();

            if (b.Length < 2)
            {
                stopWatch.Stop();
                sp = stopWatch.Elapsed;
                return -1;
            }

            int first = b.Length - 1;
            int second = b.Length - 2;

            for (int i = b.Length - 2; i >= -1; i--)
            {
                if (i == -1)
                {
                    stopWatch.Stop();
                    sp = stopWatch.Elapsed;
                    return -1;
                }
                if (b[i] >= b[i + 1])
                {
                    continue;
                }
                else if (b[i] < b[i] + 1)
                {
                    first = i;
                    break;
                }
            }

            for (int i = b.Length - 1; i >= 0; i--)
            {
                if (b[i] <= b[first]) continue;
                else
                {
                    second = i;
                    int tmp = b[second];
                    b[second] = b[first];
                    b[first] = tmp;
                    break;
                }
            }

            second = b.Length - 1;
            for(int i = first +1; i <second; i++)
            {
                int tmp = b[i];
                b[i] = b[second];
                b[second] = tmp;
                second--;
            }

            a = Convert.ToInt32(String.Join("", b.Select(p => p.ToString()).ToArray()));

            stopWatch.Stop();
            sp = stopWatch.Elapsed;

            return a;
        }

        public static int Main(string[] args)
        {
            TimeSpan sp = new TimeSpan();
            Console.WriteLine(FindNextBiggerNumber(12, out sp));
            Console.WriteLine(sp);
            Console.WriteLine(FindNextBiggerNumber(513, out sp));
            Console.WriteLine(sp);
            Console.WriteLine(FindNextBiggerNumber(2017, out sp));
            Console.WriteLine(sp);
            Console.WriteLine(FindNextBiggerNumber(414, out sp));
            Console.WriteLine(sp);
            Console.WriteLine(FindNextBiggerNumber(144, out sp));

            return 0;
        }
    }
}
