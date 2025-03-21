using Medicines.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
	using static Medicines.Data.DataConstraints;

	[XmlType(nameof(Pharmacy))]
	public class ImportPharmaciesDto
	{
		[Required]
		[XmlElement(nameof(Name))]
		[MinLength(PharmacyNameMinLength)]
		[MaxLength(PharmacyNameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[XmlElement(nameof(PhoneNumber))]
		[StringLength(PharmacyPhoneNumberLength)]
		[RegularExpression(PharmacyPhoneNumberRegex)]
		public string PhoneNumber { get; set; } = null!;

		[Required]
		[XmlAttribute("non-stop")]
		[RegularExpression(PharmacyBooleanRegex)]
		public bool IsNonStop { get; set; }

		[XmlArray(nameof(Medicines))]
		public ImportMedicineDto[] Medicines { get; set; } = null!;
    }
}
