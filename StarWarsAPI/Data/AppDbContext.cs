using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using StarWarsAPI.Models;

namespace StarWarsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {

        }

        public DbSet<People> Peoples { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Starship> Starships { get; set; }
    }
}
