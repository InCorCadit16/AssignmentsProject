using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLocator
{
    public interface IService
    {
        void DoSomeWork();
    }

    public class ServiceA : IService
    {
        public void DoSomeWork()
        {
            Console.WriteLine("Service A is working");
        }
    }

    public class ServiceB : IService
    {
        public void DoSomeWork()
        {
            Console.WriteLine("Service B is working");
        }
    }
}
