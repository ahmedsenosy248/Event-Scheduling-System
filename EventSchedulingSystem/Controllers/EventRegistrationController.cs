using EventSchedulingSystem.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EventRegistrationController : ControllerBase
{
    private readonly IEventRegistrationService _eventRegistrationService;

    public EventRegistrationController(IEventRegistrationService eventRegistrationService)
    {
        _eventRegistrationService = eventRegistrationService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUserForEvent([FromBody] EventRegistrationDto eventRegistrationDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _eventRegistrationService.RegisterAsync(eventRegistrationDto);
        if (!result)
            return BadRequest("Registration failed.");

        return Ok("Registration successful.");
    }

    [HttpDelete("unregister")]
    public async Task<IActionResult> UnregisterUserFromEvent([FromBody] EventRegistrationDto eventRegistrationDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _eventRegistrationService.UnregisterAsync(eventRegistrationDto);
        if (!result)
            return BadRequest("Unregistration failed.");

        return Ok("Unregistration successful.");
    }

    [HttpGet("user/{userId}/events")]
    public async Task<IActionResult> GetAllEventsForUser(string userId)
    {
        var events = await _eventRegistrationService.GetAllEventsForUserAsync(userId);
        return Ok(events);
    }

    [HttpGet("event/{eventId}/users")]
    public async Task<IActionResult> GetAllUsersForEvent(Guid eventId)
    {
        var users = await _eventRegistrationService.GetAllUsersForEventAsync(eventId);
        return Ok(users);
    }
}
