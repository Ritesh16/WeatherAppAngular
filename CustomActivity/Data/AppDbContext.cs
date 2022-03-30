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

        public DbSet<City> Cities { get; set; }
        public DbSet<Weather> Weathers { get; set; }
    }
}
