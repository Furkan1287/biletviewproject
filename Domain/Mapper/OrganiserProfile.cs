using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Domain.Mapper
{
    public class OrganiserProfile : Profile
    {
        public OrganiserProfile()
        {
            CreateMap<Organiser, OrganiserDetailDto>().ReverseMap();
            CreateMap<Organiser, OrganiserCreateDto>().ReverseMap();
        }
    }
}
