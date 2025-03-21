using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.DataProcessor.ImportDto
{
	using static Boardgames.Data.DataConstraints;

	public class ImportSellerDto
	{
		[Required]
		[MinLength(SellerNameMinLength)]
		[MaxLength(SellerNameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[MinLength(SellerAddressMinLength)]
		[MaxLength(SellerAddressMaxLength)]
		public string Address { get; set; } = null!;

		[Required]
		public string Country { get; set; } = null!;

		[Required]
		[RegularExpression(@"www\.[a-zA-Z0-9-]+\.com")]
		public string Website { get; set; } = null!;

		[JsonProperty(nameof(Boardgames))]
        public int[] BoardgamesIds { get; set; }
    }
}
