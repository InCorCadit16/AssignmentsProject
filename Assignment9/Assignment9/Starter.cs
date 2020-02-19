using System;
using System.Collections.Generic;
using Assignment9.Model;
using Assignment9.Repositories;

namespace Assignment9
{
    class Starter
    {
        static void Main(string[] args)
        {
            var List = new MyList<int>() { 5, 2, 6, 4 };
            List.Add(12);
            List.Add(5);
            List[2] = 12;
            List.Insert(3, 5);

            Console.WriteLine($"List[2] = {List[2]}");
            Console.WriteLine($"List.Get(5) = {List.Get(5)}");
            Console.WriteLine($"Count = {List.Count}; capacity = {List.Capacity}");
            foreach (var i in List) Console.Write(i + " ");
            Console.WriteLine();

            List.Swap(0, 2);
            foreach (var i in List) Console.Write(i + " ");
            Console.WriteLine();

            /*User User = new User("User_1", "user@gmail.com","fNd34Rzw");
            IRepository<User> UserRepository = new Repository<User>();
            UserRepository.Insert(User);*/

            Parent parent = new Child();
            IEnumerable<Parent> I = new List<Child>();
            //MyList<Parent> Lst = (MyList<Parent>) I;

        }

        class Parent {

            }


        class Child : Parent
        {

        }
    }

   
   
}
