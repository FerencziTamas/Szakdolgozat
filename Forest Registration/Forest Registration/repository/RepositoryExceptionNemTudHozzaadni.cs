using System;
using System.Runtime.Serialization;

namespace Forest_Register.repository
{
    [Serializable]
    internal class RepositoryExceptionNemTudHozzaadni : Exception
    {
        public RepositoryExceptionNemTudHozzaadni()
        {
        }

        public RepositoryExceptionNemTudHozzaadni(string message) : base(message)
        {
        }

        public RepositoryExceptionNemTudHozzaadni(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RepositoryExceptionNemTudHozzaadni(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}