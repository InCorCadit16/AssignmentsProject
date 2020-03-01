using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using ServiceLocator;

namespace DIExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var productContainer = new UnityContainer();
            productContainer.RegisterType<MarketProduct>();
            productContainer.RegisterType<IData, ProductData>();

            var marketProduct = productContainer.Resolve<MarketProduct>();

            marketProduct.GetPersonalCode();
            marketProduct.GetDescription();

            Console.ReadKey();
        }
    }
}
