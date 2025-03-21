using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.DataProcessor.ImportDtos
{
	using static Medicines.Data.DataConstraints;
	public class ImportPatientsDto
	{
		[Required]
		[MinLength(PatientFullNameMinLength)]
		[MaxLength(PatientFullNameMaxLength)]
		public string FullName { get; set; } = null!;

		[Required]
		[Range(PatientAgeGroupMinLength, PatientAgeGroupMaxLength)]
        public int AgeGroup { get; set; }

		[Required]
		[Range(PatientGenderMinLength, PatientGenderMaxLength)]
		public int Gender { get; set; }

		[Required]
		public int[] Medicines { get; set; }
	}
}
