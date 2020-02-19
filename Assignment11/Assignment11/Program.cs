using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment11
{
    class Program
    {
        static void Main(string[] args)
        {
            var Names = new List<string> { "Jane", "Jacob", "Simon", "Terry", "Alex", "Simon", "John" };
            var Names2 = new List<string> { "Ion", "Alex", "Jane", "Artur", "Victor", "Ivy" };
            var Holders = new List<Holder>
            {
                new Holder { Available = new List<Item>() { Item.CreateRandomItem(),Item.CreateRandomItem(),Item.CreateRandomItem() }, Name = "Holder #1" },
                new Holder { Available = new List<Item>() { Item.CreateRandomItem(),Item.CreateRandomItem(),Item.CreateRandomItem() }, Name = "Holder #2" },
                new Holder { Available = new List<Item>() { Item.CreateRandomItem(),Item.CreateRandomItem(),Item.CreateRandomItem() }, Name = "Holder #3" },
            };

            // Filtering
            var HasE = Names.Where(s => s.Contains('e'));

            // Projection
            var PlusJR = Names.Select(s => s + " Jr.");
            var NamesAndPrices = Holders.SelectMany(h => h.Available, (h, item) => new { h.Name, item.Price }).ToList();


            // Joining
            var RepeatedNames = Names.Join(Names2,
                                            s => s,
                                            s => s,
                                            (s1,s2) => new { FirstS = s1, SecondS = s2 }).ToList();

            // Ordering
            var ItemsByRatingAndId = Holders.First()
                                            .Available.OrderBy(item => item.Price).ThenBy(item => item.Rating);

            // Grouping
            var GroupsOfNames = Names.GroupBy(s => s.Substring(0,3));

            // Set Operators
            var NoDublictes = Names.Union(Names2).ToHashSet();

            // First 
            var Artur = Names2.First(s => s.Contains("Art"));

            // Aggregation
            var Product = Holders.First().Available.Select(item => item.Price).Aggregate((prod, price) => prod * price);

            var HasZ = Names.Any(s => s.Contains('z'));

            var Digits = Enumerable.Range(0, 9);
            var _5Items = Enumerable.Repeat(Item.CreateRandomItem(), 5);

            Method[] action = new Method[2];

            int outer = 0;

            for (int i = 0; i < action.Length; i++)
            {
                int inner = 0;

                action[i] = () =>
                {
                    Console.WriteLine($"inner: {inner} and outer: {outer}");
                    inner++;
                    outer++;
                };
            }

            Method first = action[0];
            Method second = action[1];

            first();
            first();
            first();
            first();

            second();
            second();
            second();
            second();

            first();

            second();

        }

        public delegate void Method();

        class Holder
        {
            public string Name;
            public List<Item> Available;
        }

        class Item
        {
            public int Price;
            public int Rating;
            

            public static Item CreateRandomItem()
            {
                Random random = new Random();
                return new Item
                {
                    Price = random.Next(1, 400),
                    Rating = random.Next(1, 10),
                };
            }
        }
    }
}
