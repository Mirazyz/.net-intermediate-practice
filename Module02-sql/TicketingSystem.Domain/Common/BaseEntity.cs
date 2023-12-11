using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingSystem.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        private readonly List<BaseEvent> _domainEvents = new();

        [NotMapped]
        public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddEvent(BaseEvent domainEvent)
        {
            if (domainEvent == null)
                return;

            if (_domainEvents.Contains(domainEvent))
                return;

            _domainEvents.Add(domainEvent);
        }

        public void RemoveEvent(BaseEvent domainEvent)
        {
            if (domainEvent == null)
                return;

            if (!_domainEvents.Contains(domainEvent))
                return;

            _domainEvents.Remove(domainEvent);
        }

        public void ClearEvents()
        {
            _domainEvents.Clear();
        }
    }
}
