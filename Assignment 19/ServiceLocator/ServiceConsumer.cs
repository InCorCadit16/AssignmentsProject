using System;

namespace ServiceLocator
{
    public class ServiceConsumer
    {
        public IService CurrentService { get; set; };

        static void Main(string[] args)
        {
            ServiceConsumer Consumer = new ServiceConsumer();

            ServiceLocator.RegisterService(new ServiceA());
            ServiceLocator.RegisterService(new ServiceB());

            Consumer.CurrentService = ServiceLocator.Provide<ServiceA>();

            Consumer.CurrentService.DoSomeWork();
        }
    }
}
