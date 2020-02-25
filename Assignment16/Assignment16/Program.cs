using Assignment16.Singleton;
using System;
using System.Collections.Generic;

namespace Assignment16
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSingleton Singleton = DataSingleton.GetInstance();
            Singleton.AddUser(new User { Id = 1, Age = 22, Name = "Jacky Mao"});
            Singleton.AddUser(new User { Id = 2, Age = 17, Name = "Steven King", Status = Status.Experienced });
            Singleton.AddUser(new User { Id = 3, Age = 19, Name = "Bill Mellow", Status = Status.Experienced });
            Singleton.AddUser(new User { Id = 4, Age = 14, Name = "Ethan Kyle"});
            Singleton.AddUser(new User { Id = 5, Age = 39, Name = "Seth Chest", Status = Status.Professional });
            Singleton.AddUser(new User { Id = 6, Age = 29, Name = "Fill Heat", Status = Status.Professional });

            List<User> neededUsers = new UserValidator().Validate(18, 30, Status.Experienced);

            foreach (var user in neededUsers)
            {
                Console.WriteLine($"\nId: {user.Id}, Name: {user.Name}, Age: {user.Age}, Status: {user.Status}");
            }
        }
    }
}
