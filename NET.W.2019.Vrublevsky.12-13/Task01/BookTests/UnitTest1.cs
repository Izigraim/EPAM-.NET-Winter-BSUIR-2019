using System;
using NUnit.Framework;
using Task01;

namespace BookTests
{
    public class Tests
    {
        private static object[] _bookToStringDefaultSource = { new object[] { new Book("1234567891234", "1", "1", "1", 1, 1, 1.0), "1234567891234 - 1 - 1 - 1 - 1 - 1 - $1.00" },
                                                        new object[] { new Book("1478587272778", "2", "2", "2", 2, 2, 2.0), "1478587272778 - 2 - 2 - 2 - 2 - 2 - $2.00"} };

        private static object[] _bookToStringASource = { new object[] { new Book("1234567891234", "1", "1", "1", 1, 1, 1.0), "1, 1" },
                                                        new object[] { new Book("1478587272778", "2", "2", "2", 2, 2, 2.0), "2, 2" } };

        private static object[] _bookToStringBSource = { new object[] { new Book("1234567891234", "1", "1", "1", 1, 1, 1.0), "1, 1, 1" },
                                                        new object[] { new Book("1478587272778", "2", "2", "2", 2, 2, 2.0), "2, 2, 2" } };

        private static object[] _bookToStringCSource = { new object[] { new Book("1234567891234", "1", "1", "1", 1, 1, 1.0), "ISBN 123-4-5678-9123-4, 1, 1, 1, 1, P. 1." },
                                                        new object[] { new Book("1478587272778", "2", "2", "2", 2, 2, 2.0), "ISBN 147-8-5872-7277-8, 2, 2, 2, 2, P. 2." } };

        private static object[] _bookToStringDSource = { new object[] { new Book("1234567891234", "1", "1", "1", 1, 1, 1.0), "ISBN 123-4-5678-9123-4, 1, 1, 1, 1, P. 1, $1.00" },
                                                        new object[] { new Book("1478587272778", "2", "2", "2", 2, 2, 2.0), "ISBN 147-8-5872-7277-8, 2, 2, 2, 2, P. 2, $2.00" } };

        [Test, TestCaseSource("_bookToStringDefaultSource")]
        public static void BookToStringTest(Book b, string expected)
        {
            Assert.AreEqual(b.ToString(), expected);
        }

        [Test, TestCaseSource("_bookToStringASource")]
        public static void BookToStringATest(Book b, string expected)
        {
            Assert.AreEqual(b.ToString("a"), expected);
        }

        [Test, TestCaseSource("_bookToStringBSource")]
        public static void BookToStringBTest(Book b, string expected)
        {
            Assert.AreEqual(b.ToString("b"), expected);
        }

        [Test, TestCaseSource("_bookToStringCSource")]
        public static void BookToStringCTest(Book b, string expected)
        {
            Assert.AreEqual(b.ToString("c"), expected);
        }

        [Test, TestCaseSource("_bookToStringDSource")]
        public static void BookToStringDTest(Book b, string expected)
        {
            Assert.AreEqual(b.ToString("d"), expected);
        }

        [TestCase("1234567890123", "123-4-5678-9012-3")]
        [TestCase("7896419579712", "789-6-4195-7971-2")]
        [TestCase("3697815427815", "369-7-8154-2781-5")]
        public static void ISBNFormatTest(string input, string expected)
        {
            Assert.AreEqual(string.Format(new ISBNFormat(), "{0:ISBN}", input), expected);
        }

        [TestCase("457875")]
        [TestCase("")]
        [TestCase("369781542781541646")]
        public static void ISBNFormatTest_Expection(string input)
            => Assert.Throws<FormatException>(() => string.Format(new ISBNFormat(), "{0:ISBN}", input));
    }
}