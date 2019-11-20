using System;
using NUnit.Framework;
using static Task01.GCD;

namespace Task01Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase(10, 1, 1)]
        [TestCase(55, 4, 1)]
        [TestCase(15, 0, 15)]
        [TestCase(48, 4, 4)]
        [TestCase(55, 55, 55)]
        [TestCase(0, 0, 0)]
        [TestCase(99, 11, 11)]
        public static void GCDEuclidianTwoTest(int a, int b, int expected)
        {
            if (GCDEuclidian(a, b) != expected || GCDEuclidian(out _, a, b) != expected)
            {
                Assert.Fail();
            }

            if (GCDEuclidianBinary(a, b) != expected || GCDEuclidianBinary(out _, a, b) != expected)
            {
                Assert.Fail();
            }
        }

        [TestCase(25, 50, 100, 25)]
        [TestCase(0, 0, 0, 0)]
        [TestCase(20, 30, 40, 10)]
        [TestCase(-25, 50, -75, 25)]
        [TestCase(19, 2, 3, 1)]
        [TestCase(10, 0, 20, 10)]
        public static void GCDEuclidianThreeTest(int a, int b, int c, int expected)
        {
            if (GCDEuclidian(a, b, c) != expected || GCDEuclidian(out _, a, b, c) != expected)
            {
                Assert.Fail();
            }

            if (GCDEuclidianBinary(a, b, c) != expected || GCDEuclidianBinary(out _, a, b, c) != expected)
            {
                Assert.Fail();
            }
        }

        [TestCase(10, 20, 30, 40, 50, 60)]
        [TestCase(1, 13, 17, 3, 7, 10)]
        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        [TestCase(25, 0, 50, 75, 100, 0, 125)]
        public static void GCDEuclidianArrayTest(int expected, params int[] arr)
        {
            if (GCDEuclidian(arr) != expected || GCDEuclidian(out _, arr) != expected)
            {
                Assert.Fail();
            }

            if (GCDEuclidianBinary(arr) != expected || GCDEuclidianBinary(out _, arr) != expected)
            {
                Assert.Fail();
            }
        }

        [TestCase(0)]
        [TestCase(10)]
        public static void GCDEuclidianOneNumberTest(params int[] arr)
        {
            Assert.Throws<ArgumentException>(() => GCDEuclidian(arr));
        }
    }
}