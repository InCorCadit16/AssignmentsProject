using System;
using System.Text;

namespace Assignment6
{
    class Program
    {
        private static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int min = arr[i], min_i = i;
                for (int n = i + 1; n < arr.Length; n++)
                {
                    if (min > arr[n])
                    {
                        min = arr[n];
                        min_i = n;
                    }
                }

                arr[min_i] = arr[i];
                arr[i] = min;
            }
        }

        public static void AllTwice(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] *= 2;
            }
        }

        public static void PrintArr(int[] arr)
        {
            Console.WriteLine("\n----");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        public static float Average(int[,] arr)
        {
            float whole = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    whole += arr[i,j];
                }
            }
            return whole/arr.Length;
        }

        public static void AddIncToEach(string[][] Names)
        {
            for (int i = 0;i < Names.Length; i++)
            {
                for (int j = 0; j < Names[i].Length; j++)
                {
                    Names[i][j] += " Inc.";
                }
            }
        }

        static void Main(string[] args)
        {
            int[] arr = new int[20];
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(1, 1000);
            }

            PrintArr(arr);
            SelectionSort(arr);
            PrintArr(arr);
            AllTwice(arr);
            PrintArr(arr);

            int[,] Multi = new int[,]{ { 12, 75, 6 },{ 5, 94, 28 },{ 222, 54, 23 } };
            Console.WriteLine("\n");
            Console.WriteLine(Average(Multi));

            string[][] Jagged = { new string[] { "Microsoft", "Apple", "Google" }, new string[] { "Simple", "Nike", "", "Reebok"} };
            AddIncToEach(Jagged);
            for (int i = 0; i < Jagged.Length; i++)
            {
                for (int j = 0; j < Jagged[i].Length; j++)
                {
                   Console.WriteLine(Jagged[i][j]);
                }
            }

            string MyStr = String.Join(" ", Jagged[1]);
            Console.WriteLine(MyStr);
            int IndexOfi = MyStr.IndexOf('i');
            Console.WriteLine("Index of \"i\": {0}", IndexOfi);
            int LastIndexOfi = MyStr.LastIndexOf('i');
            Console.WriteLine("Last index of \"i\": {0}", LastIndexOfi);
            int IndexOfike = MyStr.IndexOf("ike");
            Console.WriteLine("Index of \"ike\": {0}", IndexOfike);
            bool ContainsBim = MyStr.Contains("Bim");
            Console.WriteLine("Contains \"Bim\": {0}", ContainsBim);
            string s = MyStr.ToLower();
            Console.WriteLine("To lower: " + s);
            string ike = MyStr.Substring(13, 3);
            Console.WriteLine(@"'ike' substring: " + ike);
            string withFree = MyStr.Insert(7, "Free ");
            Console.WriteLine($"with 'Free': {withFree}");
            Console.WriteLine("\t \n Heey \n \t".Trim());

            StringBuilder sb = new StringBuilder("Help to cure");
            Console.WriteLine(sb);
            sb.Append(" us ").Replace("cure", "save").Remove(5,8);
            sb.AppendJoin(" ", Jagged[1]).AppendLine();
            Console.WriteLine(sb);


            string[] Names = "-Samuel-Jack-Alex-Simon".Split('-');
            foreach(string name in Names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            string NamesInColumn= String.Join(" : ", Names);
            Console.WriteLine(NamesInColumn);

            var a = "abc";
            var b = "abc";
            Console.WriteLine(a != b);



            (int row, int column) = getTwoInts();
            Console.WriteLine(row);
            Console.WriteLine(column);
        }

        static (int row, int column) getTwoInts() => (8, 10);
    }
}
