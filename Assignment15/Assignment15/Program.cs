﻿using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Assignment15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 - Strings and Encoding");
            Console.WriteLine("2 - DateTime and Zones");
            Console.WriteLine("3 - Finalizers and Disposable");
            Console.WriteLine("4 - Last Task");
            int.TryParse(Console.ReadLine(), out int i);

            switch (i)
            {
                case 1: StringsWork(); break;
                case 2: DateTimeAndZones(); break;
                case 3: FinalizersAndDisposables(); break;
                case 4: LastPoint(); break;
            }

            Console.ReadLine();
        }


        public static void StringsWork()
        {
            // Using of encodings 
            Console.Write("Write string with non-Ascii characters: ");
            // π ρ θ î ¶ ¤ ®
            string str = Console.ReadLine();
            byte[] offset = Encoding.Unicode.GetBytes(str);
            offset = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, offset);
            string AsciiStr = Encoding.ASCII.GetString(offset);
            using (StreamWriter sw = new StreamWriter("test.notype"))
            {
                sw.WriteLine(AsciiStr);
            }

            // String Searching
            if (str.Contains('π'))
                Console.WriteLine($"string has π with code {(int)'π'}");

            if (str.Contains('ρ'))
                Console.WriteLine($"string has ρ with code {(int)'ρ'}");

            if (str.Contains('î'))
                Console.WriteLine("string has {0} with code {1}", 'î', (int)'î');

            var cultureInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            var cultureList = new List<CultureInfo>(cultureInfos);

            // Culture info 
            Console.WriteLine("Choose Culture (two letters)");
            string code = Console.ReadLine().ToUpper();

            CultureInfo.CurrentCulture = cultureList.FirstOrDefault(culture => culture.CompareInfo.Name.Contains(code));
            if (CultureInfo.CurrentCulture is null)
            {
                Console.WriteLine("No matching culture found");
                return;
            }
            Console.WriteLine(CultureInfo.CurrentCulture.TextInfo);

            // String comparing
            Console.WriteLine($"î and i are {("î".Equals("i") ? "same" : "different")} in CurrentCulture");

            Console.WriteLine($"î and i are {("î".Equals("i", StringComparison.InvariantCulture) ? "same" : "different")} in InvariantCulture");
        }

        public static void LastPoint()
        {

            FileInfo file = new FileInfo("date.txt");
            if (!file.Exists)
            {
                using (StreamWriter Writer = new StreamWriter("date.txt"))
                {
                    Writer.WriteLine(DateTime.Now.ToString(), CultureInfo.CurrentCulture);
                }
            }
           

            string dateStr;
            using (StreamReader Reader = new StreamReader("date.txt"))
            {
                dateStr = Reader.ReadLine();
            }

            DateTime date = DateTime.Parse(dateStr, CultureInfo.InvariantCulture);
            Console.WriteLine($"Current culture: {date.ToString(CultureInfo.CurrentCulture)}");
            Console.WriteLine($"France culture: {date.ToString(CultureInfo.GetCultureInfo(12))}");
            Console.WriteLine($"Japan culture: {date.ToString(CultureInfo.GetCultureInfo(17))}");
        }

        public static void FinalizersAndDisposables()
        {
            using (var ints = new FixedDataHolder<int>(12))
            {
                Random random = new Random();
                for (int i = 0; i < 12; i++)
                {
                    ints[i] = random.Next(1, 500);
                }

                var Holder = new OneValueHolder<FixedDataHolder<int>>(ints);

                ints.PrintIf(n => n > 250);
            }


        }

        public static void DateTimeAndZones()
        {
            Console.Write("Give a number: ");
            int days = int.Parse(Console.ReadLine());

            var span = new TimeSpan(days, 0, 0, 0);
            Console.WriteLine($"There will be {DateTime.Now.Add(span).DayOfWeek} after {days} days");


            DateTime nowOffset = new DateTime(DateTime.Now.Ticks, DateTimeKind.Unspecified);
            DateTimeOffset nowInVladivostoc = new DateTimeOffset(nowOffset, TimeSpan.FromHours(8));
         
            Console.WriteLine(nowOffset);
            Console.WriteLine(nowInVladivostoc);

            TimeZoneInfo infoLocal = TimeZoneInfo.Local;

            Console.WriteLine( (infoLocal.SupportsDaylightSavingTime ? "Ooh, dude" : ";D"));
        }
    }

    class FixedDataHolder<T> : IDisposable
    {
        T[] _data;

        public FixedDataHolder(int size)
        {
            _data = new T[size];
        }

        public FixedDataHolder()
        {
            _data = new T[12];
        }

        public T this[int index]
        {
            get
            {
                if (index < _data.Length && index >= 0)
                    return _data[index];
                else
                    return default;
            }

            set
            {
                if (index < _data.Length && index >= 0)
                    _data[index] = value;
            }
        }

        public void PrintIf(Func<T, bool> predicate)
        {
            foreach (var val in _data)
            {
                if (predicate(val)) Console.WriteLine(val);
            }
        }

        public void Dispose()
        {
            for (int i = 0; i < _data.Length; i++)
                _data[i] = default;

            _data = null;
            Console.WriteLine("Data Holder Disposed");
        }
    }

    class OneValueHolder<T> where T : new()
    {
        public T Value;

        public OneValueHolder(T v)
        {
            Value = v;
        }

        public OneValueHolder() : this(new T()) { }

        ~OneValueHolder()
        {
            Console.WriteLine($"Finalizer called for {Value} value");
            Value = default;
        }
    }
}
