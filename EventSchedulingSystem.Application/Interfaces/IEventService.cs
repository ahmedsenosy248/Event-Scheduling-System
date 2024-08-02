using EventSchedulingSystem.Application;

public interface IEventService
{
    Task<IEnumerable<EventDto>> GetAllEventsAsync();
    Task<EventDto> GetEventByIdAsync(Guid id);
    Task<EventDto> CreateEventAsync(EventDto eventDto);
    Task<EventDto> UpdateEventAsync(Guid id, EventDto eventDto);
    Task<bool> DeleteEventAsync(Guid id);
}
