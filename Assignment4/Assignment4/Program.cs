using System;
using System.Threading;

namespace Assignment4
{
    class Program
    {

        class Car
        {
            int HorsePowers;
            string Numberplate;
            
            internal Car(int HorsePowers, string Numberplate)
            {
                this.HorsePowers = HorsePowers;
                this.Numberplate = Numberplate;
            }
        }

        class Coffee
        {
            public static readonly int Price, CupVolume;

            static Coffee()
            {
                Price = 20;
                CupVolume = 350;
            }
        }

        struct Person
        {
            public string Name;
            public int Age;
            public int Height;
        }

        public static void cout(object o) {
            Console.WriteLine(o);   
        }

        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static int SeperateDouble(double number, out double afterDot)
        {
            afterDot = number - (int) number;
            return (int) number;
        }

        public static void PrintInACycle()
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Background Thread. i = " + i);
                    Thread.Sleep(1000);
                }
            } catch (ThreadAbortException e)
            {
                Console.WriteLine("Child thread aborted");
            }
        }

        /*static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // some value types
            cout("\nSome value types\n");
            int a = 12;
            cout(a);
            char c = 'z';
            cout(c);
            bool b = false;
            cout(b);
            double d = 1.37E6;
            cout(d);
            Person Mark = new Person{ Name = "Mark", Age = 22, Height = 189 };

            // some reference types
            cout("\nSome reference types\n");
            string s = "I'm a reference";
            cout(s);
            Car Kia = new Car(120, "AAZ322");

            // boxing
            object obj = 27.15;
            cout(obj);
            // unboxing
            double val = (double) obj;
            cout(val);

            // ref modifier
            cout("\nSome reference types\n");
            int e = 22;
            cout("a = " + a);
            cout("e = " + e);
            Swap(ref a,ref e);
            cout("Swap: ");
            cout("a = " + a);
            cout("e = " + e);

            // out modifier
            cout("\nSome reference types\n");
            int beforeDot = SeperateDouble(val, out double afterDot);
            cout(beforeDot);
            cout(afterDot);

            // static constructor
            cout(Coffee.Price);
            cout(Coffee.CupVolume);

            // basic threads
            ThreadStart Start = new ThreadStart(PrintInACycle);

            Thread ChildThread = new Thread(Start);
            ChildThread.Start();

            Thread.Sleep(200);

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("Main Thread. i = " + i);
                Thread.Sleep(700);
            }
<<<<<<< HEAD

        }
=======
        }*/
>>>>>>> 735f14e86e6e4bda7ec0b5eba154a608dc83cf4a
    }
}
