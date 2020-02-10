using System;
using System.Collections;
using System.Threading;

namespace Orders
{
    class FastFood
    {
        public static FoodList<IEatable> Orders = new FoodList<IEatable>();
        public static FoodList<IEatable> Ready = new FoodList<IEatable>();
        static IEmployee[] Restaurant;
        public static void Main(string[] args)
        {
            Orders.Add(new Burger());
            Orders.Add(new Pizza());
            Orders.Add(new Pizza());
            Orders.Add(new Wings());
            Orders.Add(new Pizza());
            Orders.Add(new Wings());
            Orders.Add(new Burger());
            Orders.Add(new Wings());
            Restaurant = new IEmployee[5] { new Chef(), new Chef(), new Waiter(), new Waiter(), new Chef() };

            while (Orders.Count != 0 || Ready.Count != 0 || !AllEmployeeAreFree())
            {
                foreach (IEmployee employee in Restaurant)
                {
                    if (employee is Chef && employee.CurrentItem == null)
                    {
                        if (Orders.Count != 0)
                        {
                            employee.CurrentItem = Orders.GetFirst();
                            Orders.Remove(employee.CurrentItem);
                            StartNewThread(employee);
                        }
                    }

                    if (employee is Waiter && employee.CurrentItem == null)
                    {
                        if (Ready.Count != 0)
                        {
                            employee.CurrentItem = Ready.GetFirst();
                            Ready.Remove(employee.CurrentItem);
                            StartNewThread(employee);
                        }
                    }
                }
            }
        }

        static void StartNewThread(IEmployee Employee)
        {
            ThreadStart Starter = new ThreadStart(Employee.ExecuteOrder);
            Thread EmployeeThread = new Thread(Starter);
            EmployeeThread.Start();
        }

        static bool AllEmployeeAreFree()
        {
            foreach (IEmployee employee in Restaurant)
            {
                if (employee.CurrentItem != null) return false;
            }

            return true;
        }
    }

    public interface IEatable
    {
        public int RequiredTime { get; }
        public string Name { get; }
    }

    public class Burger : IEatable
    {
        public int RequiredTime { get; }
        public string Name { get; }

        public Burger()
        {
            Name = "Burger";
            RequiredTime = 2000;
        }
    }

    public class Pizza : IEatable
    {
        public int RequiredTime { get; }
        public string Name { get; }

        public Pizza()
        {
            Name = "Pizza";
            RequiredTime = 5000;
        }
    }

    public class Wings : IEatable
    {
        public int RequiredTime { get; }
        public string Name { get; }

        public Wings()
        {
            Name = "Wings";
            RequiredTime = 3000;
        }
    }

    public interface IEmployee
    {
        public IEatable CurrentItem { get; set; }

        public void ExecuteOrder();
    }

    public class Waiter : IEmployee
    {
        public IEatable CurrentItem { get; set; }

        public void ExecuteOrder()
        {
            Console.WriteLine("Bring " + CurrentItem.Name + " in " + ((CurrentItem.RequiredTime / 1000) / 5f) + " minutes");
            Thread.Sleep(CurrentItem.RequiredTime/5);
            FastFood.Ready.Remove(CurrentItem);
            CurrentItem = null;
        }
    }

    public class Chef : IEmployee
    {
        public IEatable CurrentItem { get; set; }
        public void ExecuteOrder()
        {
            Console.WriteLine("Preparing " + CurrentItem.Name + " in " + (CurrentItem.RequiredTime / 1000) + " minutes");
            Thread.Sleep(CurrentItem.RequiredTime);
            FastFood.Ready.Add(CurrentItem);
            CurrentItem = null;
        }
    }

    public class FoodList<T>
    {
        ArrayList Items;
        public int Count { get { return Items.Count; } }

        public FoodList() {
            Items = new ArrayList();
        }

        public void Add(T Item)
        {
            Items.Add(Item);
        }

        public T Get(int index)
        {
            return (T)Items.ToArray()[index];
        }

        public T GetFirst()
        {
            return (T)Items.ToArray()[0];
        }

        public void Remove(T Item)
        {
            Items.Remove(Item);
        }

        public T[] ToArray()
        {
            object[] Initial = Items.ToArray();
            T[] Result = new T[Initial.Length];
            for (int i = 0; i < Initial.Length; i++)
            {
                Result[i] = (T)Initial[i];
            }
            return Result;
        }
    }

}