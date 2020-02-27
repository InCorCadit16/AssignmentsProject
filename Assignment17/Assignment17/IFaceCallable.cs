using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment17
{
    interface IFaceCallable
    {
        void FaceCall(long phone);
    }

    class BasicFaceCall : IFaceCallable
    {
        public void FaceCall(long phone)
        {
            Console.WriteLine($"Calling {phone} using Face Call");
        }
    }

    class NoFaceCall : IFaceCallable
    {
        public void FaceCall(long phone)
        {
            Console.WriteLine("This device doesn\'t support Face Call");
        }
    }

}
