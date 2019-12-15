using System;
using System.Collections.Generic;
using System.Text;

namespace Task02GenericMatrix.Matrix
{
    /// <summary>
    /// Diagonal matrix class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DiagonalMatrix<T> : Matrix<T>
    {
        private readonly T[] array;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="array">Array.</param>
        public DiagonalMatrix(T[,] array)
            : base(array)
        {
            this.Size = array.GetUpperBound(0) + 1;
            this.array = new T[this.Size];
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    if (i == j)
                    {
                        this.array[i] = array[i, j];
                    }
                }
            }
        }

        protected override T GetValue(int i, int j)
        {
            if (i == j)
            {
                return this.array[i];
            }
            else
            {
                return default;
            }
        }

        protected override void SetValue(T value, int i, int j)
        {
            if (i == j)
            {
                this.array[i] = value;
            }
            else
            {
                throw new ArgumentException("Can't set element that not diagonal.");
            }
        }
    }
}
