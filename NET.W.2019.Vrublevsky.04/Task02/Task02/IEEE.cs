using System.Runtime.InteropServices;

namespace Task02
{
    public static class IEEE
    {

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

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLong
        {
            [FieldOffset(0)]
            private readonly long long64;
            [FieldOffset(0)]
            private readonly double double64;

            public DoubleToLong(double number)
            {
                this.long64 = 0;
                this.double64 = number;
            }

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
