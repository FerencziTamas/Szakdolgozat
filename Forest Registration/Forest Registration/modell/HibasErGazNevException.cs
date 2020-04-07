using System;
using System.Runtime.Serialization;

namespace Forest_Register.modell
{
    [Serializable]
    public class HibasErGazNevException : Exception
    {
        public HibasErGazNevException()
        {
        }

        public HibasErGazNevException(string message) : base(message)
        {
        }

        public HibasErGazNevException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HibasErGazNevException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}