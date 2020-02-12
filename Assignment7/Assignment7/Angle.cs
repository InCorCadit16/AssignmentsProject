using System;
using System.Collections;

namespace Assignment7
{
    class Angle : IEnumerable, IComparable
    {
        private int _degress, _minutes, _seconds;

        private int Degrees {
            get 
            {
                return _degress;
            }
            
            set
            {
                _degress = value; 
            }
        }
        private int Minutes
        {
            get
            {
                return _minutes;
            }

            set
            {
                if (value > 60)
                {
                    _minutes = value % 60;
                    Degrees += value / 60;
                } else if (value < 0)
                {
                    _minutes = value + 60;
                    Degrees--;
                } else
                     _minutes = value;
            }
        }
        private int Seconds
        {
            get
            {
                return _seconds;
            }

            set
            {
                if (value > 60)
                {
                    _seconds = value % 60;
                    Minutes += value / 60;
                }
                else if (value < 0)
                {
                    _seconds = value + 60;
                   Minutes--;
                } else
                    _seconds = value;
            }
        }

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
            return new Angle(lhs.Degrees + rhs.Degrees, lhs.Minutes + rhs.Minutes, lhs.Seconds + rhs.Seconds);
        }

        public static Angle operator -(Angle lhs, Angle rhs)
        {
            return new Angle(lhs.Degrees - rhs.Degrees, lhs.Minutes - rhs.Minutes, lhs.Seconds - rhs.Seconds);
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

        /*public IEnumerator GetEnumerator()
        {
            return new AngleEnumerator(this);
        }*/

        public IEnumerator GetEnumerator()
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
