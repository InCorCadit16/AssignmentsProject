using System;

namespace Assignment9
{
    class Starter
    {
        static void Main(string[] args)
        {
            var List = new MyList<int>() { 5, 2, 6, 4 };
            List.Add(12);
            List.Add(5);
            List[2] = 12;
            List.Insert(3,5);
            

            Console.WriteLine($"Count = {List.Count}; capacity = {List.Capacity}");
            foreach (var i in List) Console.Write(i + " ");
            Console.WriteLine();

            List.Swap(0, 2);
            foreach (var i in List) Console.Write(i + " ");
            Console.WriteLine();

        }
    }
}
