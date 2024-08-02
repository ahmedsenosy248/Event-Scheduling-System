using EventSchedulingSystem.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEvents()
    {
        var events = await _eventService.GetAllEventsAsync();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventById(Guid id)
    {
        var evnt = await _eventService.GetEventByIdAsync(id);
        if (evnt == null)
            return NotFound();

        return Ok(evnt);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvent([FromBody] EventDto eventDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdEvent = await _eventService.CreateEventAsync(eventDto);
        return CreatedAtAction(nameof(GetEventById), new { id = createdEvent.Id }, createdEvent);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent(Guid id, [FromBody] EventDto eventDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedEvent = await _eventService.UpdateEventAsync(id, eventDto);
        if (updatedEvent == null)
            return NotFound();

        return Ok(updatedEvent);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(Guid id)
    {
        var result = await _eventService.DeleteEventAsync(id);
        if (!result)
            return NotFound();

        return NoContent();
    }
}
