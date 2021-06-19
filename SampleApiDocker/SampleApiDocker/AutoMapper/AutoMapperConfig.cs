using AutoMapper;
using SampleApiDocker.Entities;
using SampleApiDocker.Entities.Model;

namespace SampleApiDocker.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<EventEntitie, EventModel>().ReverseMap();
        }
    }
}
