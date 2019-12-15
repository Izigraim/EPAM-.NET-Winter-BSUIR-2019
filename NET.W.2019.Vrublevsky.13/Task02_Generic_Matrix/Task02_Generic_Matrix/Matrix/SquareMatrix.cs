using System;
using System.Collections.Generic;
using System.Text;

namespace Task02GenericMatrix.Matrix
{
    /// <summary>
    /// Square matrix class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SquareMatrix<T> : Matrix<T>
    {
        private readonly T[] array;

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="array">Array.</param>
        public SquareMatrix(T[,] array)
            : base(array)
        {
            this.Size = array.GetUpperBound(0) + 1;
            this.array = new T[array.Length];
            int i = 0;
            foreach (T t in array)
            {
                this.array[i++] = t;
            }
        }

        protected override T GetValue(int i, int j)
        {
            return this.array[(i * this.Size) + j];
        }

        protected override void SetValue(T value, int i, int j)
        {
            this.array[(i * this.Size) + j] = value;
        }
    }
}
