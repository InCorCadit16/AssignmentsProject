using System;
using System.Collections.Generic;
using PublisherSolution;

namespace ReceiversProject
{ 
    class SmsService
    {

        public void SaleStarted(object sender, SalesEventArgs args)
        {
            Console.WriteLine("New Sms Generated: ");
            Console.WriteLine(GenerateSms(args));
        }

        private string GenerateSms(SalesEventArgs args)
        {
            return $"\nDear Sms Subscriber! There is a sale on {args.ProductName}. Now you can buy in with {args.SaleInPercents}%, " +
                $"means only for {args.SalePrice} instead of {args.DefaultPrice}. Hurry up! The sale will end on {args.EndTime}\n";
        }

    }
}
