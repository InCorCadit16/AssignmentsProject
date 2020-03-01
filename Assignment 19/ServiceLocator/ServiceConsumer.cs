using System;

namespace ServiceLocator
{
    public class ServiceConsumer
    {
        public IService CurrentService { get; set; }

        static void Main(string[] args)
        {
            ServiceConsumer consumer = new ServiceConsumer();

            ServiceLocator.RegisterService(new ServiceA());
            ServiceLocator.RegisterService(new ServiceB());

            consumer.CurrentService = ServiceLocator.Provide<ServiceA>();

            consumer.CurrentService.DoSomeWork();
        }
    }
}
