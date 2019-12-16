using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Task02GenericMatrix.Events;

namespace Task02GenericMatrix.Matrix
{
    /// <summary>
    /// Matrix.
    /// </summary>
    /// <typeparam name="T">Parameter type.</typeparam>
    public abstract class Matrix<T> : ElementChange<T>, IEnumerable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T}"/> class.
        /// </summary>
        /// <param name="array">Array.</param>
        public Matrix(T[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            this.ArrayValidation(array);
        }

        /// <summary>
        /// Occurs when element change.
        /// </summary>
        public event EventHandler<ElementChangeEventArgs<T>> ElementChange;

        /// <summary>
        /// Gets or sets size.
        /// </summary>
        /// <value>
        /// Size.
        /// </value>
        public int Size { get; protected set; }

        /// <summary>
        /// Gets or sets the <see cref="T"/> with specified indexes.
        /// </summary>
        /// <param name="i">Row.</param>
        /// <param name="j">Colomn.</param>
        /// <returns>Value.</returns>
        public T this[int i, int j]
        {
            get
            {
                if (i >= this.Size || j >= this.Size || i < 0 || j < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.GetValue(i, j);
            }

            set
            {
                if (i >= this.Size || j >= this.Size || i < 0 || j < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                T was = this.GetValue(i, j);
                this.SetValue(value, i, j);

                this.Subscribe(this);
                this.OnElementChange(this, new ElementChangeEventArgs<T>(i, j, was, value));
                this.Unsubscribe(this);
            }
        }

        protected abstract T GetValue(int i, int j);

        protected abstract void SetValue(T value, int i, int j);

        private void OnElementChange(object source, ElementChangeEventArgs<T> e)
        {
            this.ElementChange.Invoke(this, e);
        }

        private void ArrayValidation(T[,] array)
        {
            int rows = array.GetUpperBound(0) + 1;
            int colomns = array.Length / rows;

            if (rows != colomns)
            {
                throw new ArgumentException($"Rows and colomns should be equals.");
            }

            if (this.GetType() == typeof(SimmetricMatrix<T>))
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < colomns; j++)
                    {
                        if (!Equals(array[i, j], array[j, i]))
                        {
                            throw new ArgumentException("Can't build simmetric matrix.");
                        }
                    }
                }
            }

            if (this.GetType() == typeof(DiagonalMatrix<T>))
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < colomns; j++)
                    {
                        if (i != j && !Equals(default(T), array[i, j]))
                        {
                            throw new ArgumentException("Can't build diagonal matrix.");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns> An enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
