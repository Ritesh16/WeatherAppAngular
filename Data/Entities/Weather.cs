using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Weather
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int CityId { get; set; }
        
        [Required]
        public int WeatherJson { get; set; }
        
        [Required]
        public bool IsActive { get; set; }
        
        [Required]
        public DateTime DateCreated { get; set; }
        
        [Required]
        public DateTime DateUpdated { get; set; }

        public City City { get; set; }
    }
}