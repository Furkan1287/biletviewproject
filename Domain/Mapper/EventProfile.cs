using AutoMapper;

namespace Domain.Mapper
{
    public class StandingEventProfile : Profile
    {
        public StandingEventProfile()
        {
            CreateMap<Entities.StandingEvent, DTOs.StandingEventCreateDto>().ReverseMap();
        }
    }

    public class SeatedEventProfile : Profile
    {
        public SeatedEventProfile()
        {
            CreateMap<Entities.SeatedEvent, DTOs.SeatedEventCreateDto>().ReverseMap();
        }
    }
}
