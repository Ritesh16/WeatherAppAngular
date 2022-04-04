using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class WeatherAlert
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int WeatherId { get; set; }
        [StringLength(80)]
        public string SenderName { get; set; }
        [StringLength(150)]
        public string Event { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
        
        [Required]
        public DateTime DateUpdated { get; set; }
        
        [ForeignKey("WeatherId")]
        public Weather Weather { get; set; }
        
    }
}