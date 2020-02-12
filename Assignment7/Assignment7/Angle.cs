using System;
using System.Collections;

namespace Assignment7
{
    class Angle : IEnumerable, IComparable
    {
        private int Degrees, Minutes, Seconds;

        public Angle(int Degrees) : this(Degrees, 0, 0) { }

        public Angle(int Degrees, int Minutes) : this(Degrees, Minutes, 0) { }

        public Angle(int Degrees, int Minutes, int Seconds)
        {
            this.Degrees = Degrees;
            this.Minutes = Minutes;
            this.Seconds = Seconds;
        }

        public static bool operator ==(Angle lhs, Angle rhs)
        {
            return lhs.Degrees == rhs.Degrees &&
                     lhs.Minutes == rhs.Minutes &&
                     lhs.Seconds == rhs.Seconds;
        }

        public static bool operator !=(Angle lhs, Angle rhs)
        {
            return !(lhs == rhs);
        }

        public static Angle operator +(Angle lhs, Angle rhs)
        {
            Angle A = new Angle(lhs.Degrees + rhs.Degrees, lhs.Minutes + rhs.Minutes, lhs.Seconds + rhs.Seconds);
            if (A.Seconds >= 60)
            {
                A.Minutes += A.Seconds / 60;
                A.Seconds %= 60;
            }

            if (A.Minutes >= 60)
            {
                A.Degrees += A.Minutes / 60;
                A.Minutes %= 60;
            }
            return A;
        }

        public static Angle operator -(Angle lhs, Angle rhs)
        {
            Angle A = new Angle(lhs.Degrees - rhs.Degrees, lhs.Minutes - rhs.Minutes, lhs.Seconds - rhs.Seconds);
            if (A.Seconds < 0)
            {
                A.Seconds += 60;
                A.Minutes--;
            }

            if (A.Minutes < 0)
            {
                A.Minutes += 60;
                A.Degrees--;
            }
            return A;
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

        /*public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return this[i];
            }
        }*/

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
