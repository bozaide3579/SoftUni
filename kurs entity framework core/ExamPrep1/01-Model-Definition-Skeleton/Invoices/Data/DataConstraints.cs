using System;
using Invoices.Data.Models.Enums;

namespace Invoices.Data
{
	public class DataConstraints
	{
		public const byte ProductNameMinLenght = 9;
        public const byte ProductNameMaxLenght = 30;
		public const string ProductPriceMinValue = "5.00";
		public const string ProductPriceMaxValue = "1000.00";
		public const int ProductCategoryTypeMinValue = (int)CategoryType.ADR;
        public const int ProductCategoryTypeMaxValue = (int)CategoryType.Tyres;

        public const byte AdressStreetNameMinLength = 10;
        public const byte AdressStreetNameMaxLength = 20;
		public const byte AdressCityMinLength = 5;
		public const byte AdressCityMaxLength = 15;
        public const byte AdressCountryMinLength = 5;
        public const byte AdressCountryMaxLength = 15;

		public const int InvoiceNumberMinValue = 1_000_000_000;
        public const int InvoiceNumberMaxValue = 1_500_000_000;
		public const int InvoiceCurrencyTypeMinValue = (int)CurrencyType.BGN;
		public const int InvoiceCurrencyTypeMaxValue = (int)CurrencyType.USD;

        public const int ClientNameMinLength = 10;
        public const int ClientNameMaxLength = 25;
		public const int ClientNumberVatMinLength = 10;
        public const int ClientNumberVatMaxLength = 15;


    }
}

