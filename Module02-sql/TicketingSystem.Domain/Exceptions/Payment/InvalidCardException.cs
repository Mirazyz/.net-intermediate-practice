using System.Runtime.Serialization;

namespace TicketingSystem.Domain.Exceptions.Payment
{
    [Serializable]
    public class InvalidCardException : PaymentException
    {
        public InvalidCardException() { }
        public InvalidCardException(string message) : base(message) { }
        public InvalidCardException(string message, Exception innerException) : base(message, innerException) { }
        protected InvalidCardException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
