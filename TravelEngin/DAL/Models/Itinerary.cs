using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelEngin.DAL.Models
{
    public class Itinerary
    {
        public int Id { get; set; }

        [ForeignKey("TravelPackage")]
        public int TravelPackageId { get; set; }

        [Range(1, 365)]
        public int DayNumber { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string Activities { get; set; }

        public string Accommodation { get; set; }

        public string Meals { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        // Navigation Property
        public virtual TravelPackage TravelPackage { get; set; }
    }
}