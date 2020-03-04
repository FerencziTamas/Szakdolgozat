using System;
using System.Runtime.Serialization;

namespace Forest_Register.repository
{
    [Serializable]
    internal class RepositoryExceptionNemTudTorolni : Exception
    {
        public RepositoryExceptionNemTudTorolni()
        {
        }

        public RepositoryExceptionNemTudTorolni(string message) : base(message)
        {
        }

        public RepositoryExceptionNemTudTorolni(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RepositoryExceptionNemTudTorolni(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}