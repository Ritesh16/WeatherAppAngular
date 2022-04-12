using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomActivity.Data.Entities
{
    public class Temperature
    {
        [Key]
        [Required]
        public int Id { get; set; }

        //[ForeignKey("Weather")]
        public int WeatherId { get; set; }

        [Required]
        public float Day { get; set; }
        [Required]
        public float Min { get; set; }
        [Required]
        public float Max { get; set; }
        [Required]
        public float Night { get; set; }
        [Required]
        public float Evening { get; set; }
        [Required]
        public float Morning { get; set; }
        [Required]
        public float Day_FeelsLike { get; set; }
        [Required]
        public float Night_FeelsLike { get; set; }
        [Required]
        public float Evening_FeelsLike { get; set; }
        [Required]
        public float Morning_FeelsLike { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        [ForeignKey("WeatherId")]
        public virtual Weather Weather { get; set; }

    }
}
