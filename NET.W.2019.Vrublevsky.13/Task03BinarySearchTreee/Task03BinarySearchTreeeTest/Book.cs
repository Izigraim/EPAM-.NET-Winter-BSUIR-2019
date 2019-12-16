using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Task03BinarySearchTreeeTest
{
    public class Book : IComparable<Book>
    {
        public string name;
        public int countPages;

        public Book(string name, int countPages)
        {
            this.name = name;
            this.countPages = countPages;
        }

        public int CompareTo(Book other)
        {
            if (other == null)
            {
                return 1;
            }

            if (this.countPages > other.countPages)
            {
                return 1;
            }
            else if (this.countPages < other.countPages)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return this.name == (obj as Book).name && this.countPages == (obj as Book).countPages;
        }
    }
}
