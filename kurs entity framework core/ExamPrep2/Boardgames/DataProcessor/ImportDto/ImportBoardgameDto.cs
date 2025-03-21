using Boardgames.Data;
using Boardgames.Data.Models;
using Boardgames.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
	using static DataConstraints;

	[XmlType(nameof(Boardgame))]
	public class ImportBoardgameDto
	{
		[XmlElement(nameof(Name))]
		[Required]
		[MinLength(BoardgameNameMinLength)]
		[MaxLength(BoardgameNameMaxLength)]
		public string Name { get; set; } = null!;

		[XmlElement(nameof(Rating))]
		[Required]
		[Range(BoardgameRatingMinLength, BoardgameRatingMaxLength)]
		public double Rating { get; set; }

		[XmlElement(nameof(YearPublished))]
		[Required]
		[Range(BoardgameYearPublishedMinLength, BoardgameYearPublishedMaxLength)]
		public int YearPublished { get; set; }

		[XmlElement(nameof(CategoryType))] 
		[Required]
		[Range(BoaedgameCategoryMinLength, BoaedgameCategoryMaxLength)]
		public int CategoryType { get; set; }

		[XmlElement(nameof(Mechanics))]
		[Required]
		public string Mechanics { get; set; } = null!;
	}
}