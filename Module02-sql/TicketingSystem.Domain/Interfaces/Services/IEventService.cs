using TicketingSystem.Domain.DTOs.Event;

namespace TicketingSystem.Domain.Interfaces.Services
{
    public interface IEventService
    {
        public Task<IEnumerable<EventDto>> GetEventsAsync();
        public Task<EventDto> GetEventByIdAsync(int id);
        public Task<EventDto> CreateEventAsync(EventForCreateDto eventToCreate);
        public Task<EventDto> UpdateEventAsync(EventForUpdateDto eventToUpdate);
        public Task DeleteEventAsync(int id);
    }
}
