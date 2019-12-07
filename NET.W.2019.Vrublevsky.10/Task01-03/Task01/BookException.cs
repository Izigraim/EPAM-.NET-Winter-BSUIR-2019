using System;
using System.Collections.Generic;
using System.Text;

namespace Task01
{
    /// <summary>
    /// Specified exceptions for <see cref="Book"/>.
    /// </summary>
    public class BookException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        public BookException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookException"/> class.
        /// </summary>
        public BookException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="innerException">Inner exception.</param>
        public BookException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
