using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace Task01
{
    internal class Book : IEquatable<Book>
    {

        public Book(string isbn, string author, string name, string publishing, int yearOfPublishing, int countOfPages, double price)
        {
            this.ISBN = isbn;
            this.Author = author;
            this.Name = name;
            this.Publishing = publishing;
            this.YearOfPublishing = yearOfPublishing;
            this.CountOfPages = countOfPages;
            this.Price = price;
        }

        public string ISBN { get; set; }

        public string Author { get; set; }

        public string Name { get; set; }

        public string Publishing { get; set; }

        public int YearOfPublishing { get; set; }

        public int CountOfPages { get; set; }

        public double Price { get; set; }

        public static bool operator ==(Book b1, Book b2)
        {
            if (((object)b1) == null || ((object)b2) == null)
            {
                return object.Equals(b1, b2);
            }

            return b1.Equals(b2);
        }

        public static bool operator !=(Book b1, Book b2)
        {
            if (((object)b1) == null || ((object)b2) == null)
            {
                return !object.Equals(b1, b2);
            }

            return !b1.Equals(b2);
        }

        public bool Equals(Book b)
        {
            if (b == null)
            {
                return false;
            }

            if (this.Name == b.Name && this.Author == b.Author)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Book bookObj = obj as Book;
            if (bookObj == null)
            {
                return false;
            }
            else
            {
                return this.Equals(bookObj);
            }
        }

        public override string ToString()
        {
            string priceUs = string.Format(new CultureInfo("en-US"), "{0:c}", this.Price);
            return $"{this.ISBN} - {this.Author} - {this.Name} - {this.Publishing} - {this.YearOfPublishing} - {this.CountOfPages} - {priceUs}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static IComparer SortIsbn()
        {
            return (IComparer)new SortIsbnHelper();
        }

        public static IComparer SortAuthor()
        {
            return (IComparer)new SortAuthorHelper();
        }

        public static IComparer SortName()
        {
            return (IComparer)new SortNameHelper();
        }

        public static IComparer SortPublishing()
        {
            return (IComparer)new SortPublishingHelper();
        }

        public static IComparer SortYear()
        {
            return (IComparer)new SortYearHelper();
        }

        public static IComparer SortPages()
        {
            return (IComparer)new SortPagesHelper();
        }

        public static IComparer SortPrice()
        {
            return (IComparer)new SortPriceHelper();
        }

        public class SortIsbnHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Book b1 = (Book)a;
                Book b2 = (Book)b;
                return String.Compare(b1.ISBN, b2.ISBN);
            }
        }

        private class SortAuthorHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Book b1 = (Book)a;
                Book b2 = (Book)b;
                return String.Compare(b1.Author, b2.Author);
            }
        }

        private class SortNameHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Book b1 = (Book)a;
                Book b2 = (Book)b;
                return String.Compare(b1.Name, b2.Name);
            }
        }

        private class SortPublishingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Book b1 = (Book)a;
                Book b2 = (Book)b;
                return String.Compare(b1.Publishing, b2.Publishing);
            }
        }

        private class SortYearHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Book b1 = (Book)a;
                Book b2 = (Book)b;

                if (b1.YearOfPublishing > b2.YearOfPublishing)
                {
                    return 1;
                }
                else if (b1.YearOfPublishing < b2.YearOfPublishing)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        private class SortPagesHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Book b1 = (Book)a;
                Book b2 = (Book)b;

                if (b1.CountOfPages > b2.CountOfPages)
                {
                    return 1;
                }
                else if (b1.CountOfPages < b2.CountOfPages)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        private class SortPriceHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Book b1 = (Book)a;
                Book b2 = (Book)b;

                if (b1.Price > b2.Price)
                {
                    return 1;
                }
                else if (b1.Price < b2.Price)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
