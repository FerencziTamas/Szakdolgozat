using System;
using System.Runtime.Serialization;

namespace Forest_Register.modell
{
    [Serializable]
    public class HibasErGazUresException : Exception
    {
        public HibasErGazUresException()
        {
        }

        public HibasErGazUresException(string message) : base(message)
        {
        }

        public HibasErGazUresException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HibasErGazUresException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}