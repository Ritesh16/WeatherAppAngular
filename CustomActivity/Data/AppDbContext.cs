using CustomActivity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(string connectionString) : base(connectionString)
        {

        }

        public DbSet<City> City { get; set; }
        public DbSet<RawWeather> RawWeather { get; set; }
        public DbSet<Weather> Weather { get; set; }
        public DbSet<Temperature> Temperature { get; set; }
        public DbSet<WeatherDescription> WeatherDescription { get; set; }
        public DbSet<WeatherAlert> WeatherAlert { get; set; }
    }
}
