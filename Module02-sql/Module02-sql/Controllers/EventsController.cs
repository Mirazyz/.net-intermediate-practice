using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Domain.DTOs.Event;
using TicketingSystem.Domain.Interfaces.Services;

namespace Module02_sql.Controllers
{
    [Route("api/events")]
    [ApiController]
    [ResponseCache(CacheProfileName = "240SecondsCacheProfile")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEventsAsync()
        {
            var events = await _eventService.GetEventsAsync();

            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetByIdAsync(int id)
        {
            var eventDto = await _eventService.GetEventByIdAsync(id);

            return Ok(eventDto);
        }

        [HttpPost]
        public async Task<ActionResult<EventDto>> CreateAsync(EventForCreateDto eventToCreate)
        {
            var result = await _eventService.CreateEventAsync(eventToCreate);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<EventDto>> UpdateAsync(EventForUpdateDto eventToUpdate)
        {
            var result = await _eventService.UpdateEventAsync(eventToUpdate);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _eventService.DeleteEventAsync(id);

            return NoContent();
        }
    }
}
