using AutoMapper;
using TicketingSystem.Domain.DTOs.Venue;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Domain.Mappings
{
    public class VenueMapping : Profile
    {
        public VenueMapping()
        {
            CreateMap<Venue, VenueDto>();
            CreateMap<VenueDto, Venue>();
        }
    }
}
