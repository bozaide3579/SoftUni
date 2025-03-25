using NetPay.Data.Models.Enums;
using NetPay.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPay.DataProcessor.ImportDtos
{
	using static NetPay.Data.DataConstraints;

	public class ImportExpenceDto
	{
		[Required]
		[MinLength(ExpenseNameMin)]
		[MaxLength(ExpenseNameMax)]
		public string ExpenseName { get; set; } = null!;

		[Required]
		[Range(typeof(decimal), ExpenseAmoutMinStr, ExpenseAmoutMaxStr)]
		public decimal Amount { get; set; }

		[Required]
		public string DueDate { get; set; } = null!;

		[Required]
		public string PaymentStatus { get; set; } = null!;

		[Required]
		public int HouseholdId { get; set; }

		[Required]
		public int ServiceId { get; set; }
	}
}
