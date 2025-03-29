using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Data.Models
{
	using static DataConstraints;

	public class TourPackage
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(TourPackageNameMax)]
		public string PackageName { get; set; } = null!;

		[MaxLength(TourPackageDescriptionMax)]
		public string? Description { get; set; }

		[Required]
        public decimal Price { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
		= new HashSet<Booking>();

		public virtual ICollection<TourPackageGuide> TourPackagesGuides { get; set; }
		= new HashSet<TourPackageGuide>();
    }
}