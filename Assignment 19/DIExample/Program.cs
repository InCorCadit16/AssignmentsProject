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
           var serviceContainer = new UnityContainer();

           serviceContainer.RegisterType<IService, ServiceA> ();
           serviceContainer.RegisterType<IService, ServiceB> ();

            var consumer = serviceContainer.Resolve<ServiceConsumer>();
            consumer.CurrentService.DoSomeWork();
           
        }
    }
}
