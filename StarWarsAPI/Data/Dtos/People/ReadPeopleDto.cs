using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using AutoMapper.Configuration.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json.Serialization;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace StarWarsAPI.Data.Dtos.People
{
    public class ReadPeopleDto
    {
        [Key]
        [Required]
        [JsonProperty("id")]
        public int PeopleId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("mass")]
        public string Mass { get; set; }

        [JsonProperty("hair_color")]
        public string HairColor { get; set; }

        [JsonProperty("skin_color")]
        public string SkinColor { get; set; }

        [JsonProperty("eye_color")]
        public string EyeColor { get; set; }

        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("homeworld")]
        public string Homeworld { get; set; }

        [JsonProperty("films")]
        public List<string> Films { get; set; }

        [JsonProperty("species")]
        public List<string> Species { get; set; }

        [JsonProperty("vehicles")]
        public List<string> Vehicles { get; set; }

        [JsonProperty("starships")]
        public List<string> Starships { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("edited")]
        public DateTime Edited { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
        public DateTime HoraDaConsulta { get; set; }
    }
}
