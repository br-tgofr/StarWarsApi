using AutoMapper;
using StarWarsAPI.Data.Dtos.Starship;
using StarWarsAPI.Models;

namespace StarWarsAPI.Profiles
{
    public class StarshipProfile : Profile
    {
        public StarshipProfile()
        {
            CreateMap<Starship, ReadStarshipDto>();
        }
    }
}
