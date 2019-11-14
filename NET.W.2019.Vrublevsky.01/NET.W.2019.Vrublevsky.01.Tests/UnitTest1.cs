using System;
using NET.W._2019.Vrublevsky._01;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W._2019.Vrublevsky._01.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MergeTest1()
        {
            var array = new int[10] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] arrayExpected = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int[] result = Program.MergeSort(array, 0, array.Length - 1);

            CollectionAssert.AreEqual(arrayExpected, result);
        }

        [TestMethod]
        public void MergeTest2()
        {
            var array = new int[2] { 5, -5 };
            int[] arrayExpected = new int[2] { -5, 5 };

            int[] result = Program.MergeSort(array, 0, array.Length - 1);

            CollectionAssert.AreEqual(arrayExpected, result);
        }

        [TestMethod]
        public void MergeTest3()
        {
            var array = new int[5] { -5, 6, 7, -22, 3 };
            int[] arrayExpected = new int[5] { -22, -5, 3, 6, 7 };

            int[] result = Program.MergeSort(array, 0, array.Length - 1);

            CollectionAssert.AreEqual(arrayExpected, result);
        }

        [TestMethod]
        public void QSTest1()
        {
            var array = new int[10] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] arrayExpected = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int[] result = Program.QuickSort(array, 0, array.Length - 1);

            CollectionAssert.AreEqual(arrayExpected, result);
        }

        [TestMethod]
        public void QSTest2()
        {
            var array = new int[2] { 5, -5};
            int[] arrayExpected = new int[2] { -5, 5};

            int[] result = Program.QuickSort(array, 0, array.Length - 1);

            CollectionAssert.AreEqual(arrayExpected, result);
        }

        [TestMethod]
        public void QSTest3()
        {
            var array = new int[5] { -5, 6, 7,-22, 3 };
            int[] arrayExpected = new int[5] { -22, -5, 3, 6, 7};

            int[] result = Program.QuickSort(array, 0, array.Length - 1);

            CollectionAssert.AreEqual(arrayExpected, result);
        }
    }
}
