using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class Program
    {
        /// <summary>
        /// InsertNumber method - insert bits from c-th to d-th of one number to another
        /// so that the bits of the second number took up positions with bit d-th through 
        /// bit c-th.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Right border of range.</param>
        /// <param name="d">Left border of range.</param>
        /// <returns>If something work incorrect - -1.
        /// If all works correct return int number.</returns>
        public static int InsertNumber(int a, int b, int c, int d)
        {
            if (c > d) return -1;

            string aBin = Convert.ToString(a, 2);
            string bBin = Convert.ToString(b, 2);

            //32 bits = 0
            StringBuilder answerBin = new StringBuilder("00000000000000000000000000000000");

            int i = answerBin.Length - c - 1;
            int j = answerBin.Length - d - 1;
            //Append first number to the end of answerBin
            answerBin.Remove(answerBin.Length - aBin.Length, aBin.Length);
            answerBin.Append(aBin);

            //ii - vaiable fro passing the array of the second number backwards
            int ii = 0;
            do
            {
                //if our second number array length less than range of (j - i)
                if (ii == bBin.Length) break;
                answerBin[i] = bBin[bBin.Length - 1 - ii];
                ii++;
                i--;

            } while (i != (j - 1));

            int answer = Convert.ToInt32(answerBin.ToString(), 2);
            Console.WriteLine(answer);
            Console.WriteLine(answerBin);
            return answer;
        }

        public static int Main(string[] args)
        {
            InsertNumber(15, 15, 0, 0);
            InsertNumber(8, 15, 0, 0);
            InsertNumber(8, 15, 3, 8);
            InsertNumber(10, 20, 6, 8);

            return 0;
        }
    }
}
