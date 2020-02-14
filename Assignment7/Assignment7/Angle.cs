using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment7
{
    class Angle :  IComparable
    {
        public const int SEC_IN_DEG = 3600; 
        public const int SEC_IN_MIN = 60;
        public const int SEC_IN_360 = 360 * 3600;

        private int _quantityInSeconds;

        private int Degrees 
        { 
            get { return QuantityInSeconds / SEC_IN_DEG; }
            set { QuantityInSeconds = (value - Degrees) * SEC_IN_DEG; }
        }
        private int Minutes
        {
            get { return (QuantityInSeconds % SEC_IN_DEG) / SEC_IN_MIN; }
            set { QuantityInSeconds = (value - Minutes) * SEC_IN_MIN; }
        }

        private int Seconds { 
            get { return (QuantityInSeconds % SEC_IN_DEG) % SEC_IN_MIN; }
            set { QuantityInSeconds = (value - Seconds); }
        }

        private int QuantityInSeconds
        {
            get
            {
                return _quantityInSeconds;
            }

            set
            {
                if (value > SEC_IN_360)
                    _quantityInSeconds = value - SEC_IN_360;
                else if (value < 0)
                    _quantityInSeconds = SEC_IN_360 + value;
                else
                    _quantityInSeconds = value;
            }
        }

        

        public Angle(int Degrees) : this(Degrees, 0, 0) { }

        public Angle(int Degrees, int Minutes) : this(Degrees, Minutes, 0) { }

        public Angle(int Degrees, int Minutes, int Seconds)
        {
            this.QuantityInSeconds = Degrees * SEC_IN_DEG + Minutes * SEC_IN_MIN + Seconds;
        }

        public static bool operator ==(Angle lhs, Angle rhs)
        {
            return lhs.QuantityInSeconds == rhs.QuantityInSeconds;
        }

        public static bool operator !=(Angle lhs, Angle rhs)
        {
            return !(lhs == rhs);
        }

        public static Angle operator +(Angle lhs, Angle rhs)
        {
            return toAngle(lhs.QuantityInSeconds + rhs.QuantityInSeconds);
        }

        public static Angle operator -(Angle lhs, Angle rhs)
        {
            return toAngle(lhs.QuantityInSeconds - rhs.QuantityInSeconds);
        }

        public static Angle operator *(Angle lhs, int multiple)
        {
            return toAngle(lhs.QuantityInSeconds + multiple);
        }

        public static Angle operator *(int multiple, Angle lhs)
        {
            return lhs * multiple;
        }

        public static Angle operator /(Angle lhs, int devisor)
        {
            return toAngle(lhs.QuantityInSeconds/devisor);
        }

        public static double operator /(Angle lhs,  Angle rhs)
        {
            return (double) lhs.QuantityInSeconds / rhs.QuantityInSeconds;
        }

        private static Angle toAngle(int QuantityInSeconds)
        {
            return new Angle(QuantityInSeconds / SEC_IN_DEG, (QuantityInSeconds % SEC_IN_DEG) / SEC_IN_MIN, ((QuantityInSeconds % SEC_IN_DEG) % SEC_IN_MIN));
        }

        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Degrees;
                    case 1: return Minutes;
                    case 2: return Seconds;
                    default: throw new IndexOutOfRangeException($"Try to access element with index {index}");
                }
            }

            set
            {
                switch (index)
                {
                    case 0: Degrees = value; break;
                    case 1: Minutes = value; break;
                    case 2: Seconds = value; break;
                    default: throw new IndexOutOfRangeException($"Try to set value of element with index {index}");
                }
            }
        }

        public override string ToString()
        {
            return $"({Degrees}, {Minutes}, {Seconds})";
        }

        public IEnumerator GetEnumerator()
        {
            return new AngleEnumerator(this);
        }

        public IEnumerable GetEnumerator2()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return this[i];
            }
        }
        public IEnumerable<int> GetEnumerator3()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return this[i];
            }
        }

        public IEnumerator GetEnumerator4()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return this[i];
            }
        }

        public int CompareTo(object obj)
        {
            Angle Comp = (Angle)obj;
            if (this.Degrees > Comp.Degrees)
                return 1;
            else if (Comp.Degrees > this.Degrees)
                return -1;

            return 0;
        }
    }
}
