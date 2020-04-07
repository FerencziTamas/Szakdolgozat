using System;
using System.Runtime.Serialization;

namespace Forest_Register.modell
{
    [Serializable]
    public class HibasVevoUresException : Exception
    {
        public HibasVevoUresException()
        {
        }

        public HibasVevoUresException(string message) : base(message)
        {
        }

        public HibasVevoUresException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HibasVevoUresException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}