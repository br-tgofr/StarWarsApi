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
        [Route("{id}")]
        public async Task<IActionResult> GetIdPeopleAsync([FromRoute] int id)
        {
            {
                using (var httpClient = new HttpClient())
                {
                    People result = _context.Peoples.FirstOrDefault(people => people.PeopleId == id);

                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        ReadPeopleDto readPeopleId = new ReadPeopleDto();
                        readPeopleId.PeopleId = id;

                        httpClient.BaseAddress = new Uri("https://swapi.dev/api/");
                        var response = await httpClient.GetAsync($"people/{id}/");
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var getPeople = JsonConvert.DeserializeObject<ReadPeopleDto>(jsonResponse);

                        if (getPeople != null)
                        {
                            People people = _mapper.Map<People>(getPeople);
                            _context.Peoples.Add(people);
                            _context.SaveChanges();
                            return Ok(people);
                        }
                        return NotFound();
                    }
                }
            }
        }
    }
}
