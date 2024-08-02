using Microsoft.AspNetCore.Identity;

namespace EventSchedulingSystem
{
    public class EventRegistration
    {
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public Guid EventId { get; set; }
        public Event Event { get; set; }
    }
}
