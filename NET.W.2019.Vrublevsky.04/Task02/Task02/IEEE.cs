using System.Runtime.InteropServices;

namespace Task02
{
    /// <summary>
    /// Converter from double to binary IEEE.
    /// </summary>
    public static class IEEE
    {
        /// <summary>
        /// Converts from double to string of it's binary representation.
        /// </summary>
        /// <param name="number">Double number.</param>
        /// <returns>Binary representation.</returns>
        public static string DoubleToBin(this double number)
        {
            string bin = null;
            DoubleToLong doubleToLong = new DoubleToLong(number);
            long numberLong = doubleToLong.Long64;

            for (int i = 0; i < 64; i++)
            {
                if ((numberLong & 1) == 1)
                {
                    bin += "1";
                }
                else
                {
                    bin += "0";
                }

                numberLong >>= 1;
            }

            return Rev(bin);
        }

        private static string Rev(string a)
        {
            string rev = null;
            for (int i = a.Length - 1; i > -1; i--)
            {
                rev += a[i];
            }

            return rev;
        }

        /// <summary>
        /// Double and Long number at one field offset.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLong
        {
            [FieldOffset(0)]
            private readonly long long64;
            [FieldOffset(0)]
            private readonly double double64;

            /// <summary>
            /// Initializes a new instance of the <see cref="DoubleToLong"/> struct.
            /// </summary>
            /// <param name="number">Double number.</param>
            public DoubleToLong(double number)
            {
                this.long64 = 0;
                this.double64 = number;
            }

            /// <summary>
            /// Get long64.
            /// </summary>
            public long Long64
            {
                get
                {
                    return this.long64;
                }
            }
        }
    }
}
