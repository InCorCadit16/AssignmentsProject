﻿using System;

namespace PublisherSolution
{
    public class SalesPublisher
    {
        public event EventHandler<SalesEventArgs> SalesEventHandler;
        

        public void OnNewSaleStarted(SalesEventArgs args)
        {
            Console.WriteLine("\nPublisher Received Following Sale:");
            Console.WriteLine(args);
            
            SalesEventHandler(this, args);
        }
    }
}
