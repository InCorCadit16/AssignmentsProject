using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLocator
{
    public static class ServiceLocator
    {
        static IService _instance;

        public static IService Provide()
        {
            return _instance;
        }

        public static void RegisterService(IService service)
        {
            _instance = service;
        }
    }
}
