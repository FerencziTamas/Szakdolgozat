using System;
using System.Runtime.Serialization;

namespace Forest_Register.repository
{
    [Serializable]
    internal class RepositoryExceptionNemTudModositani : Exception
    {
        public RepositoryExceptionNemTudModositani()
        {
        }

        public RepositoryExceptionNemTudModositani(string message) : base(message)
        {
        }

        public RepositoryExceptionNemTudModositani(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RepositoryExceptionNemTudModositani(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}