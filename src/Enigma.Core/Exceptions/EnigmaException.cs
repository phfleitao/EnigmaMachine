using System;
using System.Runtime.Serialization;

namespace Enigma.Core.Exceptions
{
    public class EnigmaException : Exception
    {
        public EnigmaException()
        {
        }

        public EnigmaException(string message) : base(message)
        {
        }

        public EnigmaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EnigmaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
