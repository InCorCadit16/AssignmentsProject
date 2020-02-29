using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLocator
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object>
            services = new Dictionary<Type, object>();

        public static T Provide<T>()
        {
            try
            {
                return (T)services[typeof(T)];
            } catch (KeyNotFoundException ke)
            {
                throw new Exception($"Service of type {typeof(T)} is not registered", ke);
            }
        }

        public static void RegisterService<T>(T service)
        {
            services[typeof(T)] = service;
        }
    }
}
