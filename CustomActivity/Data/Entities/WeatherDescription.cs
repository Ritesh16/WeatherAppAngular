using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomActivity.Data.Entities
{
    public class WeatherDescription
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int WeatherId { get; set; }
        [Required]
        public string Main { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Icon { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }
        [ForeignKey("WeatherId")]
        public Weather Weather { get; set; }
    }
}
