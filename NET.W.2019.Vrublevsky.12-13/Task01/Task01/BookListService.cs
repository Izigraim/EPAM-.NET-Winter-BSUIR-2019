using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Task01
{
    /// <summary>
    /// Service to work with a books.
    /// </summary>
    public class BookListService
    {
        private List<Book> books = BookListStorage.ReadFromFile();

        /// <summary>
        /// Add new <see cref="Book"/> to list..
        /// </summary>
        /// <param name="b"><see cref="Book"/> instance.</param>
        public void AddBook(Book b)
        {
            try
            {
                if (this.books.Find(c => (c.Author == b.Author) && (c.Name == b.Name)) != null)
                {
                    throw new BookException("This book is already exist.");
                }
                else
                {
                    this.books.Add(b);
                    BookListStorage.AddToFile(b);
                    Program.Logger.Info("The book is successfully added.");
                }
            }
            catch (BookException ex)
            {
                Program.Logger.Error(ex.Message);
            }
        }

        /// <summary>
        /// Remove <see cref="Book"/> from list.
        /// </summary>
        /// <param name="b"><see cref="Book"/> instance.</param>
        public void RemoveBook(Book b)
        {
            this.books.Remove(b);
            BookListStorage.RemoveFromFile(this.books);
            Program.Logger.Info("The book is successfully remove.");
        }

        /// <summary>
        /// Return list of all books.
        /// </summary>
        /// <returns>List of all books.</returns>
        public List<Book> GetBooks()
        {
            return this.books;
        }

        /// <summary>
        /// Find <see cref="Book"/> by tag.
        /// </summary>
        /// <param name="tag">Tag.</param>
        /// <param name="find">Find query.</param>
        /// <returns>Instance of book.</returns>
        public Book FindByTag(string tag, string find)
        {
            Book b = null;
            tag = tag.ToLower(CultureInfo.CreateSpecificCulture("en-US"));
            List<string> tags = new List<string> { "isbn", "author", "name", "publishing", "year", "pages", "price" };
            try
            {
                if (!tags.Contains(tag))
                {
                    throw new BookException("Incorrect tag.");
                }
            }
            catch (BookException ex)
            {
                Program.Logger.Error(ex.Message);
                return null;
            }

            switch (tag)
            {
                case "isbn":
                    b = this.books.Find(c => c.ISBN == find);
                    break;
                case "author":
                    b = this.books.Find(c => c.Author == find);
                    break;
                case "name":
                    b = this.books.Find(c => c.Name == find);
                    break;
                case "publishing":
                    b = this.books.Find(c => c.Publishing == find);
                    break;
                case "year":
                    b = this.books.Find(c => c.YearOfPublishing == Convert.ToInt32(find, CultureInfo.CreateSpecificCulture("en-US")));
                    break;
                case "pages":
                    b = this.books.Find(c => c.CountOfPages == Convert.ToInt32(find, CultureInfo.CreateSpecificCulture("en-US")));
                    break;
                case "price":
                    b = this.books.Find(c => c.Price == Convert.ToDouble(find, CultureInfo.CreateSpecificCulture("en-US")));
                    break;
            }

            return b;
        }

        /// <summary>
        /// Sort list of books by tag.
        /// </summary>
        /// <param name="tag">Tag.</param>
        public void SortByTag(string tag)
        {
            if (tag == null)
            {
                return;
            }

            tag = tag.ToLower(CultureInfo.CreateSpecificCulture("en-US"));
            List<string> tags = new List<string> { "isbn", "author", "name", "publishing", "year", "pages", "price" };
            try
            {
                if (!tags.Contains(tag))
                {
                    throw new BookException("Incorrect tag.");
                }
            }
            catch (BookException ex)
            {
                Program.Logger.Error(ex.Message);
                return;
            }

            var a = this.books.ToArray();
            switch (tag)
            {
                case "isbn":
                    {
                        Array.Sort(a, Book.SortIsbn());
                        this.books = a.ToList();
                    }

                    break;
                case "author":
                    {
                        Array.Sort(a, Book.SortAuthor());
                        this.books = a.ToList();
                    }

                    break;
                case "name":
                    {
                        Array.Sort(a, Book.SortName());
                        this.books = a.ToList();
                    }

                    break;
                case "publishing":
                    {
                        Array.Sort(a, Book.SortPublishing());
                        this.books = a.ToList();
                    }

                    break;
                case "year":
                    {
                        Array.Sort(a, Book.SortYear());
                        this.books = a.ToList();
                    }

                    break;
                case "pages":
                    {
                        Array.Sort(a, Book.SortPages());
                        this.books = a.ToList();
                    }

                    break;
                case "price":
                    {
                        Array.Sort(a, Book.SortPrice());
                        this.books = a.ToList();
                    }

                    break;
            }

            BookListStorage.SaveSortToFile(this.books);
        }
    }
}
