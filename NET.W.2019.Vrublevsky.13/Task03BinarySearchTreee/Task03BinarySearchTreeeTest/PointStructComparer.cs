using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Task03BinarySearchTreeeTest
{
    public class PointStructComparer : IComparer<PointStruct>
    {
        public int Compare(PointStruct x, PointStruct y)
        {
            if (x.a > y.a && x.b > y.b)
            {
                return 1;
            }
            else if (x.a < y.a && x.b < y.b)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
