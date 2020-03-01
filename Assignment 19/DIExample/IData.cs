using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIExample
{
    interface IData
    {
        void GetDescription();

        void GetCode();
    }

    class ProductData : IData
    {
        public void GetCode()
        {
            Console.WriteLine("Personal Code of Product Data: 111");
        }

        public void GetDescription()
        {
            Console.WriteLine("Desciption of Product Data");
        }
    }

}
