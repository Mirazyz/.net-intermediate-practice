using AutoMapper;
using TicketingSystem.Domain.DTOs.Section;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Domain.Mappings
{
    public class SectionsMapping : Profile
    {
        public SectionsMapping()
        {
            CreateMap<Section, SectionDto>();
            CreateMap<SectionDto, Section>();
        }
    }
}
