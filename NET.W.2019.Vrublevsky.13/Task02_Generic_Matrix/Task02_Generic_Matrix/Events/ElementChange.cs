using System;
using System.Collections.Generic;
using System.Text;
using Task02GenericMatrix.Matrix;

namespace Task02GenericMatrix.Events
{
    /// <summary>
    /// Element change class.
    /// </summary>
    /// <typeparam name="T">Parameter type.</typeparam>
    public class ElementChange<T>
    {
        /// <summary>
        /// Subscribe the matrix to event.
        /// </summary>
        /// <param name="matrix"></param>
        public void Subscribe(Matrix<T> matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            matrix.ElementChange += this.Message;
        }

        /// <summary>
        /// Unsubscribe the matrix from event.
        /// </summary>
        /// <param name="matrix"></param>
        public void Unsubscribe(Matrix<T> matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            matrix.ElementChange -= this.Message;
        }

        private void Message(object sender, ElementChangeEventArgs<T> e)
        {
            Console.WriteLine($"Element [{e.I},{e.J}] was changed from {e.Was} to {e.Became}.");
        }
    }
}
