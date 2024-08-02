namespace EventSchedulingSystem.Application
{
    public class EventRegistrationDto
    {
        public string UserId { get; set; }
        public Guid EventId { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}
