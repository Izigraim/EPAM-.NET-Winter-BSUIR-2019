using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Vrublevsky._01
{
    public class Program
    {
        /// <summary>
        /// Quick Sort method.
        /// </summary>
        /// <param name="array">Unsorted array.</param>
        /// <param name="first">Sort start index.</param>
        /// <param name="last">Sort end index.</param>
        /// <returns>Sorted array.</returns>
        public static int[] QuickSort(int[] array, int first, int last)
        {
            if(first < last)
            {
                int left = first, right = last, middle = array[(left + right) / 2];
                do
                {
                    while (array[left] < middle) left++;
                    while (array[right] > middle) right--;
                    if (left <= right)
                    {
                        int temp = array[left];
                        array[left] = array[right];
                        array[right] = temp;
                        left++;
                        right--;
                    }
                } while (left <= right);
                if (first < right) QuickSort(array, first, right);
                if (left < last) QuickSort(array, left, last);
            }
            return array;
        }

        /// <summary>
        /// Merge sort recurcive.
        /// </summary>
        /// <param name="array"> Unsorted array.</param>
        /// <param name="left">Sort start index.</param>
        /// <param name="right">Sort end index.</param>
        /// <returns>Sorted array.</returns>
        public static int[] MergeSort(int[] array, int left, int right)
        {
            int mid;

            if(right > left)
            {
                mid = (right + left) / 2;
                MergeSort(array, left, mid);
                MergeSort(array, (mid + 1), right);
                Merge(array, left, (mid + 1), right);
            }

            return array;
        }

        public static void Merge(int[] array, int left, int mid, int right)
        {
            int[] temp = new int[array.Length];
            int leftEnd = mid - 1, length = right - left + 1, pos = left;
            while((left <= leftEnd) && (mid <= right))
            {
                if(array[left] <= array[mid])
                {
                    temp[pos++] = array[left++];
                }
                else
                {
                    temp[pos++] = array[mid++];
                }
            }

            while(left <= leftEnd)
            {
                temp[pos++] = array[left++];
            }
            while(mid <= right)
            {
                temp[pos++] = array[mid++];
            }
            for(int i = 0; i <length; i++)
            {
                array[right] = temp[right];
                right--;
            }
        }

        public static void Main(string[] args)
        {
            Random rand = new Random();

            int[] arrayQS = new int[rand.Next(0, 30)];
            int[] arrayMerge = new int[arrayQS.Length];

            for (int i = 0; i < arrayQS.Length; i++)
                arrayQS[i] = rand.Next(0, 100);

            Array.Copy(arrayQS, arrayMerge, arrayQS.Length);

            QuickSort(arrayQS, 0, arrayQS.Length - 1);

            Console.WriteLine("QuickSort: ");
            for (int i = 0; i < arrayQS.Length; i++)
                Console.Write("{0} ", arrayQS[i]);
            MergeSort(arrayMerge, 0, arrayMerge.Length - 1);
            Console.WriteLine("\nMergeSort: ");
            for (int i = 0; i < arrayQS.Length; i++)
                Console.Write("{0} ", arrayMerge[i]);
        }
    }
}
