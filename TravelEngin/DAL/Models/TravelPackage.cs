using System.ComponentModel.DataAnnotations;

namespace TravelEngin.DAL.Models
{
    public class TravelPackage
    {
         public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(1, 365)]
        public int Duration { get; set; } // Duration in days

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        // Navigation Property
        public virtual ICollection<Itinerary> Itineraries { get; set; }
    }

    
}