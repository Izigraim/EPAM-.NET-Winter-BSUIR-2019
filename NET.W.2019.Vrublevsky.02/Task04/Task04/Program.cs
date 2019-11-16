using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    class Program
    {
        /// <summary>
        /// FilterDigit method. Takes an array of integers and filters the array so that only the digits
        /// containing the specified digit remain in the output.
        /// </summary>
        /// <param name="a">Array of integer digits.</param>
        /// <param name="b">The digit by which to filter.</param>
        /// <returns>Filtered array</returns>
        public static int[] FilterDigit(int[] a, int b)
        {
            //Temp array, that contains filtered digits. It's nullable because default array filled with 0.
            int?[] temp = new int?[a.Length];
            int count = 0;
            foreach (int i in a)
            {
                if ((i.ToString()).Contains(b.ToString()))
                {
                    //Check whether this number was already.
                    if (temp.Contains(i)) continue;
                    temp[count] = i;
                    a[count] = i;
                    count++;
                }
            }
            //Array with filtered values.
            int[] answer = new int[count];
            Array.Copy(a, answer, count);
            return answer;
        }

        static void Main(string[] args)
        {
            foreach(int i in FilterDigit(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 10, 11, 12, 13, 14, 15, 16, 18, 19 }, 0))
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();

            foreach (int i in FilterDigit(new int[] { 7,1,2,3,4,5,6,7,68,69,70,15,17}, 7))
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();

            foreach (int i in FilterDigit(new int[] { 100,256,14785,125463,147852,1,3,5,4,6}, 9))
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }
    }
}
