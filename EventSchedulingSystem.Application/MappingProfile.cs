using AutoMapper;
using EventSchedulingSystem.Application;

namespace EventSchedulingSystem
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<EventRegistration, EventRegistrationDto>().ReverseMap();
        }
    }
}
