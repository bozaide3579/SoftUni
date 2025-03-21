using Medicines.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.Data
{
	public class DataConstraints
	{

		public const int PharmacyNameMinLength = 2;
		public const int PharmacyNameMaxLength = 50;
		public const int PharmacyPhoneNumberLength = 14;
		public const string PharmacyPhoneNumberRegex = @"^\(\d{3}\) \d{3}-\d{4}$";
		public const string PharmacyBooleanRegex = @"^(true|false)$";

		public const int MedicineNameMinLength = 3;
		public const int MedicineNameMaxLength = 150;
		public const decimal MedicinePriceMinLength = 0.01m;
		public const decimal MedicinePriceMaxLength = 1000.00m;
		public const int MedicineProducerNameMinLength = 3;
		public const int MedicineProducerNameMaxLength = 100;
		public const int MedicineCategoryMinLength = (int)Category.Analgesic;
		public const int MedicineCategoryMaxLength = (int)Category.Vaccine;

		public const int PatientFullNameMinLength = 5;
		public const int PatientFullNameMaxLength = 100;
		public const int PatientAgeGroupMinLength = (int)AgeGroup.Child;
		public const int PatientAgeGroupMaxLength = (int)AgeGroup.Senior;
		public const int PatientGenderMinLength = (int)Gender.Male;
		public const int PatientGenderMaxLength = (int)Gender.Female;




	}
}
