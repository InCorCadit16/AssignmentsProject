using System;
using PublisherSolution;


namespace ReceiversProject
{
    public class Starter
    {
        static SalesPublisher Publisher;
        static void Main(string[] args)
        {
            Publisher = new SalesPublisher();
          

            var SmsService = new SmsService();
            var EmailService = new EmailService();

            
            Publisher.SalesEventHandler += SmsService.SaleStarted;
            Publisher.SalesEventHandler += EmailService.SaleStarted;

            char c = default;
            while (c != '0') 
            {
                if (c == '1')
                {
                    GenerateSale();
                }

                Console.WriteLine("\n1 - add new sale");
                Console.WriteLine("0 - exit program");
                Console.WriteLine("other - do nothing");
                Console.Write("command: ");
                c = char.Parse(Console.ReadLine());
            }

            // Add WeakEventHandler

            SmsService = null;

            Publisher.OnNewSaleStarted(new SalesEventArgs
            {
                ProductName = "Last",
                DefaultPrice = 320,
                SaleInPercents = 25,
                EndTime = DateTime.Now.AddDays(4)
            });
        }

        static void GenerateSale()
        {
            var Sale = new SalesEventArgs();
            Console.Write("Product Name: ");
            Sale.ProductName = Console.ReadLine();

            Console.Write("Default Price: ");
            Sale.DefaultPrice = double.Parse(Console.ReadLine());

            Console.Write("Sale in percents: ");
            Sale.SaleInPercents = double.Parse(Console.ReadLine());

            Console.Write("Due date (dd/mm/yyyy): ");
            Sale.EndTime = DateTime.Parse(Console.ReadLine());


            Publisher.OnNewSaleStarted(Sale);
        }
        
     
    }
}
