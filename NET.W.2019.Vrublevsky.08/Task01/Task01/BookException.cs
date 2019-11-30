using System;
using System.Collections.Generic;
using System.Text;

namespace Task01
{
    internal class BookException : ArgumentException
    {
        public BookException(string message)
            : base(message)
        {
        }

        public BookException()
        {
        }

        public BookException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
