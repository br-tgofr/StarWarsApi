using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StarWarsAPI.Data;
using StarWarsAPI.Data.Dtos.Planets;
using StarWarsAPI.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanetController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public PlanetController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlanetIdAsync()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://swapi.dev/api/");
                var response     = await httpClient.GetAsync("planets/1/");
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var planet = JsonConvert.DeserializeObject<ReadPlanetDto>(jsonResponse);

                if (planet != null)
                {
                    ReadPlanetDto readPlanetDto = _mapper.Map<ReadPlanetDto>(planet);
                    return Ok(readPlanetDto);
                }
                return NotFound();
            }
        }
    }
}
