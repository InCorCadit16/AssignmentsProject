#define LONGSTR

using System;
using System.IO;
using System.Text;

namespace Assignment8
{



    class Program
    {
        static void Main(string[] args)
        {
            var MyStr = "Fine String";
            var t = 15;
            
            try
            {
                CheckData(MyStr, t);
            }
            catch (WrongNumberException wne) when (t % 5 == 0)
            {
                Console.WriteLine(wne.StackTrace);

                #if DEBUG
                    throw;
                #endif
            }
            catch (LongStringException lse)
            {
                Console.WriteLine(lse.Message);

                #if LONGSTR
                    Console.WriteLine("Long String Processed");
                #endif
            }



            StreamWriter Writer = null;
            try {
                Writer = new StreamWriter("text.txt");
                for (int i = 1; i < 6; i++)
                {
                    StringBuilder SB = new StringBuilder();
                    for (int j = 0; j < 10; j++)
                    {
                        if (j > 4 - i && j < 4 + i) SB.Append("*");
                        else SB.Append(" ");
                    }
                    Writer.WriteLine(SB);
                }
            } finally
            {
                Writer.Dispose();
            }

            var CustomData = new { id = 11433523, Info = "Danger to health" };

            var SomeLicence = new Licence { FName = "Nick", SName = "Ev", Age = 20 };
            var AnonymousLicence = new { SomeLicence.FName, Nickname = "InCorCadit" };

            Console.WriteLine(CustomData.Info);
            Console.WriteLine(SomeLicence.FName);
            Console.WriteLine(AnonymousLicence.FName);
        }

        static void CheckData(string ShortString, int DivisableBySeven)
        {
            if (DivisableBySeven % 7 != 0)
                throw new WrongNumberException("Number is not divisable by 7");
            else
                Console.WriteLine($"{DivisableBySeven} / 7 = {DivisableBySeven % 7}");
            

            if (ShortString.Length > 12)
                throw new LongStringException("String is too long for output");
            else
                Console.WriteLine(ShortString);

        }
    }

    class LongStringException : Exception
    {
        public LongStringException(String Message) : base(Message) { }
    }

    class WrongNumberException : ArithmeticException
    {
        public WrongNumberException(String Message) : base(Message) { }
    }

    class Licence
    {
        public string FName;
        public string SName;
        public int Age;
    }
}

    
