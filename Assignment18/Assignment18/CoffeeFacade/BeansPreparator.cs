using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment18.CoffeeFacade
{
    class BeansPreparator
    {
        void MoveBeansToFramer()
        {
            Console.WriteLine("Moving beans to framer");
        }

        void FrameBeans()
        {
            Console.WriteLine("Fraiming Beans");
        }

        public void GetBeans()
        {
            MoveBeansToFramer();
            FrameBeans();
            Console.WriteLine("Pour framed beans");
        }

        public void Clear()
        {
            Console.WriteLine("Clearing beans Framer");
        }

    }
}
