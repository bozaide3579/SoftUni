using Cadastre.Data.Enumerations;
using Microsoft.Data.SqlClient.DataClassification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.Data
{
	public class DataConstraints
	{
		public const int DistrictNameMinLength = 2;
		public const int DistrictNameMaxLength = 80;
		public const int DistrictPostalCodeLength = 8;
		public const string DistrictPostalCodeRegex = "^[A-Z]{2}-\\d{5}$";
		public const int DistrictRegionMinLength = (int)Region.SouthEast;
		public const int DistrictRegionMaxLength = (int)Region.NorthWest;

		public const int PropertyIndentifierMinLenght = 16;
		public const int PropertyIndentifierMaxLenght = 20;
		public const int PropertyDeatilsMinLength = 5;
		public const int PropertyDeatilsMaxLength = 500;
		public const int PropertyAddressMinLength = 5;
		public const int PropertyAddressMaxLength = 200;
		public const int PropertyAreaMinLength = 0;

		public const int CitizenFirstNameMinLength = 2;
		public const int CitizenFirstNameMaxLength = 30;
		public const int CitizenLastNameMinLength = 2;
		public const int CitizenLastNameMaxLength = 30;
		public const int CitizenMaritalStatusMinLength = (int)MaritalStatus.Unmarried;
		public const int CitizenMaritalStatusMaxLength = (int)MaritalStatus.Widowed;

	}
}
