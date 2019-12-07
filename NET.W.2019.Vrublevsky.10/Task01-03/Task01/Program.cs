using System;
using System.Collections.Generic;
using System.Globalization;

namespace Task01
{
    internal class Program
    {
        private static readonly BookListService BookListService = new BookListService();

        public static void AddBook()
        {
            string isbn;
            while (true)
            {
                try
                {
                    Console.Write("ISBN: ");
                    isbn = Console.ReadLine();
                    if (isbn.Length != 13)
                    {
                        throw new FormatException();
                    }

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("ISBN consist of 13 numbers.");
                }
            }

            Console.Write("Author: ");
            string author = Console.ReadLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Publishing: ");
            string publishing = Console.ReadLine();
            int yearOfPublishing = 0;
            while (true)
            {
                try
                {
                    Console.Write("Year of publishing: ");
                    yearOfPublishing = Convert.ToInt32(Console.ReadLine(), CultureInfo.CreateSpecificCulture("en-US"));
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorrect number format.");
                }
            }

            int countOfPages = 0;
            while (true)
            {
                try
                {
                    Console.Write("Count of pages: ");
                    countOfPages = Convert.ToInt32(Console.ReadLine(), CultureInfo.CreateSpecificCulture("en-US"));
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorrect number format.");
                }
            }

            double price = 0;
            while (true)
            {
                try
                {
                    Console.Write("Price: ");
                    price = Convert.ToDouble(Console.ReadLine(), CultureInfo.CreateSpecificCulture("en-US"));
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorrect number format.");
                }
            }

            Book b = new Book(isbn, author, name, publishing, yearOfPublishing, countOfPages, price);

            Program.BookListService.AddBook(b);

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public static void ShowBooks()
        {
            List<Book> books = BookListService.GetBooks();

            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"#{i + 1} " + books[i].ToString());
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public static void RemoveBook()
        {
            Console.Write("Author: ");
            string author = Console.ReadLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();

            List<Book> books = BookListService.GetBooks();

            try
            {
                Book b = books.Find(c => (c.Author == author) && (c.Name == name));
                if (b == null)
                {
                    throw new BookException("This book doesn't exist.");
                }
                else
                {
                    BookListService.RemoveBook(b);
                }
            }
            catch (BookException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public static void FindByTag()
        {
            Console.WriteLine("By which tag you want to find book?");
            Console.WriteLine("(ISBN/Author/Name/Publishing/Year/Pages/Price)");
            string tag = Console.ReadLine();
            Console.Write("Find: ");
            string find = Console.ReadLine();
            try
            {
                Book b = Program.BookListService.FindByTag(tag, find);
                Console.WriteLine(b.ToString());
            }
            catch (NullReferenceException)
            {
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public static void SortByTag()
        {
            Console.WriteLine("By which tag you want to sort books?");
            Console.WriteLine("(ISBN/Author/Name/Publishing/Year/Pages/Price)");
            string tag = Console.ReadLine();
            Program.BookListService.SortByTag(tag);

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                int i;

                // Console.WriteLine(string.Format(new ISBNFormat(), "{0:ISBN}", "1234567890123"));
                Console.WriteLine("1. Add new book.");
                Console.WriteLine("2. Remove book.");
                Console.WriteLine("3. Show all books.");
                Console.WriteLine("4. Find book by tag.");
                Console.WriteLine("5. Sort list of books.");
                Console.WriteLine("0. Exit.");
                try
                {
                    i = Convert.ToInt32(Console.ReadLine(), CultureInfo.CreateSpecificCulture("en-US"));
                }
                catch (FormatException)
                {
                    continue;
                }

                switch (i)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        RemoveBook();
                        break;
                    case 3:
                        ShowBooks();
                        break;
                    case 4:
                        FindByTag();
                        break;
                    case 5:
                        SortByTag();
                        break;
                    case 0: return;
                }

                Console.Clear();
            }
        }
    }
}
