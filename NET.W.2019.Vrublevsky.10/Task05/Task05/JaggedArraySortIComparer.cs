using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Task05
{
    public static class JaggedArraySortIComparer
    {

        public static int[][] Sorting(int[][] array, string typeSort)
        {
            switch (typeSort.ToUpper(new CultureInfo("en-US")))
            {
                case "SUMASC":
                    return SumAscFunc(CompareSum, array);
                case "SUMDESC":
                    return SumDescFunc(CompareSum, array);
                case "MAXASC":
                    return MaxAscFunc(CompareMax, array);
                case "MAXDESC":
                    return MaxDescFunc(CompareMax, array);
                case "MINASC":
                    return MinAscFunc(CompareMin, array);
                case "MINDESC":
                    return MinDescFunc(CompareMin, array);
                default:
                    return SumAscFunc(CompareSum, array);
            }
        }

        private static int[][] SumAscFunc(Func<int[], int[], int> func, int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (func(array[i], array[j]) > 0)
                    {
                        int[] temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        private static int[][] SumDescFunc(Func<int[], int[], int> func, int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (func(array[i], array[j]) < 0)
                    {
                        int[] temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        private static int[][] MaxAscFunc(Func<int[], int[], int> func, int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (func(array[i], array[j]) > 0)
                    {
                        int[] temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        private static int[][] MaxDescFunc(Func<int[], int[], int> func, int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (func(array[i], array[j]) < 0)
                    {
                        int[] temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        private static int[][] MinAscFunc(Func<int[], int[], int> func, int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (func(array[i], array[j]) > 0)
                    {
                        int[] temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        private static int[][] MinDescFunc(Func<int[], int[], int> func, int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (func(array[i], array[j]) < 0)
                    {
                        int[] temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        private static int CompareSum(int[] x, int[] y)
        {
            if (x.Sum() > y.Sum())
            {
                return 1;
            }
            else if (x.Sum() < y.Sum())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private static int CompareMax(int[] x, int[] y)
        {
            if (x.Max() > y.Max())
            {
                return 1;
            }
            else if (x.Max() < y.Max())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private static int CompareMin(int[] x, int[] y)
        {
            if (x.Min() > y.Min())
            {
                return 1;
            }
            else if (x.Min() < y.Min())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
