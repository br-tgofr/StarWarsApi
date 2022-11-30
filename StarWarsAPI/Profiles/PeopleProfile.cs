using AutoMapper;
using StarWarsAPI.Data.Dtos.People;
using StarWarsAPI.Models;

namespace StarWarsAPI.Profiles
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            CreateMap<People, ReadPeopleDto>();
        }
    }
}
