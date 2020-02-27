using System;

namespace Assignment17
{
    abstract class Phone
    {
        public ISmsSendable smsSender { get; set; }
        public ICallable caller { get; set; }
        public IFaceCallable faceCaller { get; set; }

        public void Call(long phoneNumber)
        {
            PrepareUIForCall();
            caller.Call(phoneNumber);
        }

        protected abstract void PrepareUIForCall();

        public void SendSMS(string text)
        {
            smsSender.sendSms(text);
        }

        public void FaceCall(long phoneNumber)
        {
            faceCaller.FaceCall(phoneNumber);
        }

        public abstract string DisplayInfo();
    }

    class Smartphone : Phone
    {
        public Smartphone()
        {
            smsSender = new FastWirelessSms();
            faceCaller = new BasicFaceCall();
            caller = new FastWirelessCall();
        }

        public override string DisplayInfo()
        {
            return "Basic Modern Smarphone";
        }

        protected override void PrepareUIForCall()
        {
            Console.WriteLine("Switching to call screen");
        }
    }

    class Sellphone : Phone
    {

        public Sellphone()
        {
            smsSender = new WirelessSms();
            faceCaller = new NoFaceCall();
            caller = new WirelessCall();
        }

        public override string DisplayInfo()
        {
            return "Basic phone from 2007";
        }

        protected override void PrepareUIForCall()
        {
            Console.WriteLine("Show called number on screen");
        }
    }

    class StationalPhone : Phone
    {
        public StationalPhone()
        {
            smsSender = new NoPhoneSms();
            faceCaller = new NoFaceCall();
            caller = new CableCall();
        }

        public override string DisplayInfo()
        {
            return "Stational phone (like your grandmother haves)";
        }

        protected override void PrepareUIForCall()
        {
            Console.WriteLine("Make weird noises");
        }
    }
}
