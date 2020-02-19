using System;
using PublisherSolution;

namespace ReceiversProject
{
    class EmailService
    {
        

        public void SaleStarted(object sender, SalesEventArgs args)
        {
            Console.WriteLine("New Email Generated: ");
            Console.WriteLine(GenerateEmail(args));
        }

        private string GenerateEmail(SalesEventArgs args)
        {
            return $"\nDear Mail Subscriber! There is a sale on {args.ProductName}. Now you can buy in with {args.SaleInPercents}%, " +
                $"means only for {args.SalePrice} instead of {args.DefaultPrice}. Hurry up! The sale will end on {args.EndTime}\n";
        }
    }
}
