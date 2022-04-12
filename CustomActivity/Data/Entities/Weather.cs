using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomActivity.Data.Entities
{
    public class Weather
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int CityId { get; set; }
        [Required]
        public DateTime WeatherDate { get; set; }

        [Required]
        public DateTime Sunrise { get; set; }
        [Required]
        public DateTime Sunset { get; set; }
        [Required]
        public DateTime Moonrise { get; set; }
        [Required]
        public DateTime Moonset { get; set; }

        [Required]
        public float MoonPhase { get; set; }
        [Required]
        public float Pressure { get; set; }

        [Required]
        public float Humidity { get; set; }

        [Required]
        public float DewPoint { get; set; }

        [Required]
        public float WindSpeed { get; set; }

        [Required]
        public float WindDeg { get; set; }

        [Required]
        public float WindGust { get; set; }

        [Required]
        public float Clouds { get; set; }

        [Required]
        public float Pop { get; set; }

        [Required]
        public float UVI { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }
       // public virtual Temperature Temperature { get; set; }
        //public virtual ICollection<WeatherDescription> WeatherDescriptions { get; set; }
        //public virtual ICollection<WeatherAlert> WeatherAlerts { get; set; }

    }
}
