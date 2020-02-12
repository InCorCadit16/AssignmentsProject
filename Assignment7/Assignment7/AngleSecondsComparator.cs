using System;
using System.Collections;

namespace Assignment7
{
    class AngleSecondsComparator : IComparer
    {
        public int Compare(object x, object y)
        {
            Angle X = (Angle)x;
            Angle Y = (Angle)y;
            if (X[2] > Y[2])
                return 1;
            else if (Y[2] > X[2])
                return -1;

            return 0;
        }
    }
}
