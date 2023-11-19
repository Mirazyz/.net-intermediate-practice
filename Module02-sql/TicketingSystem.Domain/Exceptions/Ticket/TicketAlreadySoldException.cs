using System.Runtime.Serialization;

namespace TicketingSystem.Domain.Exceptions.Ticket
{
    [Serializable]
    public class TicketAlreadySoldException : TicketException
    {
        public TicketAlreadySoldException() { }
        public TicketAlreadySoldException(string message) : base(message) { }
        public TicketAlreadySoldException(string message, Exception inner) : base(message, inner) { }
        protected TicketAlreadySoldException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
