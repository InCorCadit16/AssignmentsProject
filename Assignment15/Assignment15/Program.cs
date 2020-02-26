using System;
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

            if (str.Contains('π'))
                Console.WriteLine($"string has π with code {(int) 'π'}");

            if (str.Contains('ρ'))
                Console.WriteLine($"string has ρ with code {(int) 'ρ'}");

            if (str.Contains('î'))
                Console.WriteLine("string has {0} with code {1}", 'î', (int)'î');

            var cultureInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            var cultureList = new List<CultureInfo>(cultureInfos);

            Console.WriteLine("Choose Culture (two letters)");
            string code = Console.ReadLine().ToUpper();

            CultureInfo.CurrentCulture = cultureList.First(culture => culture.CompareInfo.Name.Contains(code));
            Console.WriteLine(CultureInfo.CurrentCulture.TextInfo);
          
            Console.WriteLine($"î and i are {("î".Equals("i", StringComparison.CurrentCulture)? "same": "different")} in CurrentCulture");

            Console.WriteLine($"î and i are {("î".Equals("i", StringComparison.InvariantCulture)? "same": "different")} in InvariantCulture");

        }
    }
}
