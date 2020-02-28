using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment18.CoffeeFacade
{
    class CoffeMachineFacade
    {
        private WaterHeater _whaterHeater;
        private MilkService _milkService;
        private WhipPreparator _whipPreparator;
        private BeansPreparator _beansPreparator;
        private ChocolatePreparator _chocolatePreparator;

        public CoffeMachineFacade()
        {
            _whaterHeater = new WaterHeater();
            _milkService = new MilkService();
            _whipPreparator = new WhipPreparator();
            _beansPreparator = new BeansPreparator();
            _chocolatePreparator = new ChocolatePreparator();
        }

        public void Americano()
        {
            _whaterHeater.HeatWater();
            _beansPreparator.GetBeans();
            _beansPreparator.GetBeans();
            Console.WriteLine("Americano ready");
        }

        public void Espresso()
        {
            _whaterHeater.HeatWater();
            _whaterHeater.HeatWater();
            _beansPreparator.GetBeans();
            _whipPreparator.GetWhip();
            Console.WriteLine("Espresso ready");
        }

        public void Milk()
        {
            _milkService.GetHotMilk();
            _milkService.GetHotMilk();
            Console.WriteLine("Just Milk");
        }

        public void Frappe()
        {
            _milkService.GetColdMilk();
            _milkService.GetColdMilk();
            _beansPreparator.GetBeans();
            Console.WriteLine("Frappe Ready");
        }

        public void HotChocolate()
        {
            _milkService.GetHotMilk();
            _chocolatePreparator.PourOutChocolate();
            _chocolatePreparator.PourOutChocolate();
            _chocolatePreparator.PourOutChocolate();
            Console.WriteLine("Hot Chocolate Ready");
        }

        public void HotWater()
        {
            _whaterHeater.HeatWater();
            _whaterHeater.HeatWater();
            Console.WriteLine("Just Hot Water");
        }

        public void SelfCleare()
        {
            _whaterHeater.Clear();
            _chocolatePreparator.Clear();
            _beansPreparator.Clear();
            _milkService.Clear();
            _whipPreparator.Clear();
        }
    }
}
