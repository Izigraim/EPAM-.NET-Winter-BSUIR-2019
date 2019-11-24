using NUnit.Framework;
using Task01;

namespace Task01Tests
{
    public class Tests
    {
        [TestCase(new double[] { 1, 2, 3, 4, 5, 6 }, new double[] { 1, 2, 3 }, new double[] { 2, 4, 6, 4, 5, 6 })]
        [TestCase(new double[] { -1, -2 }, new double[] { 1, 2 }, new double[] { 0 })]
        [TestCase(new double[] { 1.0, 1.5, -1.6 }, new double[] { 1, 2, 3 }, new double[] { 2.0, 3.5, 1.4 })]
        public static void PolynomialAddTest(double[] a1, double[] a2, double[] expected)
        {
            Polynomial p1 = new Polynomial(a1);
            Polynomial p2 = new Polynomial(a2);
            Polynomial p3 = new Polynomial(expected);
            Assert.AreEqual(p1 + p2, p3);
        }

        [TestCase(new double[] { 1, 2, 3, 4, 5, 6 }, new double[] { 1, 2, 3 }, new double[] {0, 0, 0, 4, 5, 6 })]
        [TestCase(new double[] { -1, -2 }, new double[] { 1, 2 }, new double[] { -2, -4 })]
        [TestCase(new double[] { 1.0, 1.5, -1.6 }, new double[] { 1, 2, 3 }, new double[] {0, -0.5, -4.6 })]
        public static void PolynomialSubTest(double[] a1, double[] a2, double[] expected)
        {
            Polynomial p1 = new Polynomial(a1);
            Polynomial p2 = new Polynomial(a2);
            Polynomial p3 = new Polynomial(expected);
            Assert.AreEqual(p1 - p2, p3);
        }

        [TestCase(new double[] { 1, 2, 3, 4, 5, 6 }, new double[] { 1, 2, 3 }, new double[] { 1, 4, 10, 16, 22, 28, 27, 18 })]
        [TestCase(new double[] { -1, -2 }, new double[] { 1, 2 }, new double[] { -1, -4, -4 })]
        [TestCase(new double[] { 1.0, 1.5, -1.6 }, new double[] { 1, 2, 3 }, new double[] { 1, 3.5, 4.4, 1.2999999999999998, -4.800000000000001 })]
        public static void PolynomialMulTest(double[] a1, double[] a2, double[] expected)
        {
            Polynomial p1 = new Polynomial(a1);
            Polynomial p2 = new Polynomial(a2);
            Polynomial p3 = new Polynomial(expected);
            Assert.AreEqual(p1 * p2, p3);
        }

        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, ExpectedResult = true)]
        [TestCase(new double[] { -1, -2 }, new double[] { 1, 2 }, ExpectedResult = false)]
        [TestCase(new double[] { 1.0, 1.5, -1.6 }, new double[] { 1, 2, 3 }, ExpectedResult = false)]
        public static bool PolynomialEqualsTest(double[] a1, double[] a2)
        {
            Polynomial p1 = new Polynomial(a1);
            Polynomial p2 = new Polynomial(a2);
            return p1.Equals(p2);
        }
    }
}