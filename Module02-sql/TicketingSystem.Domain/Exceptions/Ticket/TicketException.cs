using System.Runtime.Serialization;

namespace TicketingSystem.Domain.Exceptions.Ticket
{
    [Serializable]
    public class TicketException : Exception
    {
        public TicketException() { }
        public TicketException(string message) : base(message) { }
        public TicketException(string message, Exception inner) : base(message, inner) { }
        protected TicketException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
