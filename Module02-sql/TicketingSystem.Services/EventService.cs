using AutoMapper;
using TicketingSystem.Domain.DTOs.Event;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Domain.Interfaces.Services;

namespace TicketingSystem.Services
{
    public class EventService : IEventService
    {
        private readonly ICommonRepository _repository;
        private readonly IMapper _mapper;

        public EventService(ICommonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventDto>> GetEventsAsync()
        {
            var events = await _repository.Events.FindAllAsync();

            return _mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task<EventDto> GetEventByIdAsync(int id)
        {
            var eventEntity = await _repository.Events.FindByIdAsync(id);

            return _mapper.Map<EventDto>(eventEntity);
        }

        public async Task<EventDto> CreateEventAsync(EventForCreateDto eventToCreate)
        {
            ArgumentNullException.ThrowIfNull(eventToCreate);

            var eventEntity = _mapper.Map<Event>(eventToCreate);

            var createdEntity = await _repository.Events.CreateAsync(eventEntity);

            return _mapper.Map<EventDto>(createdEntity);
        }

        public async Task<EventDto> UpdateEventAsync(EventForUpdateDto eventToUpdate)
        {
            ArgumentNullException.ThrowIfNull(eventToUpdate);

            var eventEntity = _mapper.Map<Event>(eventToUpdate);

            await _repository.Events.UpdateAsync(eventEntity);

            return _mapper.Map<EventDto>(eventEntity);
        }

        public async Task DeleteEventAsync(int id)
        {
            await _repository.Events.DeleteAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
