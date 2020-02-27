using System;

namespace Assignment17
{
    abstract class Phone
    {
        ISmsSendable smsSender;
        ICallable caller;
        IFaceCallable faceCaller;

        public abstract void Call(long phoneNumber);

        public abstract void SendSMS(string text);

        public abstract void FaceCall(long phoneNumber);

        public abstract string DisplayInfo();
    }

    class Smartphone : Phone
    {
        ISmsSendable smsSender = new FastWirelessSms();
        ICallable caller = new FastWirelessCall();
        IFaceCallable faceCaller = new BasicFaceCall();
        public override void Call(long phoneNumber)
        {
            caller.Call(phoneNumber);
        }

        public override string DisplayInfo()
        {
            return "Basic Modern Smarphone";
        }

        public override void FaceCall(long phoneNumber)
        {
            faceCaller.FaceCall(phoneNumber);
        }

        public override void SendSMS(string text)
        {
            smsSender.sendSms(text);
        }
    }
}
