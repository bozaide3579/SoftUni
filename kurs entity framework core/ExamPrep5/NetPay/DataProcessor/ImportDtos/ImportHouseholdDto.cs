using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ImportDtos
{
	using static NetPay.Data.DataConstraints;

	[XmlType("Household")]
	public class ImportHouseholdDto
	{
		[Required]
		[XmlElement("ContactPerson")]
		[MinLength(HouseholdContactPersonMin)]
		[MaxLength(HouseholdContactPersonMax)]
		public string ContactPerson { get; set; } = null!;

		[XmlElement("Email")]
		[MinLength(HouseholdEmailMin)]
		[MaxLength(HouseholdEmailMax)]
		public string? Email { get; set; }

		[Required]
		[XmlAttribute("phone")]
		[StringLength(HouseholdPhoneNumberLength)]
		[RegularExpression(HouseholdPhoneNumberRegex)]
		public string PhoneNumber { get; set; } = null!;
	}
}
