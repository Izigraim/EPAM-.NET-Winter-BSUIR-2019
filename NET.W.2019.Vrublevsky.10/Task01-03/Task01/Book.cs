using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace Task01
{
    /// <summary>
    /// Book.
    /// </summary>
    internal class Book : IEquatable<Book>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="isbn">ISBN.</param>
        /// <param name="author">Author.</param>
        /// <param name="name">Name.</param>
        /// <param name="publishing">Publishing.</param>
        /// <param name="yearOfPublishing">Year of publishing.</param>
        /// <param name="countOfPages">Count of pages.</param>
        /// <param name="price">Price.</param>
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

        /// <summary>
        /// Gets or sets ISBN.
        /// </summary>
        /// <value>
        /// ISBN.
        /// </value>
        public string ISBN { get; set; }

        /// <summary>
        /// Gets or sets Author.
        /// </summary>
        /// <value>
        /// Author.
        /// </value>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        /// <value>
        /// Name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets publishing.
        /// </summary>
        /// <value>
        /// Publishing.
        /// </value>
        public string Publishing { get; set; }

        /// <summary>
        /// Gets or sets year of publishing.
        /// </summary>
        /// <value>
        /// Year of publishing.
        /// </value>
        public int YearOfPublishing { get; set; }

        /// <summary>
        /// Gets or sets count of pages.
        /// </summary>
        /// <value>
        /// Count of pages.
        /// </value>
        public int CountOfPages { get; set; }

        /// <summary>
        /// Gets or sets price.
        /// </summary>
        /// <value>
        /// Price.
        /// </value>
        public double Price { get; set; }

        /// <summary>
        /// Override '==' operator for <see cref="Book"/> class.
        /// </summary>
        /// <param name="b1">The first book.</param>
        /// <param name="b2">The second book.</param>
        /// <returns>True or false.</returns>
        public static bool operator ==(Book b1, Book b2)
        {
            if (((object)b1) == null || ((object)b2) == null)
            {
                return object.Equals(b1, b2);
            }

            return b1.Equals(b2);
        }

        /// <summary>
        /// Override '!=' operator for <see cref="Book"/> class.
        /// </summary>
        /// <param name="b1">The first book.</param>
        /// <param name="b2">The second book.</param>
        /// <returns>True or false.</returns>
        public static bool operator !=(Book b1, Book b2)
        {
            if (((object)b1) == null || ((object)b2) == null)
            {
                return !object.Equals(b1, b2);
            }

            return !b1.Equals(b2);
        }

        /// <summary>
        /// Indecates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="b">An another object to compare with this object.</param>
        /// <returns>True if the current object is equal. Otherwise, false.</returns>
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

        /// <summary>
        /// Indecates whether the current object is equal to another object of the another type.
        /// </summary>
        /// <param name="obj">An another object to compare with this object.</param>
        /// <returns>True if the current object is equal. Otherwise, false.</returns>
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

        /// <summary>
        /// Returns string that represents this instance.
        /// </summary>
        /// <returns>String that represents this instance.</returns>
        public override string ToString()
        {
            return this.ToString(string.Empty);
        }

        public string ToString(string fmt)
        {
            string priceUs = string.Format(new CultureInfo("en-US"), "{0:c}", this.Price);

            switch (fmt.ToUpper(new CultureInfo("en-US")))
            {
                case "A":
                    return string.Format("{0}, {1}", this.Author, this.Name);

                case "B":
                    return string.Format("{0}, {1}, {2}", this.Author, this.Name, this.Publishing);

                case "C":
                    return string.Format("ISBN {0}, {1}, {2}, {3}, {4}, P. {5}.", this.ISBN, this.Author, this.Name, this.Publishing, this.YearOfPublishing, this.CountOfPages);

                case "D":
                    return string.Format("ISBN {0}, {1}, {2}, {3}, {4}, P. {5}, {6}", this.ISBN, this.Author, this.Name, this.Publishing, this.YearOfPublishing, this.CountOfPages, priceUs);

                default:
                    return $"{this.ISBN} - {this.Author} - {this.Name} - {this.Publishing} - {this.YearOfPublishing} - {this.CountOfPages} - {priceUs}";

            }
        }

        /// <summary>
        /// The override of GetHasCode method.
        /// </summary>
        /// <returns>GetHasCode of this instance.</returns>
        public override int GetHashCode()
        {
            return (this.ISBN + this.Author + this.Name + this.Publishing + this.YearOfPublishing.ToString() + this.CountOfPages.ToString() + this.Price.ToString()).GetHashCode();
        }

        /// <summary>
        /// Method for sorting by <see cref="ISBN"/>  tag.
        /// </summary>
        /// <returns>IComparer for soring by <see cref="ISBN"/> tag.</returns>
        public static IComparer SortIsbn()
        {
            return (IComparer)new SortIsbnHelper();
        }

        /// <summary>
        /// Method for sorting by <see cref="Author"/>  tag.
        /// </summary>
        /// <returns>IComparer for sorting by <see cref="Author"/> tag.</returns>
        public static IComparer SortAuthor()
        {
            return (IComparer)new SortAuthorHelper();
        }

        /// <summary>
        /// Method for sorting by <see cref="Name"/>  tag.
        /// </summary>
        /// <returns>OComparer for sorting by <see cref="Name"/> tag.</returns>
        public static IComparer SortName()
        {
            return (IComparer)new SortNameHelper();
        }

        /// <summary>
        /// Method for sorting by <see cref="Publishing"/> tag.
        /// </summary>
        /// <returns>IComparer for sorting by <see cref="Publishing"/> tag.</returns>
        public static IComparer SortPublishing()
        {
            return (IComparer)new SortPublishingHelper();
        }

        /// <summary>
        /// Method for sorting by <see cref="YearOfPublishing"/> tag.
        /// </summary>
        /// <returns>IComparer for sorting by <see cref="YearOfPublishing"/> tag.</returns>
        public static IComparer SortYear()
        {
            return (IComparer)new SortYearHelper();
        }

        /// <summary>
        /// Method for sorting by <see cref="CountOfPages"/> tag.
        /// </summary>
        /// <returns>IComparer for sorting by <see cref="CountOfPages"/> tag.</returns>
        public static IComparer SortPages()
        {
            return (IComparer)new SortPagesHelper();
        }

        /// <summary>
        /// Method for sorting by <see cref="Price"/> tag.
        /// </summary>
        /// <returns>IComparer for sorting by <see cref="Price"/> tag.</returns>
        public static IComparer SortPrice()
        {
            return (IComparer)new SortPriceHelper();
        }

        private class SortIsbnHelper : IComparer
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
