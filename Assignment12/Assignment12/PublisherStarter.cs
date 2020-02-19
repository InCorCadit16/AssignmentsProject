using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PublisherSolution
{
    public class PublisherStarter
    {

        static SalesPublisher Publisher;
        public static void Main(string[] args)
        {
            while (Publisher == null)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Wating for Publisher instance...");
            }

            int i = 1;
            while (i != 0)
            {
                Console.WriteLine("1 - create sale\n 0 - exit");
                i = int.Parse(Console.ReadLine());
            }
            
        }

        public static void SetPublisher(SalesPublisher Publisher)
        {
            PublisherStarter.Publisher = Publisher;
        }
    }
}
