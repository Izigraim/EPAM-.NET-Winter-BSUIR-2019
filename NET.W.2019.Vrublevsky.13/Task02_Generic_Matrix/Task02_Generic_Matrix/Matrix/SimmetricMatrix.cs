using System;
using System.Collections.Generic;
using System.Text;

namespace Task02GenericMatrix.Matrix
{
    /// <summary>
    /// Simmetric matrix class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SimmetricMatrix<T> : Matrix<T>
    {
        private readonly T[] array;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimmetricMatrix{T}"/> class.
        /// </summary>
        /// <param name="array">Array.</param>
        public SimmetricMatrix(T[,] array)
            : base(array)
        {
            this.Size = array.GetUpperBound(0) + 1;
            this.array = new T[(this.Size + array.Length) / 2];
            for (int i = 0, k = 0; i < this.Size; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    this.array[k++] = array[i, j];
                }
            }
        }

        protected override T GetValue(int i, int j)
        {
            if (i < j)
            {
                this.Swap(ref i, ref j);
            }

            return this.array[this.FindIndex(i, j)];
        }

        protected override void SetValue(T value, int i, int j)
        {
            if (i < j)
            {
                Swap(ref i, ref j);
            }

            this.array[this.FindIndex(i, j)] = value;
        }

        private void Swap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }

        private int FindIndex(int i, int j)
        {
            int index = 0;
            for (int ii = 0; ii < this.Size; ii++)
            {
                for (int jj = 0; jj <= ii; jj++)
                {
                    if ((i == ii) && (j == jj))
                    {
                        return index;
                    }

                    index++;
                }
            }

            return -1;
        }
    }
}
