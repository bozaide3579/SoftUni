using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NetPay.Data.Models
{
	using static DataConstraints;

	public class Service
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(ServiceNameMax)]
		public string ServiceName { get; set; } = null!;

		public virtual ICollection<Expense> Expenses { get; set; } 
		= new HashSet<Expense>();

		public virtual ICollection<SupplierService> SuppliersServices { get; set; }
		= new HashSet<SupplierService>();
    }
}
