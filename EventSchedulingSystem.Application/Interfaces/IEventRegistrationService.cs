using EventSchedulingSystem.Application;
using Microsoft.AspNetCore.Identity;

public interface IEventRegistrationService
{
    Task<bool> RegisterAsync(EventRegistrationDto eventRegistrationDto);
    Task<bool> UnregisterAsync(EventRegistrationDto eventRegistrationDto);
    Task<IEnumerable<EventDto>> GetAllEventsForUserAsync(string userId);
    Task<IEnumerable<IdentityUser>> GetAllUsersForEventAsync(Guid eventId);
}
