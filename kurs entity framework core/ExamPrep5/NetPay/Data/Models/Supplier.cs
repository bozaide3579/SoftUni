using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace NetPay.Data.Models
{
	using static DataConstraints;

	public class Supplier
	{
		[Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(SupplierNameMax)]
		public string SupplierName { get; set; } = null!;

		public virtual ICollection<SupplierService> SuppliersServices { get; set; }
		= new HashSet<SupplierService>();
    }
}
