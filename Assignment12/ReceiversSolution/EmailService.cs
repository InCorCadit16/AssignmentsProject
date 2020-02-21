using PublisherSolution;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReceiversSolution
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
            return $"Dear Mail Subscriber! There is a sale on {args.ProductName}. Now you can buy in with {args.SaleInPercents}%, " +
                $"means only for {args.SalePrice} instead of {args.DefaultPrice}.\n Hurry up! The sale will end on {args.EndTime}\n";
        }
    }
}
