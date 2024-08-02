using AutoMapper;
using EventSchedulingSystem.Application;
using EventSchedulingSystem;
using EventSchedulingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class EventAppService : IEventService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public EventAppService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EventDto>> GetAllEventsAsync()
    {
        var events = await _context.Events.ToListAsync();
        return _mapper.Map<IEnumerable<EventDto>>(events);
    }

    public async Task<EventDto> GetEventByIdAsync(Guid id)
    {
        var evnt = await _context.Events.FindAsync(id);
        if (evnt == null)
            return null;

        return _mapper.Map<EventDto>(evnt);
    }

    public async Task<EventDto> CreateEventAsync(EventDto eventDto)
    {
        var evnt = _mapper.Map<Event>(eventDto);
        _context.Events.Add(evnt);
        await _context.SaveChangesAsync();
        return _mapper.Map<EventDto>(evnt);
    }

    public async Task<EventDto> UpdateEventAsync(Guid id, EventDto eventDto)
    {
        var evnt = await _context.Events.FindAsync(id);
        if (evnt == null)
            return null;

        _mapper.Map(eventDto, evnt);
        _context.Events.Update(evnt);
        await _context.SaveChangesAsync();
        return _mapper.Map<EventDto>(evnt);
    }

    public async Task<bool> DeleteEventAsync(Guid id)
    {
        var evnt = await _context.Events.FindAsync(id);
        if (evnt == null)
            return false;

        evnt.IsDeleted = true;
        _context.Events.Update(evnt);
        await _context.SaveChangesAsync();
        return true;
    }
}
