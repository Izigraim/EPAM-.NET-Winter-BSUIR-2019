using System;
using System.Collections.Generic;
using System.Text;

namespace Task03BinarySearchTreeeTest
{
    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.name.Length > y.name.Length)
            {
                return 1;
            }
            else if (x.name.Length < y.name.Length)
            {
                return -1;
            }
            else
            {
                return -1;
            }
        }
    }
}
