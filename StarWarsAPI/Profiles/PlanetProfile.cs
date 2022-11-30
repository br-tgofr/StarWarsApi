using AutoMapper;
using StarWarsAPI.Data.Dtos.Planets;
using StarWarsAPI.Models;

namespace StarWarsAPI.Profiles
{
    public class PlanetProfile : Profile
    {
        public PlanetProfile()
        {
            CreateMap<Planet, ReadPlanetDto>();
        }
    }
}
