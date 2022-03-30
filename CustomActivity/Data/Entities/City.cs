using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity.Data.Entities
{
    public class City
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        [Required]
        public float Latitude { get; set; }

        [Required]
        public float Longitude { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        public ICollection<Weather> WeatherDetails { get; set; }

    }
}
