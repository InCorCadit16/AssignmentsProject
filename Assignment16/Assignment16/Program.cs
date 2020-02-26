using Assignment16.Singleton;
using SimpleFactory;
using System;
using System.Collections.Generic;

namespace Assignment16
{
    class Program
    {
        static void Main(string[] args)
        {
            SingletonExample();
        }

        static void SingletonExample()
        {
            DataSingleton Singleton = DataSingleton.GetInstance();
            Singleton.AddUser(new User { Id = 1, Age = 22, Name = "Jacky Mao" });
            Singleton.AddUser(new User { Id = 2, Age = 17, Name = "Steven King", Status = Status.Experienced });
            Singleton.AddUser(new User { Id = 3, Age = 19, Name = "Bill Mellow", Status = Status.Experienced });
            Singleton.AddUser(new User { Id = 4, Age = 14, Name = "Ethan Kyle" });
            Singleton.AddUser(new User { Id = 5, Age = 39, Name = "Seth Chest", Status = Status.Professional });
            Singleton.AddUser(new User { Id = 6, Age = 29, Name = "Fill Heat", Status = Status.Professional });

            List<User> neededUsers = UserValidator.Validate(18, 30, Status.Experienced);

            Console.WriteLine("\nList 1: ");
            foreach (var user in neededUsers)
            {
                Console.WriteLine($"\nId: {user.Id}, Name: {user.Name}, Age: {user.Age}, Status: {user.Status}");
            }

            neededUsers = UserValidator.Validate(maxAge: 23, orderBy: "Name");


            Console.WriteLine("\nList 2");
            foreach (var user in neededUsers)
            {
                Console.WriteLine($"\nId: {user.Id}, Name: {user.Name}, Age: {user.Age}, Status: {user.Status}");
            }
        }

        static void FactoryExample()
        {
            Car PorcheCayman = CarFactory.CreateCar("Porche", "Cayman S", CarcassType.Coupe, 210, 25, 1.4f);
            PorcheCayman.SetDimensions(1.25f, 1.90f, 1.10f);

            Car Lancer = CarFactory.CreateCar("Mitsubishi", "Lancer", CarcassType.Coupe, 180, 27.5f);

            Car KiaRioXline = CarFactory.CreateCar("KIA", "Rio", CarcassType.SUV, 200, 29, 2.2f);
            KiaRioXline.SetDimensions(1.45f, 2.15f, 1.55f);

            KiaRioXline.ChangeWheels(new Wheel() { Diameter = 26.5f, Manufacturer = "Somebody", PatternDepth = 1.5f });

            Console.WriteLine(PorcheCayman);
            Console.WriteLine(Lancer);
            Console.WriteLine(KiaRioXline);
        }
    }
}