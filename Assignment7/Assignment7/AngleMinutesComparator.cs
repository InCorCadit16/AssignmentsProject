using System;
using System.Collections;
using System.Text;

namespace Assignment7
{
    class AngleMinutesComparator : IComparer
    {
        public int Compare(object x, object y)
        {
            Angle X = (Angle)x;
            Angle Y = (Angle)y;
            if (X[1] > Y[1])
                return 1;
            else if (Y[1] > X[1])
                return -1;

            return 0;
        }
    }
}
