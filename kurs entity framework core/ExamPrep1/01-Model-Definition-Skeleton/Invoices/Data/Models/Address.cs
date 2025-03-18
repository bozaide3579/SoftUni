namespace Invoices.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstraints;

	public class Address
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(AdressStreetNameMaxLength)]
		public string StreetName { get; set; } = null!;

		[Required]
		public int StreetNumber { get; set; }

		[Required]
		public string PostCode { get; set; } = null!;

		[Required]
		[MaxLength(AdressCityMaxLength)]
		public string City { get; set; } = null!;

		[Required]
		[MaxLength(AdressCountryMaxLength)]
		public string Country { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Client))]
		public int  ClientId { get; set; }

		[Required]
		public virtual Client Client { get; set; } = null!;

	}
}

