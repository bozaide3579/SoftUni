using System;
using System.ComponentModel.DataAnnotations;

namespace Invoices.DataProcessor.ImportDto
{
	using static Data.DataConstraints;

	public class ImportProductDto
	{
		[Required]
		[MinLength(ProductNameMinLenght)]
		[MaxLength(ProductNameMaxLenght)]
		public string Name { get; set; } = null!;

		[Required]
		[Range(typeof(decimal), ProductPriceMinValue, ProductPriceMaxValue)]
		public decimal Price { get; set; }

		[Required]
		[Range(ProductCategoryTypeMinValue, ProductCategoryTypeMaxValue)]
		public int CategoryType { get; set; }

		[Required]
		public int[] Clients { get; set; } = null!;

	}
}

