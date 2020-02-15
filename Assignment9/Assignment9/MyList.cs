using System;
using System.Collections;

namespace Assignment9
{
    public class MyList<T> : IEnumerable
    {
        T[] Items;

        public int Count { get; private set; }
        public int Capacity { get { return Items.Length; } }

        public MyList() : this(4) { }

        public MyList(int Size)
        {

            Items = new T[Size];
            Count = 0;
        }

        public T Get(int Index)
        {
            return this[Index];
        }

        public void Insert(T value, int Index)
        {
            if (Index > Count - 1)
                throw new IndexOutOfRangeException($"Trying to Insert at Index {Index} when Size is {Count}");

            this[Index] = value;
        }

        public void Add(T value)
        {
            this[Count] = value;
            Count++;

            if (Count == Capacity - 1)
                IncreaseCapacity();
        }

        public void Swap(int Index1, int Index2)
        {
            if (Index1 > Count - 1)
                throw new IndexOutOfRangeException($"Trying to Insert at Index {Index1} when Size is {Count}");

            if (Index2 > Count - 1)
                throw new IndexOutOfRangeException($"Trying to Insert at Index {Index1} when Size is {Count}");

            T tmp = this[Index1];
            this[Index1] = this[Index2];
            this[Index2] = tmp;
        }

        public T this[int index]
        {
            get
            {
                if (index > Count || index < 0)
                    throw new IndexOutOfRangeException($"Trying to access value at Index {index} when Size is {Count}");

                return Items[index];
            }
            set
            {
                if (index > Count | index < 0)
                    throw new IndexOutOfRangeException($"Trying to set value at Index {index} when Size is {Count}");

                Items[index] = value;
            }
        }

        private void IncreaseCapacity()
        {
            T[] NewItems = new T[Items.Length * 2];
            Items.CopyTo(NewItems, 0);
            Items = NewItems;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return Items[i];
            }
        }
    }
}
