using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
