using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StarWarsAPI.Data;
using StarWarsAPI.Data.Dtos.Starship;
using StarWarsAPI.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StarshipController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public StarshipController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStarshipIdAsync([FromRoute] string id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new System.Uri("https://swapi.dev/api/");
                var response     = await httpClient.GetAsync($"starships/{id}/");
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var starship = JsonConvert.DeserializeObject<ReadStarshipDto>(jsonResponse);

                if (starship != null)
                {
                    ReadStarshipDto readStarshipDto = _mapper.Map<ReadStarshipDto>(starship);
                    return Ok(readStarshipDto);
                }
                return NotFound();
            }
        }
    }
}
