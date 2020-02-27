using System;
using System.Collections.Generic;

namespace Assignment17
{
    class Program
    {
        static void Main(string[] args)
        {
            var Gadjets = new List<Phone>() { new Sellphone(), new Smartphone(), new StationalPhone() };

            Gadjets[0].FaceCall(8_800_555_3535);
            Gadjets[0].Call(8_800_555_3535);

            Gadjets[1].SendSMS("test sms");

            Gadjets[2].FaceCall(022_642975);

            Gadjets[2].SendSMS("anyway it does not support this");

            Gadjets[2].smsSender = new WirelessSms();

            Gadjets[2].SendSMS("I can send sms from my stational home");

            foreach (var gadjet in Gadjets)
            {
                Console.WriteLine(gadjet.DisplayInfo());
            }
        }
    }
}
