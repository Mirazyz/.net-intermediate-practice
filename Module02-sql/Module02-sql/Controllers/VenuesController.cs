using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Domain.DTOs.Section;
using TicketingSystem.Domain.DTOs.Venue;
using TicketingSystem.Domain.Interfaces.Services;

namespace Module02_sql.Controllers
{
    [Controller]
    [Route("api/venues")]
    public class VenuesController : Controller
    {
        private readonly IVenueService _venueService;

        public VenuesController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VenueDto>>> GetVenuesAsync()
        {
            var venues = await _venueService.GetVenuesAsync();

            return Ok(venues);
        }

        [HttpGet("{venueId}/sections")]
        public async Task<ActionResult<IEnumerable<SectionDto>>> GetSectionsAsync(int venueId)
        {
            var sections = await _venueService.GetSectionsByVenueIdAsync(venueId);

            return Ok(sections);
        }
    }
}
