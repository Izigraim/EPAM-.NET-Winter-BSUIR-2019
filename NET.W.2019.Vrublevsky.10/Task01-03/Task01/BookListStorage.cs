using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Task01
{
    /// <summary>
    /// A clas for working with a book store.
    /// </summary>
    public static class BookListStorage
    {
        private static readonly string path = AppDomain.CurrentDomain.BaseDirectory + "Books.dat";

        /// <summary>
        /// Add new <see cref="Book"/> to binary file.
        /// </summary>
        /// <param name="b">Instance of <see cref="Book"/></param>
        public static void AddToFile(Book b)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append)))
                {
                    writer.Write(b.ISBN);
                    writer.Write(b.Author);
                    writer.Write(b.Name);
                    writer.Write(b.Publishing);
                    writer.Write(b.YearOfPublishing);
                    writer.Write(b.CountOfPages);
                    writer.Write(b.Price);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Read all book from file.
        /// </summary>
        /// <returns>List of books.</returns>
        public static List<Book> ReadFromFile()
        {
            List<Book> booksFromFile = new List<Book>();

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string isbn = reader.ReadString();
                        string author = reader.ReadString();
                        string name = reader.ReadString();
                        string publishing = reader.ReadString();
                        int year = reader.ReadInt32();
                        int pages = reader.ReadInt32();
                        double price = reader.ReadDouble();

                        Book b = new Book(isbn, author, name, publishing, year, pages, price);
                        booksFromFile.Add(b);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return booksFromFile;
        }

        /// <summary>
        /// Save sorted list of books to file.
        /// </summary>
        /// <param name="books">Sorted list of books.</param>
        public static void SaveSortToFile(List<Book> books)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                {
                    foreach (Book b in books)
                    {
                        writer.Write(b.ISBN);
                        writer.Write(b.Author);
                        writer.Write(b.Name);
                        writer.Write(b.Publishing);
                        writer.Write(b.YearOfPublishing);
                        writer.Write(b.CountOfPages);
                        writer.Write(b.Price);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Remove <see cref="Book"/> from file.
        /// </summary>
        /// <param name="books">List of books without removed book.</param>
        public static void RemoveFromFile(List<Book> books)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
                {
                    foreach (Book b in books)
                    {
                        writer.Write(b.ISBN);
                        writer.Write(b.Author);
                        writer.Write(b.Name);
                        writer.Write(b.Publishing);
                        writer.Write(b.YearOfPublishing);
                        writer.Write(b.CountOfPages);
                        writer.Write(b.Price);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
