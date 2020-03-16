using System;
using System.Runtime.Serialization;

namespace Forest_Register.modell
{
    [Serializable]
    internal class HibasVevoCimException : Exception
    {
        public HibasVevoCimException()
        {
        }

        public HibasVevoCimException(string message) : base(message)
        {
        }

        public HibasVevoCimException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HibasVevoCimException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}