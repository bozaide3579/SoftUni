using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPay.Data
{
	public class DataConstraints
	{

		public const int HouseholdContactPersonMin = 5;
		public const int HouseholdContactPersonMax = 50;
		public const int HouseholdEmailMin = 6;
		public const int HouseholdEmailMax = 80;
		public const int HouseholdPhoneNumberLength = 15;
		public const string HouseholdPhoneNumberRegex = @"^\+\d{3}/\d{3}-\d{6}$";

		public const int ExpenseNameMin = 5;
		public const int ExpenseNameMax = 50;
		public const decimal ExpenseAmoutMin = 0.01m;
		public const string ExpenseAmoutMinStr = "0.01";
		public const decimal ExpenseAmoutMax = 100_000m;
		public const string ExpenseAmoutMaxStr = "100000";

		public const int ServiceNameMin = 5;
		public const int ServiceNameMax = 30;

		public const int SupplierNameMin = 3;
		public const int SupplierNameMax = 60;
	}
}
