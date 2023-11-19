using System.Runtime.Serialization;

namespace TicketingSystem.Domain.Exceptions.Ticket
{
    [Serializable]
    public class TicketBookedException : TicketException
    {
        public TicketBookedException() { }
        public TicketBookedException(string message) : base(message) { }
        public TicketBookedException(string message, Exception inner) : base(message, inner) { }
        protected TicketBookedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
