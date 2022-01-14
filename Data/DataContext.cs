using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {}

        public DbSet<Clients> clients {get; set;}
        public DbSet<SolarInteractProj> solarInteractProjs{get; set;}

    }
}