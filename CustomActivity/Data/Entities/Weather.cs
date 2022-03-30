using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity.Data.Entities
{
    public class Weather
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int CityId { get; set; }

        [Required]
        public string WeatherJson { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        public City City { get; set; }
    }
}
