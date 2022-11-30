using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StarWarsAPI.Data;
using StarWarsAPI.Data.Dtos.People;
using StarWarsAPI.Models;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace StarWarsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public PeopleController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetIdPeopleAsync([FromQuery] ReadPeopleDto readDto)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new System.Uri("https://swapi.dev/api/");
                var response     = await httpClient.GetAsync($"people/{readDto.PeopleId}/");
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var getPeople = JsonConvert.DeserializeObject<ReadPeopleDto>(jsonResponse);

                if (getPeople != null)
                {
                    ReadPeopleDto readPeopleDto = _mapper.Map<ReadPeopleDto>(getPeople);
                    return Ok(readPeopleDto);
                }
                return NotFound();
            }
        }
    }
}
