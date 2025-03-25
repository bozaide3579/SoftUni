using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPay.Data.Models
{
	using static DataConstraints;

	public class Household
	{
		[Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(HouseholdContactPersonMax)]
		public string ContactPerson { get; set; } = null!;

		[MaxLength(HouseholdEmailMax)]
		public string? Email { get; set; }

		[Required]
		public string PhoneNumber { get; set; } = null!;

		public virtual ICollection<Expense> Expenses { get; set; }
		= new HashSet<Expense>();
    }
}
