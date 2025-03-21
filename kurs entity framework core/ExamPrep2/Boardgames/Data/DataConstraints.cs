using Boardgames.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data
{
	public class DataConstraints
	{

		public const int CreatorFirstNameMinLength = 2;
		public const int CreatorFirstNameMaxLength = 7;
		public const int CreatorLastNameMinLength = 2;
		public const int CreatorLastNameMaxLength = 7;

		public const int BoardgameNameMinLength = 10;
		public const int BoardgameNameMaxLength = 20;
		public const double BoardgameRatingMinLength = 1.00;
		public const double BoardgameRatingMaxLength = 10.00;
		public const int BoardgameYearPublishedMinLength = 2018;
		public const int BoardgameYearPublishedMaxLength = 2023;
		public const int BoaedgameCategoryMinLength = (int)CategoryType.Abstract;
		public const int BoaedgameCategoryMaxLength = (int)CategoryType.Strategy;

		public const int SellerNameMinLength = 5;
		public const int SellerNameMaxLength = 20;
		public const int SellerAddressMinLength = 2;
		public const int SellerAddressMaxLength = 30;


	}
}
