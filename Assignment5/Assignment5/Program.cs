using System;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Player[] Team1 = new Player[5] { new RugbyPlayer(), new RugbyPlayer(), new BasketballPlayer(), new BasketballPlayer(), new BasketballPlayer() };
            Player[] Team2 = new Player[5] { new RugbyPlayer(), new RugbyPlayer(), new RugbyPlayer(), new RugbyPlayer(), new BasketballPlayer() };
            Team1[0].DisplayQualitites();
            for (int i = 0; i < Team1.Length; i++)
            {
                Team1[i].Train();
                Team1[i].TrainAtGym();
                Team2[i].Train();
                Team1[i].TrainAtGym();
            }
            Team1[0].DisplayQualitites();
            DisplayTeamQualities(Team1);
            DisplayTeamQualities(Team2);
            PlayBasketballGame(Team1, Team2);
            PlayRugbyGame(Team1, Team2);
        }

        static void PlayBasketballGame(Player[] Team1, Player[] Team2)
        {
            float Team1Rating = 0, Team2Rating = 0;
            for (int i = 0; i < Team1.Length; i++)
            {
                Team1Rating += Team1[i] is BasketballPlayer? Team1[i].Rating : Team1[i].Rating * 0.8f;
                Team2Rating += Team2[i] is BasketballPlayer ? Team2[i].Rating : Team2[i].Rating * 0.8f;
            }

            if (Team1Rating > Team2Rating)
                Console.WriteLine("Team 1 Wins a Basketball Game!");
            else if (Team2Rating > Team1Rating)
                Console.WriteLine("Team 2 Wins a Basketball Game!");
            else
                Console.WriteLine("Draw!");
        }
        static void PlayRugbyGame(Player[] Team1, Player[] Team2)
        {
            float Team1Rating = 0, Team2Rating = 0;
            for (int i = 0; i < Team1.Length; i++)
            {
                Team1Rating += Team1[i] is RugbyPlayer ? Team1[i].Rating : Team1[i].Rating * 0.8f;
                Team2Rating += Team2[i] is RugbyPlayer ? Team2[i].Rating : Team2[i].Rating * 0.8f;
            }

            if (Team1Rating > Team2Rating)
                Console.WriteLine("Team 1 Wins a Rugby Game!");
            else if (Team2Rating > Team1Rating)
                Console.WriteLine("Team 2 Wins a Rugby Game!");
            else
                Console.WriteLine("Draw!");
        }

        static void DisplayTeamQualities(Player[] Team)
        {
            Console.WriteLine("--------");
            float TeamRating = 0;
            for (int i = 0; i < Team.Length; i++)
            {
                Console.WriteLine("Player\'s {0} Rating: {1:f3}", (i+1), Team[i].Rating);
                TeamRating += Team[i].Rating;
            }
            Console.WriteLine("Team rating: " + TeamRating);
            Console.WriteLine("--------");
        }

    }

    abstract class Player
    {
        public readonly float GeneticalFactor;
        private float _stamina, _speed, _strength, _height, _weigth;
        public float Stamina { get { return _stamina; } protected set { _stamina += (value - _stamina) * GeneticalFactor; } }
        public float Speed { get { return _speed; } protected set { _speed += (value - _speed) * GeneticalFactor; } }
        public float Strength { get { return _strength; } protected set { _strength += (value - _strength) * GeneticalFactor; } }
        public float Height { get { return _height; } protected set { _height += (value - _height) * GeneticalFactor; } }
        public float Weigth { get { return _weigth; } protected set { _weigth += (value - _weigth) * GeneticalFactor; } }

        public Player()
        {
            Random random = new Random();
            GeneticalFactor = (float)random.NextDouble() + 1;
            Stamina = 15;
            Speed = 10;
            Strength = 10;
            Height = 140;
            Weigth = 60;
        }

        public float Rating { 
            get { return (Stamina * 0.3f + Speed * 0.2f + Strength * 0.3f + Height * 0.1f + Weigth * 0.1f) / 5; }
        }

        public void DisplayQualitites()
        {
            Console.WriteLine("--------");
            Console.WriteLine("Genetical factor: {0:f3} ", GeneticalFactor);
            Console.WriteLine("Stamina: {0:f2}", Stamina);
            Console.WriteLine("Speed: {0:f2}", Speed);
            Console.WriteLine("Strength: {0:f2}", Strength);
            Console.WriteLine("Height: {0:f2}", Height);
            Console.WriteLine("Weigth: {0:f2}", Weigth);
            Console.WriteLine("Rating: {0:f2}", Rating);
            Console.WriteLine("--------");
        }

        public abstract void Train();

        public abstract void TrainAtGym();

        protected virtual void UseDope() { }
        protected virtual void UseDope(int quantity) { }

        protected bool WillUseDope()
        {
            Random random = new Random();
            int chance = random.Next(1, 100);
            int modulo = random.Next(1, 10);
            return (chance - modulo) % 10 == 0;
        }
    }

    class BasketballPlayer : Player
    {
        public override void Train()
        {
            Stamina += 2;
            Speed += 4;
            Height += 0.02f;
            Weigth += 0.02f;

            if (WillUseDope())
                UseDope();
            
        }

        public override void TrainAtGym()
        {
            Height += 0.01f;
            Weigth += 0.03f;
            Stamina += 1;
            Strength += 4;

            if (WillUseDope())
                UseDope(2);
        }

        protected override void UseDope()
        {
            UseDope(3);
        }

        protected override void UseDope(int quantity)
        {
            Stamina += 1.8f * quantity;
            Speed += 1.5f * quantity;
            Weigth += 0.3f * quantity;
            Strength += quantity;
        }
    }

    class RugbyPlayer : Player
    {
        public override void Train()
        {
            Stamina += 2;
            Speed += 3;
            Height += 0.01f;
            Weigth += 0.04f;

            if (WillUseDope())
                UseDope();

        }

        public override void TrainAtGym()
        {
            Height += 0.01f;
            Weigth += 0.05f;
            Stamina += 2;
            Strength += 5;

            if (WillUseDope())
                UseDope(3);
        }

        protected override void UseDope()
        {
            UseDope(2);
        }

        protected override void UseDope(int quantity)
        {
            Stamina += 2.5f * quantity;
            Speed += 0.75f * quantity;
            Weigth += 0.5f * quantity;
            Strength += 1.4f * quantity;
        }
    }
}
