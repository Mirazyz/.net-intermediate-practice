namespace TicketingSystem.Domain.Interfaces.Services
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
