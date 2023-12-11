using System.Runtime.Serialization;

namespace TicketingSystem.Domain.Exceptions.Payment
{
    [Serializable]
    public class PaymentProcessingException : PaymentException
    {
        public PaymentProcessingException() { }
        public PaymentProcessingException(string message) : base(message) { }
        public PaymentProcessingException(string message, Exception innerException) : base(message, innerException) { }
        protected PaymentProcessingException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
