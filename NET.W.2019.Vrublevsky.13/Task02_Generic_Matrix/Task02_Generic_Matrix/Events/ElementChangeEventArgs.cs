using System;
using System.Collections.Generic;
using System.Text;

namespace Task02GenericMatrix.Events
{
    /// <summary>
    /// Element change event args class.
    /// </summary>
    /// <typeparam name="T">Parameter type.</typeparam>
    public class ElementChangeEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElementChangeEventArgs{T}"/> class.
        /// </summary>
        /// <param name="i">Row.</param>
        /// <param name="j">Colomn.</param>
        /// <param name="was">Old value of the element.</param>
        /// <param name="became">New value of the element.</param>
        public ElementChangeEventArgs(int i, int j, T was, T became)
        {
            this.I = i;
            this.J = j;
            this.Was = was;
            this.Became = became;
        }

        /// <summary>
        /// Gets I.
        /// </summary>
        /// <value>
        /// I.
        /// </value>
        public int I { get; private set; }

        /// <summary>
        /// Gets J.
        /// </summary>
        /// <value>
        /// J.
        /// </value>
        public int J { get; private set; }

        /// <summary>
        /// Gets was.
        /// </summary>
        /// <value>
        /// Was.
        /// </value>
        public T Was { get; private set; }

        /// <summary>
        /// Gets Became.
        /// </summary>
        /// <value>
        /// Became.
        /// </value>
        public T Became { get; private set; }
    }
}
