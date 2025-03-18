using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Invoices.Data.Models;

namespace Invoices.DataProcessor.ImportDto
{
    using static Data.DataConstraints;


    [XmlType(nameof(Address))]
	public class ImportAdressDto
	{
		[XmlElement(nameof(StreetName))]
		[Required]
		[MinLength(AdressStreetNameMinLength)]
        [MaxLength(AdressStreetNameMaxLength)]
        public string StreetName { get; set; } = null!;

		[XmlElement(nameof(StreetNumber))]
		[Required]
		public int StreetNumber { get; set; }

		[XmlElement(nameof(PostCode))]
		[Required]
		public string PostCode { get; set; } = null!;

		[XmlElement(nameof(City))]
		[Required]
		[MinLength(AdressCityMinLength)]
        [MaxLength(AdressCityMaxLength)]
        public string City { get; set; }

		[XmlElement(nameof(Country))]
		[Required]
		[MinLength(AdressCountryMinLength)]
		[MaxLength(AdressCountryMaxLength)]
		public string Country { get; set; }
	}
}

