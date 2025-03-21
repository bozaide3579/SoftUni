using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.Data.Models
{
	using static DataConstraints;

	public class Pharmacy
	{
		[Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(PharmacyNameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[StringLength(PharmacyPhoneNumberLength)]
		[RegularExpression(@"\(\d{3}\) \d{3}-\d{4}")]
		public string PhoneNumber { get; set; } = null!;

		[Required]
        public bool IsNonStop { get; set; }

		public virtual ICollection<Medicine> Medicines { get; set; }
		 = new HashSet<Medicine>();


    }
}
