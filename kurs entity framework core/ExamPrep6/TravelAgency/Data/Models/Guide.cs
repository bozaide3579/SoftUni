using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Data.Models.Enums;

namespace TravelAgency.Data.Models
{
	using static DataConstraints;

	public class Guide
	{
		[Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(GuideFullNameMax)]
		public string FullName { get; set; } = null!;

		[Required]
        public Language Language { get; set; }

		public virtual ICollection<TourPackageGuide> TourPackagesGuides { get; set; }
		= new HashSet<TourPackageGuide>();
    }
}
