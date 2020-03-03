using System;
using System.Diagnostics;

namespace Assignment14
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawPiramide(levels:5,symbol:'\\');

            DrawPiramide(startWidth: 1, repeat: 2,symbol: '#', levels: 6);
            DrawPiramide(startWidth: 1, levels: 2, symbol: 'g', repeat: 1);
            DrawPiramide(6);

            dynamic Everything = default;
            Everything = 3.5e+3;
            Console.WriteLine(Everything);
            Everything = "Hi, Mark";
            Console.WriteLine(Everything);
            User[] Users = new User[] { new CallingUser(), new MessagingUser() };

            foreach (var usr in Users)
            {
                Everything = usr;
               try
                {
                    Everything.Call();
                } catch(Exception e)
                {
                    Debugger.Log(1, Debugger.DefaultCategory, e.Message);
                }

                try
                {
                    Everything.Message();
                } catch (Exception e)
                {
                    Debugger.Log(1, Debugger.DefaultCategory, e.Message);
                }
            }

            var scar = new User { FName = "Johny", SName = "Montana" };

            try
            {
                ThrowRandomException();
            }
            catch (ArithmeticException ae) when (Users[0] is CallingUser)
            {
                Console.WriteLine(ae.Message);
            }
            catch (DllNotFoundException dfe)
            {
                Console.WriteLine(dfe.Message);
            } 
            catch (FieldAccessException fae)
            {
                Console.WriteLine(fae.Message);
            }

            Console.WriteLine(nameof(Users));

            int? v1 = 12;
            int? v2 = null;
            int? v3 = default;

            User usr = null;
            Console.WriteLine(usr?.Age);
            var v4 = v2 ?? v3 ?? v1;
            Console.WriteLine(v4);
        }

        public static void DrawPiramide(int levels, int startWidth = 1, char symbol = '*', int repeat = 1) 
        {
            for (int i = 0; i < repeat; i++)
            {
                for (int n = levels - 1; n >= 0; n--)
                {
                    for (int f = startWidth; f < startWidth + (2*levels); f++)
                    {
                        if (f > n && f < startWidth + (2 * levels) - n -1) Console.Write(symbol);
                        else Console.Write(' ');
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        static void ThrowRandomException()
        {
            switch(new Random().Next(1,3))
            {
                case 1: throw new ArithmeticException("1");
                case 2: throw new DllNotFoundException("2");
                default: throw new FieldAccessException("3");
            }
        }

        class User
        {
            public string FName { get; set; } 
            public  string SName { get; set; }
            public DateTime Birthday { get; }
            public int Age { get; protected set; }

            public string Info() => $"First name: {FName}\n Second Name: {SName}\n Third Name: {Age}";
        }

        class CallingUser : User
        {
            public void Call()
            {
                Console.WriteLine("User calling");
            }
        }

        class MessagingUser : User
        {
            public void Message()
            {
                Console.WriteLine("User is messaging");
            }
        }
    }
}
