using System;
using System.Collections.Generic;
using System.Text;
using PublisherSolution;

namespace ReceiversProject
{
    public class Starter
    {
        static void Main(string[] args)
        {
            SalesPublisher Publisher = new SalesPublisher();

            var SmsService = new SmsService();
            var EmailService = new EmailService();

            
            Publisher.SalesEventHandler += SmsService.SaleStarted;
            Publisher.SalesEventHandler += EmailService.SaleStarted;
            PublisherStarter.SetPublisher(Publisher);
            PublisherStarter.Main(new string[1]);
        }

        
     
    }
}
