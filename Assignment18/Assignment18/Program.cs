﻿using Assignment18.CoffeeFacade;
using System;

namespace Assignment18
{
    class Program
    {
        static void Main(string[] args)
        {
            IConnector connector = new ConnectorProxy(new string[] { "google.com", "linkedin.com", "youtube.com", "facebook.com" });

            connector.Connect("geeksforgeeks.com");

            connector.Reload();

            connector.Connect("google.com");
            connector.Connect("linkedin.com");
            connector.Reload();

            CoffeMachineFacade coffeeMachine = new CoffeMachineFacade();

            coffeeMachine.Americano();

            coffeeMachine.Frappe();

            coffeeMachine.HotChocolate();

            coffeeMachine.SelfCleare();

            coffeeMachine.HotChocolate();
        }
    }
}
