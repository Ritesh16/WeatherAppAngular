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
        //public DbSet<Weather> Weathers { get; set; }
         public DbSet<RawWeather> RawWeathers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<RawWeather>().ToTable("RawWeather");
        }
    }
}
