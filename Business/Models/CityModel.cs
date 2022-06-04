using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class CityModel
    {
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
    }
}