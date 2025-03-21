using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
	using static Medicines.Data.DataConstraints;

	[XmlType(nameof(Medicine))]
	public class ImportMedicineDto
	{
		[Required]
		[XmlAttribute("category")]
		[Range(MedicineCategoryMinLength, MedicineCategoryMaxLength)]
		public int Category { get; set; }

		[Required]
		[XmlElement(nameof(Name))]
		[MinLength(MedicineNameMinLength)]
		[MaxLength(MedicineNameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[XmlElement(nameof(Price))]
		[Range((double)MedicinePriceMinLength, (double)MedicinePriceMaxLength)]
		public decimal Price { get; set; }

		[Required]
		[XmlElement(nameof(ProductionDate))]
		public string ProductionDate { get; set; } = null!;

		[Required]
		[XmlElement(nameof(ExpiryDate))]
		public string ExpiryDate { get; set; } = null!;

		[Required]
		[XmlElement(nameof(Producer))]
		[MinLength(MedicineProducerNameMinLength)]
		[MaxLength(MedicineProducerNameMaxLength)]
		public string Producer { get; set; } = null!;
	}
}