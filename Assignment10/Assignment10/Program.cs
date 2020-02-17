using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment10
{
    static class Program
    {
        static void Main(string[] args)
        {

            var SomeList = NewRandomArray();

            // Delegate
            BiggerThenN(SomeList, new MoreThanDelegate(MoreThanNine));

            SomeList = NewRandomArray();

            // Anonymous Func
            BiggerThenN(SomeList,(Func<int, bool>) delegate (int n)
            {
                return n > 12;
            });

            SomeList = NewRandomArray();

            // Lambda
            BiggerThenN(SomeList, (Func<int, bool>) (n => n > 7) );

            SomeList = NewRandomArray();

            // My extension method
            SomeList = SomeList.MoreThen(n => n > 13).ToList();

            SomeList = NewRandomArray();

            // LINQ extensions methods
            SomeList = SomeList.Where(n => n > 5)
                                .Select(n => n + 3)
                                .ToList();


            SomeList = NewRandomArray();


            var Matching =
                from val in SomeList
                where val > 12
                select val * 2;
        }

        public delegate bool MoreThanDelegate(int n);

        public static void BiggerThenN(List<int> List, MoreThanDelegate MoreThan)
        {
            foreach (var d in List)
            {
                if (!MoreThan(d))
                    List.Remove(d);
            }
        }

        public static void BiggerThenN(List<int> List, Func<int,bool> MoreThan)
        {
            foreach (var d in List)
            {
                if (!MoreThan(d))
                    List.Remove(d);
            }
        }

        public static bool MoreThanNine(int n)
        {
            return n > 9;
        }

        public static ICollection<int> MoreThen(this ICollection<int> List, Func<int, bool> MoreThan)
        {
            foreach (var d in List)
            {
                if (!MoreThan(d))
                    List.Remove(d);
            }
            return List;
        }

        public static List<int> NewRandomArray()
        {
            Random Rand = new Random();
            var SomeList = new List<int>();
            while (SomeList.Count < 40)
                SomeList.Add(Rand.Next(1, 20));

            return SomeList;
        }
    }
}
