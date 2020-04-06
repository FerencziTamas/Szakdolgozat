using System;
using System.Runtime.Serialization;

namespace Forest_Register.modell
{
    [Serializable]
    public class HibasVevoNevException : Exception
    {
        public HibasVevoNevException()
        {
        }

        public HibasVevoNevException(string message) : base(message)
        {
        }

        public HibasVevoNevException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HibasVevoNevException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}