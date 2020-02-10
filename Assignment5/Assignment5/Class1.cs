using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    class Testing
    {
        public static void Main(string[] args)
        {
            Bird[] Birds = new Bird[3]
            {
                new Eagle() { Weigth = 4.7f, Wingspan = 1.2f, MaxSpeed = 75 },
                new Pinguin() { Weigth = 6.6f, Wingspan = 1.5f, MaxSpeed = 7 },
                new Eagle() { Weigth = 0.1f, Wingspan = 0.14f, MaxSpeed = 28 },
            };
            foreach (Bird Bird in Birds)
            {
                Bird.Eat();
                Bird.Fly();
            }
        }
    }

    public enum FeedType { CARNIVOROUS, HERBIVOROUS, OMNIVOROUS } 

    public interface IFly
    {
        void Fly();
    }

    public class CanFly: IFly
    {
        public void Fly()
        {
            Console.WriteLine("I\'m flying!");
        }
    }

    public class NoFly : IFly
    {
        public void Fly()
        {
            Console.WriteLine("I can\'t fly! :(");
        }
    }

    abstract class Bird
    {
        public static readonly FeedType Feeding;
        protected IFly FlyAbility;
        public float Weigth;
        public float Wingspan;
        public float MaxSpeed;

        public abstract void Eat();
        public void Fly()
        {
            FlyAbility.Fly();
        }
    }

    class Eagle : Bird
    {
        public static readonly FeedType Feeding = FeedType.CARNIVOROUS;

        public Eagle()
        {
            FlyAbility = new CanFly();
        }

        public override void Eat()
        {
            Console.WriteLine("Eagle is eating a mouse");
        }

        
    }

    class Pinguin : Bird
    {
        public static readonly FeedType Feeding = FeedType.CARNIVOROUS;

        public Pinguin() {
            FlyAbility = new NoFly();    
        }

        public override void Eat()
        {
            Console.WriteLine("Pinguin is eating a fish");
        }
    }

    class Sparrow : Bird
    {
        public static readonly FeedType Feeding = FeedType.HERBIVOROUS;

        public Sparrow()
        {
            FlyAbility = new CanFly();
        }

        public override void Eat()
        {
            Console.WriteLine("Sparrow is eating some corns");
        }
    }
}
