using Microsoft.Data.SqlClient.DataClassification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data
{
	public class DataConstraints
	{
		public const int CustomerFullNameMin = 4;
		public const int CustomerFullNameMax = 60;
		public const int CustomerEmailMin = 6;
		public const int CustomerEmailMax = 50;
		public const int CustomerPhoneNumberLength = 13;
		public const string CustomerPhoneNumberRegex = @"^\+\d{12}$";

		public const int GuideFullNameMin = 4;
		public const int GuideFullNameMax = 60;

		public const int TourPackageNameMin = 2;
		public const int TourPackageNameMax = 40;
		public const int TourPackageDescriptionMax = 200;
	}
}
