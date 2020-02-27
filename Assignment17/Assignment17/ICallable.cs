using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment17
{
    interface ICallable
    {
        void Call(long phone);
    }

    class WirelessCall : ICallable
    {
        public void Call(long phone)
        {
            Console.WriteLine($"Calling {phone} using 2G networks...");
        }
    }

    class FastWirelessCall : ICallable
    {
        public void Call(long phone)
        {
            Console.WriteLine($"Calling {phone} using 4G networks...");
        }
    }

    class CableCall : ICallable
    {
        public void Call(long phone)
        {
            Console.WriteLine($"Calling {phone} using cable...");
        }
    }
}
