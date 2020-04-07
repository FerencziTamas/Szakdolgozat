using System;
using System.Runtime.Serialization;

namespace Forest_Register.modell
{
    [Serializable]
    public class HibasErGazCimException : Exception
    {
        public HibasErGazCimException()
        {
        }

        public HibasErGazCimException(string message) : base(message)
        {
        }

        public HibasErGazCimException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HibasErGazCimException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}