using System;
using System.Collections.Generic;
using System.Text;

namespace Task01
{
    public sealed class Polynomial : ICloneable
    {
        private double[] coefs;

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="c">Coefficients.</param>
        public Polynomial(params double[] c)
        {
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c));
            }

            this.Degree = c.Length - 1;
            this.coefs = new double[this.Degree + 1];
            int zeroCoef = 0;
            for (int i = 0; i <= this.Degree; i++)
            {
                if (c[i] == 0)
                {
                    zeroCoef++;
                }

                this[i] = c[i];
            }

            if (zeroCoef == this.Degree + 1)
            {
                this.Degree = 0;
                this.coefs = new double[this.Degree + 1];
                this.coefs[0] = 0;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class by degree.
        /// </summary>
        /// <param name="degree">Degree.</param>
        private Polynomial(int degree)
        {
            this.Degree = degree;
            this.coefs = new double[this.Degree + 1];
        }

        /// <summary>
        /// Gets the degree.
        /// </summary>
        /// <value>
        /// The degree.
        /// </value>
        public int Degree { get; private set; }

        /// <summary>
        /// Gets the double with the specified i.
        /// </summary>
        /// <param name="i">Index.</param>
        /// <returns>Coefficient.</returns>
        public double this[int i]
        {
            get
            {
                if (this.Degree > this.coefs.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.coefs[i];
            }

            private set
            {
                if (i < 0 && i >= this.coefs.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.coefs[i] = value;
            }
        }

        /// <summary>
        /// Operator + for polynomial.
        /// </summary>
        /// <param name="p1">The first polynomial.</param>
        /// <param name="p2">The second polynomial.</param>
        /// <returns>The sum of polynimials.</returns>
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            if (p1 == null)
            {
                throw new ArgumentNullException(nameof(p1));
            }

            if (p2 == null)
            {
                throw new ArgumentNullException(nameof(p2));
            }

            Polynomial smaller, larger;
            if (p1.Degree > p2.Degree)
            {
                larger = p1.Clone();
                smaller = p2.Clone();
            }
            else
            {
                larger = p2.Clone();
                smaller = p1.Clone();
            }

            for (int i = 0; i <= smaller.Degree; i++)
            {
                larger[i] += smaller[i];
            }

            Polynomial result = new Polynomial(larger.coefs);
            return result;
        }

        /// <summary>
        /// Operator - for polynomial.
        /// </summary>
        /// <param name="p1">The first polynomial.</param>
        /// <param name="p2">The second polynomial.</param>
        /// <returns>The substract of polynomials.</returns>
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            if (p1 == null)
            {
                throw new ArgumentNullException(nameof(p1));
            }

            if (p2 == null)
            {
                throw new ArgumentNullException(nameof(p2));
            }

            p2 *= -1;
            return p1 + p2;
           
        }

        /// <summary>
        /// Operator * for polynomial.
        /// </summary>
        /// <param name="p1">The first polynomial.</param>
        /// <param name="p2">The second polynomial.</param>
        /// <returns>The multiplication of polynimials.</returns>
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            if (p1 == null)
            {
                throw new ArgumentNullException(nameof(p1));
            }

            if (p2 == null)
            {
                throw new ArgumentNullException(nameof(p2));
            }

            Polynomial result = new Polynomial(p1.Degree + p2.Degree);
            for (int i = 0; i <= p1.Degree; i++)
            {
                for (int j = 0; j <= p2.Degree; j++)
                {
                    result.coefs[i + j] += p1[i] * p2[j];
                }
            }

            return result;
        }

        /// <summary>
        /// Operator * for polynomial.
        /// </summary>
        /// <param name="a">Number.</param>
        /// <param name="p">Polynomial.</param>
        /// <returns>The multiplication of number and polynomial.</returns>
        public static Polynomial operator *(double a, Polynomial p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            Polynomial result = new Polynomial(p.Degree);
            for (int i = 0; i <= p.Degree; i++)
            {
                result[i] = p[i] * a;
            }

            return result;
        }

        /// <summary>
        /// Operator * for polynomial.
        /// </summary>
        /// <param name="p">Polynomial.</param>
        /// <param name="a">Number.</param>
        /// <returns>The multiplication of polynomial and number.</returns>
        public static Polynomial operator *(Polynomial p, double a)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            return a * p;
        }

        /// <summary>
        /// Operator == for polynomial.
        /// </summary>
        /// <param name="p1">The first polynomial.</param>
        /// <param name="p2">The second polynomial.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }

            if (p1 is null || p2 is null)
            {
                return false;
            }

            if (p1.Degree != p2.Degree)
            {
                return false;
            }
            else
            {
                for (int i = 0; i <= p1.Degree; i++)
                {
                    if (p1[i] != p2[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Operator != for polynomial.
        /// </summary>
        /// <param name="p1">The first polynomial.</param>
        /// <param name="p2">The second polynomial.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            return !(p1 == p2);
        }

        public static Polynomial Add(Polynomial p1, Polynomial p2) => p1 + p2;

        public static Polynomial Subtract(Polynomial p1, Polynomial p2) => p1 - p2;

        public static Polynomial Multiply(Polynomial p1, Polynomial p2) => p1 * p2;

        public static Polynomial Multiply(double a, Polynomial p) => a * p;

        public static Polynomial Multiply(Polynomial p, double a) => p * a;

        /// <summary>
        /// Equals for polynomials.
        /// </summary>
        /// <param name="p">The other polynomial(with which compare).</param>
        /// <returns>The result of the operation(true or false).</returns>
        public bool Equals(Polynomial p)
        {
            if (p is null)
            {
                return false;
            }

            if (ReferenceEquals(this, p))
            {
                return true;
            }

            if (this.coefs.Length != p.coefs.Length)
            {
                return false;
            }

            return this == p;
        }

        /// <summary>
        /// Equals for polynomial and other type.
        /// </summary>
        /// <param name="obj">Type which we compare witch polynomial.</param>
        /// <returns>The result of the operation(true or false).</returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Polynomial)obj);
        }

        /// <summary>
        /// String representaion for polynomial.
        /// </summary>
        /// <returns>String that represent this polynomial.</returns>
        public override string ToString()
        {
            string stringPol = null;
            for (int i = 0; i <= this.Degree; i++)
            {
                if (this[i] == 0)
                {
                    continue;
                }

                if (stringPol != null)
                {
                    if (this[i] > 0)
                    {
                        stringPol += "+";
                    }
                }

                if (i == 0)
                {
                    stringPol += this[i];
                    continue;
                }

                if (i == 1)
                {
                    stringPol += this[i];
                    stringPol += $"x";
                    continue;
                }

                if (this[i] != 1)
                {
                    if (this[i] == -1)
                    {
                        stringPol += "-";
                    }
                    else
                    {
                        stringPol += this[i];
                    }
                }

                stringPol += $"x^{i}";
            }

            return stringPol;
        }

        /// <summary>
        /// Hash code for this polynomial.
        /// </summary>
        /// <returns>A hash code of this polynomial.</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i <= this.Degree; i++)
            {
                hash += this[i].GetHashCode() * i.GetHashCode();
            }

            return hash;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        private Polynomial Clone()
        {
            Polynomial p = new Polynomial { coefs = this.coefs, Degree = this.Degree };
            return p;
        }
    }
}
