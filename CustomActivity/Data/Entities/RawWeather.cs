using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomActivity.Data.Entities
{
    public class RawWeather
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

        [ForeignKey("CityId")]
        public City City { get; set; }
    }
}
