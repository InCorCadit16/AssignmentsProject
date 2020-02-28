using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment18.CoffeeFacade
{
    class MilkService
    {
        public void GetColdMilk()
        {
            Console.WriteLine("Poured out milk");
        }

        public void GetHotMilk()
        {
            Console.WriteLine("Poured out hot milk");
        }

        private void HeatMilk()
        {
            Console.WriteLine("Heating Milk");
        }

        public void Clear()
        {
            Console.WriteLine("Clearing Milk Reservoir");
        }
    }
}