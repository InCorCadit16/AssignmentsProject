﻿using System;

namespace Assignment3 
{ 
    class ISPMistake
    {

        interface IArtPerson
        {
            public void Play();

            public void Write();

            public void Sing();
        }


        class Musician : IArtPerson
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

        class Writer : IArtPerson
        {
            public void Write()
            {
                Console.WriteLine("*Writing a story...*");
            }

            public void Sing()
            {
                // Writer can't sing
            }
            public void Play()
            {
                // Writer can't play
            }
        }

        static void Main(string[] args)
        {
            IArtPerson writer = new Writer();
            writer.Write();

            // Empty methods
            writer.Play();
            writer.Sing();

            IArtPerson musician = new Musician();
            musician.Write();

            musician.Play();
            musician.Sing();
        }
    }

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

    class OCPMistake
    {
        abstract class MoneyHolder
        {
            public int Amount;

            public MoneyHolder(int Amount)
            {
                this.Amount = Amount;
            }

        }

        class Card : MoneyHolder
        {
            public readonly int PINCODE;

            public Card(int Amount, int PINCODE) : base(Amount)
            {
                this.PINCODE = PINCODE;
            }
        }

        class Cash : MoneyHolder
        {
            public Cash(int Amount) : base(Amount) { }
        }

        static int CupOfCoffeePrice = 30;
        static void BuyCoffee(MoneyHolder PaySource)
        {
            if (PaySource is Card)
            {
                Card card = PaySource as Card;
                Console.Write("PINCODE: ");
                int pin = int.Parse(Console.ReadLine());
                if (pin ==  card.PINCODE)
                {
                    if  (card.Amount > CupOfCoffeePrice)
                    {
                        card.Amount -= CupOfCoffeePrice;
                        Console.WriteLine("*You drink coffee...*");

                    } else Console.WriteLine("Not enough money");
                } else Console.WriteLine("Wrong PINCODE");
            } 
            else if (PaySource is Cash)
            {
                Cash cash = PaySource as Cash;
                if (cash.Amount > CupOfCoffeePrice)
                {
                    cash.Amount -= CupOfCoffeePrice;
                    Console.WriteLine("*You drink coffee...*");

                } else Console.WriteLine("Not enough money");
            }
        }

        static void Main(string[] args)
        {
            MoneyHolder[] MyFinances = new MoneyHolder[2];

            MyFinances[0] = new Card(500,1234);
            MyFinances[1] = new Cash(320);

            foreach (MoneyHolder Holder in MyFinances) {
                BuyCoffee(Holder);
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

    class LSPMistake
    {
        class Rectangle
        {
            private int Width, Height;

            public virtual void setWidth(int Width)
            {
                this.Width = Width;
            }

            public virtual void setHeight(int Height)
            {
                this.Height = Height;
            }

            public int getWidth() { return Width; }
            public int getHeight() { return Height; }

        }

        class Square: Rectangle
        {
            public override void setWidth(int Width)
            {
                base.setWidth(Width);
                base.setHeight(Width);
            }

            public override void setHeight(int Height)
            {
                base.setHeight(Height);
                base.setWidth(Height);
            }
        }

        static int Area(Rectangle rectangle)
        {
            rectangle.setWidth(5);
            rectangle.setHeight(4);

            return rectangle.getHeight() * rectangle.getWidth();
        }


    }

    class LSPDemonstration
    {
        interface IGetArea
        {
            public double GetArea();
        }


        class Rectangle: IGetArea
        {
            public int Width, Height;

            public double GetArea()
            {
                return Width * Height;
            }

        }

        class Square : IGetArea
        {
            public int Side;
        
            public double GetArea()
            {
                return Side * Side;
            }
        }

        static double Area(IGetArea Figure)
        {
            return Figure.GetArea();
        }

        static void Main(string[] args)
        {
            IGetArea figure = new Square { Side = 5 };
            Area(figure);
            figure = new Rectangle { Width = 5, Height = 4 };
            Area(figure);
        }
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
