using NUnit.Framework;
using System;
using Task02;

namespace Task02Tests
{
    [TestFixture]
    public class Tests
    {
        private static  object[] _sourceArraysSumAsc = { new object[] { new int[][] { new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123, 2569, -546 }, new int[] { 123654 } }, new int[][] { new int[] { 123, 2569, -546 }, new int[] { 123654 }, new int[] { 1, 4, 7, 8, 4569874 } } },
                                                   new object[] { new int[][] { new int[] { 4 }, new int[] { 2 }, new int[] { 1 } }, new int[][] { new int[] { 1 }, new int[] { 2 }, new int[] { 4 } } },
                                                   new object[] { new int[][] { new int[] { -5, -4, 11 }, new int[] { 2 }, new int[] { 1 } }, new int[][] { new int[] {1 }, new int[] { 2 }, new int[] { -5,-4,11 } } }
        };

        private static object[] _sourceArraysSumDesc = { new object[] { new int[][] { new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123, 2569, -546 }, new int[] { 123654 } }, new int[][] { new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123654 }, new int[] { 123, 2569, -546 } } },
                                                   new object[] { new int[][] { new int[] { 4 }, new int[] { 2 }, new int[] { 1 } }, new int[][] { new int[] { 4 }, new int[] { 2 }, new int[] { 1 } } },
                                                   new object[] { new int[][] { new int[] { -5, -4, 11 }, new int[] { 2 }, new int[] { 1 } }, new int[][] { new int[] {-5,-4,11 }, new int[] { 2 }, new int[] {1 } } }
        };

        private static object[] _sourceArraysMaxAsc = { new object[] { new int[][] { new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123, 2569, -546 }, new int[] { 123654 } }, new int[][] { new int[] { 123, 2569, -546 }, new int[] { 123654 }, new int[] { 1, 4, 7, 8, 4569874 } } },
                                                   new object[] { new int[][] { new int[] { 4 }, new int[] { 2 }, new int[] { 1 } }, new int[][] { new int[] { 1 }, new int[] { 2 }, new int[] { 4 } } },
                                                   new object[] { new int[][] { new int[] { -5, -4, 11 }, new int[] { 2 }, new int[] { 1 } }, new int[][] { new int[] {1 }, new int[] { 2 }, new int[] { -5,-4,11 } } }
        };

        private static object[] _sourceArraysMaxDesc = { new object[] { new int[][] { new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123, 2569, -546 }, new int[] { 123654 } }, new int[][] { new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123654 }, new int[] { 123, 2569, -546 } } },
                                                   new object[] { new int[][] { new int[] { 4 }, new int[] { 2 }, new int[] { 1 } }, new int[][] { new int[] { 4 }, new int[] { 2 }, new int[] { 1 } } },
                                                   new object[] { new int[][] { new int[] { -5, -4, 11 }, new int[] { 2 }, new int[] { 1 } }, new int[][] { new int[] {-5,-4,11 }, new int[] { 2 }, new int[] {1 } } }
        };

        private static object[] _sourceArraysMinAsc = { new object[] { new int[][] { new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123, 2569, -546 }, new int[] { 123654 } }, new int[][] { new int[] { 123, 2569, -546 }, new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123654 } } },
                                                   new object[] { new int[][] { new int[] { 4 }, new int[] { 2 }, new int[] { 1 } }, new int[][] { new int[] { 1 }, new int[] { 2 }, new int[] { 4 } } },
                                                   new object[] { new int[][] { new int[] { -5, -4, 11 }, new int[] { 2 }, new int[] { 1 } }, new int[][] { new int[] { -5, -4, 11 }, new int[] { 1 }, new int[] { 2 } } }
        };

        private static object[] _sourceArraysMinDesc = { new object[] { new int[][] { new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123, 2569, -546 }, new int[] { 123654 } }, new int[][] { new int[] { 123654 }, new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123, 2569, -546 } } },
                                                   new object[] { new int[][] { new int[] { 4 }, new int[] { 2 }, new int[] { 1 } }, new int[][] { new int[] { 4 }, new int[] { 2 }, new int[] { 1 } } },
                                                   new object[] { new int[][] { new int[] { -5, -4, 11 }, new int[] { 2 }, new int[] { 1 } }, new int[][] { new int[] { 2 }, new int[] { 1 }, new int[] { -5, -4, 11 } } }
        };

        [Test, TestCaseSource("_sourceArraysSumAsc")]
        public static void SumByAscTest(int[][] a, int[][] expected)
        {
            Assert.AreEqual(expected, JaggedArraySort.SumByAsc(a));
        }

        [Test, TestCaseSource("_sourceArraysSumDesc")]
        public static void SumByDescTest(int[][] a, int[][] expected)
        {
            Assert.AreEqual(expected, JaggedArraySort.SumByDesc(a));
        }

        [Test, TestCaseSource("_sourceArraysMaxAsc")]
        public static void MaxByAscTest(int[][] a, int[][] expected)
        {
            Assert.AreEqual(expected, JaggedArraySort.MaxByAsc(a));
        }

        [Test, TestCaseSource("_sourceArraysMaxDesc")]
        public static void MaxByDescTest(int[][] a, int[][] expected)
        {
            Assert.AreEqual(expected, JaggedArraySort.MaxByDesc(a));
        }

        [Test, TestCaseSource("_sourceArraysMinAsc")]
        public static void MinByAscTest(int[][] a, int[][] expected)
        {
            Assert.AreEqual(expected, JaggedArraySort.MinByAsc(a));
        }

        [Test, TestCaseSource("_sourceArraysMinDesc")]
        public static void MinByDescTest(int[][] a, int[][] expected)
        {
            Assert.AreEqual(expected, JaggedArraySort.MinByDesc(a));
        }
    }
}