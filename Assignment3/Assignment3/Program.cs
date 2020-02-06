using System;

namespace Assignment3
{
    class ISPDemonstration
    {
        interface ISingable
        {
            public void Sing();
        }

        interface IWritable
        {
            public void Write();
        }

        interface IPlayable
        {
            public void Play();
        }


        class Musician : ISingable, IWritable, IPlayable
        {
            public void Play()
            {
                Console.WriteLine("*Sound of Guitar...*");
            }

            public void Sing()
            {
                Console.WriteLine("lalala");
            }

            public void Write()
            {
                Console.WriteLine("*Writing notes for a song...*");
            }
        }

        class Writer : IWritable
        {
            public void Write()
            {
                Console.WriteLine("*Writing a story...*");
            }
        }


        static void Main(string[] args)
        {
            IWritable writer = new Writer();
            writer.Write();

            IWritable musician = new Musician();
            musician.Write();

            ((Musician)musician).Play();
            ((Musician)musician).Sing();

            if (musician is Musician)
            {
                Console.WriteLine("musician is Musician");
            }

            if (musician is ISingable)
            {
                Console.WriteLine("musician is ISingable");
            }
        }
    }

    class OCPDemonstration
    {
        abstract class MoneyHolder
        {
            protected int Amount;

            public MoneyHolder(int Amount)
            {
                this.Amount = Amount;
            }

            public abstract bool Withdraw(int Payment);
        }

        class Card: MoneyHolder
        {
            int PINCODE;

            public Card(int Amount, int PINCODE) : base(Amount)
            {
                this.PINCODE = PINCODE;
            }

            public override bool Withdraw(int Payment)
            {
                Console.Write("PINCODE: ");
                int pin = int.Parse(Console.ReadLine());
                if (pin == PINCODE)
                {
                    if (Amount > Payment) 
                    {
                        Amount -= Payment;
                        return true;
                    }
                    Console.WriteLine("Not enough money");
                    return false;
                }

                Console.WriteLine("Wrong PINCODE");
                return false;
            }
        }

        class Cash : MoneyHolder
        {

            public Cash(int Amount) : base(Amount) { }

            public override bool Withdraw(int Payment)
            {
                if (Amount >= Payment)
                {
                    Amount -= Payment;
                    return true;
                }
                Console.WriteLine("Not enough money");
                return false;
            }
        }

        static int CupOfCoffeePrice = 30;
        static void BuyCoffee(MoneyHolder PaySource)
        {
            bool operationResult = PaySource.Withdraw(CupOfCoffeePrice);
            if (operationResult)
                Console.WriteLine("*You drink coffee...*");
            
        }

       /* static void Main(string[] Args)
        {
            MoneyHolder[] MyFinances = new MoneyHolder[2];

            MyFinances[0] = new Card(500,1234);
            MyFinances[1] = new Cash(320);

            foreach (MoneyHolder Holder in MyFinances) {
                BuyCoffee(Holder);
            }
        }*/
    }

    class Polymorphism
    {
        class AddEverything
        {
            public int Add(int a, int b)
            {
                return a + b;
            }

            public string Add(string a, string b)
            {
                return a + b;
            }

            public bool Add(bool a, bool b)
            {
                return a || b;
            }
        }

        static public void Swap<T>(ref T a,ref T b)
        {
            T temp;
            temp = a;
            a = b;
            b = temp;
        }

        class Vector
        {
            public int x, y;

            public Vector(int x, int y)
            {
                this.x = x; this.y = y;
            }

            public static Vector operator+(Vector first, Vector second) {
                return new Vector(first.x + second.x, first.y + second.y);
            }

            public override string ToString()
            {
                
                return "{" + x + ", " + y + "}";
            }
        }

        /*public static void Main(string[] Args)
        {
            AddEverything Adder = new AddEverything();
            Console.WriteLine(Adder.Add(12,22));
            Console.WriteLine(Adder.Add("Hi, ","Mark!"));
            Console.WriteLine(Adder.Add(true,false));

            Vector v1 = new Vector(7,12);
            Vector v2 = new Vector(6,-3);
            Console.WriteLine("v1: " + v1.ToString());
            Console.WriteLine("v2: " + v2.ToString());
            Swap<Vector>(ref v1,ref v2);
            Console.WriteLine("v1: " + v1.ToString());
            Console.WriteLine("v2: " + v2.ToString());
            Console.WriteLine("sum: " + (v1 + v2).ToString());

        }*/
    }
}
