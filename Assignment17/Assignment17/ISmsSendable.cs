using System;

namespace Assignment17
{
    interface ISmsSendable
    {
        void sendSms(string text);
    }

    class WirelessSms : ISmsSendable
    {
        public void sendSms(string text)
        {
            Console.WriteLine($"send sms using 2G network. Text: {text}");
        }
    }

    class FastWirelessSms : ISmsSendable
    {
        public void sendSms(string text)
        {
            Console.WriteLine($"send sms using 4G network. Text: {text}");
        }
    }

    class NoPhoneSms : ISmsSendable
    {
        public void sendSms(string text)
        {
            Console.WriteLine($"Device does not support sms");
        }
    }
}
