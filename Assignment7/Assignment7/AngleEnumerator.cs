using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Assignment7
{
    class AngleEnumerator : IEnumerator
    {
        private readonly Angle Angle;
        private int _index = -1;

        public AngleEnumerator(Angle Angle)
        {
            this.Angle = Angle;
        }

        public object Current => Angle[_index];

        public bool MoveNext()
        {
            _index++;

            return _index < 3;

        }

        public void Reset()
        {
            _index = -1;
        }
    }
}
