using System;

namespace Task02
{
    public static class JaggedArraySort
    {
        /// <summary>
        /// Sorting jagged array in ascending order of sums of matrix row elements.
        /// </summary>
        /// <param name="array">Unsorted array.</param>
        /// <returns>Sorted array.</returns>
        public static int[][] SumByAsc(params int[][] array)
        {
            int[] sums = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sums[i] += array[i][j];
                }
            }

            return SortAsc(sums, array);
        }

        /// <summary>
        /// Sorting jagged array in descending order of sums of matrix row elements.
        /// </summary>
        /// <param name="array">Unsorted array.</param>
        /// <returns>Sorted array./returns>
        public static int[][] SumByDesc(params int[][] array)
        {
            int[] sums = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sums[i] += array[i][j];
                }
            }

            return SortDesc(sums, array);
        }

        /// <summary>
        /// Sorting jagged array in ascending order of the maximum elements of the matrix rows.
        /// </summary>
        /// <param name="array">Unsorted array.</param>
        /// <returns>Sorted array.</returns>
        public static int[][] MaxByAsc(params int[][] array)
        {
            int[] maxs = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int max = int.MinValue;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > max)
                    {
                        max = array[i][j];
                    }
                }

                maxs[i] = max;
            }

            return SortAsc(maxs, array);
        }

        /// <summary>
        /// Sorting jagged array in descending order of the maximum elements of the matrix rows.
        /// </summary>
        /// <param name="array">Usorted array.</param>
        /// <returns>Sorted array.</returns>
        public static int[][] MaxByDesc(params int[][] array)
        {
            int[] maxs = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int max = int.MinValue;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > max)
                    {
                        max = array[i][j];
                    }
                }

                maxs[i] = max;
            }

            return SortDesc(maxs, array);
        }

        /// <summary>
        /// Sorting jagged array in descending order of minimum elements of the matrix rows.
        /// </summary>
        /// <param name="array">Unsorted array.</param>
        /// <returns>Sorted array.</returns>
        public static int[][] MinByAsc(params int[][] array)
        {
            int[] mins = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int min = int.MaxValue;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] < min)
                    {
                        min = array[i][j];
                    }
                }

                mins[i] = min;
            }

            return SortAsc(mins, array);
        }

        /// <summary>
        /// Sorting jagged array in descending order of the minimum elements of the matrix rows.
        /// </summary>
        /// <param name="array">Unsorted array.</param>
        /// <returns>Sorted array.</returns>
        public static int[][] MinByDesc(params int[][] array)
        {
            int[] mins = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int min = int.MaxValue;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] < min)
                    {
                        min = array[i][j];
                    }
                }

                mins[i] = min;
            }

            return SortDesc(mins, array);
        }

        private static int[][] SortAsc(int[] extra, int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (extra[i] > extra[j])
                    {
                        int tmp = extra[i];
                        extra[i] = extra[j];
                        extra[j] = tmp;

                        int[] temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        private static int[][] SortDesc(int[] extra, int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (extra[i] < extra[j])
                    {
                        int tmp = extra[i];
                        extra[i] = extra[j];
                        extra[j] = tmp;

                        int[] temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }
    }
}
