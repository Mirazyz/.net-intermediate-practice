using AutoMapper;
using TicketingSystem.Domain.DTOs.Event;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Domain.Mappings
{
    public class EventMapping : Profile
    {
        public EventMapping()
        {
            CreateMap<Event, EventDto>();
            CreateMap<EventDto, Event>();
            CreateMap<EventForCreateDto, Event>();
            CreateMap<EventForUpdateDto, Event>();
        }
    }
}
