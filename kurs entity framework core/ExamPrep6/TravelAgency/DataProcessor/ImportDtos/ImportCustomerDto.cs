using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ImportDtos
{
	using static TravelAgency.Data.DataConstraints;

	[XmlType("Customer")]
	public class ImportCustomerDto
	{
		[Required]
		[XmlAttribute("phoneNumber")]
		[RegularExpression(CustomerPhoneNumberRegex)]
		public string PhoneNumber { get; set; } = null!;

		[Required]
		[XmlElement("FullName")]
		[MinLength(CustomerFullNameMin)]
		[MaxLength(CustomerFullNameMax)]
		public string FullName { get; set; } = null!;

		[Required]
		[XmlElement("Email")]
		[MinLength(CustomerEmailMin)]
		[MaxLength(CustomerEmailMax)]
		public string Email { get; set; } = null!;
    }
}
