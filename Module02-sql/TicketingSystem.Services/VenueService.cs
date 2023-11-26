using AutoMapper;
using TicketingSystem.Domain.DTOs.Section;
using TicketingSystem.Domain.DTOs.Venue;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Domain.Interfaces.Services;

namespace TicketingSystem.Services
{
    public class VenueService : IVenueService
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;

        public VenueService(IMapper mapper, ICommonRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<SectionDto>> GetSectionsByVenueIdAsync(int venueId)
        {
            var sections = await _repository.Sections.FindByVenueIdAsync(venueId);

            var sectionDtos = _mapper.Map<IEnumerable<SectionDto>>(sections);

            return sectionDtos ?? Enumerable.Empty<SectionDto>();
        }

        public async Task<IEnumerable<VenueDto>> GetVenuesAsync()
        {
            var venues = await _repository.Venues.FindAllAsync();

            var venueDtos = _mapper.Map<IEnumerable<VenueDto>>(venues);

            return venueDtos ?? Enumerable.Empty<VenueDto>();
        }
    }
}
