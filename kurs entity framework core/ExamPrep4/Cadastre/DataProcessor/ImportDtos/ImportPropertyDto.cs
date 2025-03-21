using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
	using static Cadastre.Data.DataConstraints;

	[XmlType("Property")]
	public class ImportPropertyDto
	{
		[Required]
		[XmlElement("PropertyIdentifier")]
		[MinLength(PropertyIndentifierMinLenght)]
		[MaxLength(PropertyIndentifierMaxLenght)]
		public string PropertyIdentifier { get; set; } = null!;

		[Required]
		[XmlElement("Area")]
		[Range(0, int.MaxValue)]
		public int Area { get; set; }

		[XmlElement("Details")]
		[MinLength(PropertyDeatilsMinLength)]
		[MaxLength(PropertyDeatilsMaxLength)]
		public string? Details { get; set; }

		[Required]
		[XmlElement("Address")]
		[MinLength(PropertyAddressMinLength)]
		[MaxLength(PropertyAddressMaxLength)]
		public string Address { get; set; } = null!;

		[Required]
		[XmlElement("DateOfAcquisition")]
        public string DateOfAcquisition { get; set; } = null!;
    }
}