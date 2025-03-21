using Cadastre.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.DataProcessor.ImportDtos
{
	using static Cadastre.Data.DataConstraints;

	public class ImportCitizenDto
	{
		[Required]
		[MinLength(CitizenFirstNameMinLength)]
		[MaxLength(CitizenFirstNameMaxLength)]
		public string FirstName { get; set; } = null!;

		[Required]
		[MinLength(CitizenLastNameMinLength)]
		[MaxLength(CitizenLastNameMaxLength)]
		public string LastName { get; set; } = null!;

		[Required]
		public string BirthDate { get; set; } = null!;

		[Required]
		[EnumDataType(typeof(MaritalStatus))]
		public string MaritalStatus { get; set; } = null!;

		[Required]
		public int[] Properties { get; set; } = null!;
    }
}
