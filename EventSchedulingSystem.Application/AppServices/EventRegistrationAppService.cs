using AutoMapper;
using EventSchedulingSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventSchedulingSystem.Application
{
    public class EventRegistrationAppService : IEventRegistrationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EventRegistrationAppService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> RegisterAsync(EventRegistrationDto eventRegistrationDto)
        {
            var registration = _mapper.Map<EventRegistration>(eventRegistrationDto);
            _context.EventRegistrations.Add(registration);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UnregisterAsync(EventRegistrationDto eventRegistrationDto)
        {
            var registration = await _context.EventRegistrations
                .FirstOrDefaultAsync(r => r.UserId == eventRegistrationDto.UserId && r.EventId == eventRegistrationDto.EventId);

            if (registration == null)
                return false;

            _context.EventRegistrations.Remove(registration);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<EventDto>> GetAllEventsForUserAsync(string userId)
        {
            var events = await _context.EventRegistrations
                .Where(r => r.UserId == userId)
                .Select(r => r.Event)
                .ToListAsync();

            return _mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task<IEnumerable<IdentityUser>> GetAllUsersForEventAsync(Guid eventId)
        {
            var users = await _context.EventRegistrations
                .Where(r => r.EventId == eventId)
                .Select(r => r.User)
                .ToListAsync();

            return _mapper.Map<IEnumerable<IdentityUser>>(users);
        }


    }
}
