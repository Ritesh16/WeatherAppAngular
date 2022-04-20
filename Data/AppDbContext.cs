using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext: DbContext
    {
        private readonly string connectionString;
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Weather> Weathers { get; set; }
        public DbSet<RawWeather> RawWeathers { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }           
        public DbSet<WeatherAlert> WeatherAlerts { get; set; }
        public DbSet<WeatherDescription> WeatherDescriptions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<RawWeather>().ToTable("RawWeather");
            modelBuilder.Entity<Weather>().ToTable("Weather");
            modelBuilder.Entity<Temperature>().ToTable("Temperature");
            modelBuilder.Entity<WeatherDescription>().ToTable("WeatherDescription");
            modelBuilder.Entity<WeatherAlert>().ToTable("WeatherAlert");
        }
    }
}
