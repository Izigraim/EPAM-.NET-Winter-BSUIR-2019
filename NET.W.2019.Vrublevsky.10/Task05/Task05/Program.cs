using System;
using System.Collections.Generic;

namespace Task05
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[][] a = new int[][] { new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123, 2569, -546 }, new int[] { 123654 } };
            JaggedArraySortIComparer.Sorting(a, "qweq");

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    Console.Write("{0} ", a[i][j]);
                }

                Console.WriteLine();
            }
        }
    }
}
