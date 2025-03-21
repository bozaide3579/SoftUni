using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.Data.Models
{
	using static DataConstraints;

	public class Property
	{
		[Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(PropertyIndentifierMaxLenght)]
		public string PropertyIdentifier { get; set; } = null!;

		[Required]
        public int Area { get; set; }

		[MaxLength(PropertyDeatilsMaxLength)]
		public string Details { get; set; } = null!;

		[Required]
		[MaxLength(PropertyAddressMaxLength)]
		public string Address { get; set; } = null!;

		[Required]
        public DateTime DateOfAcquisition { get; set; }

		[Required]
		[ForeignKey(nameof(District))]
        public int DistrictId { get; set; }
		public virtual District District { get; set; } = null!;

		public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; }
		= new HashSet<PropertyCitizen>();
    }
}
