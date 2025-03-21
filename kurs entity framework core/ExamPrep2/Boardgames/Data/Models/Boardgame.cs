using Boardgames.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boardgames.Data.Models
{
	using static DataConstraints;

	public class Boardgame
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(BoardgameNameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[Range(BoardgameRatingMinLength, BoardgameRatingMaxLength)]
		public double Rating { get; set; }

		[Required]
		[Range(BoardgameYearPublishedMinLength, BoardgameYearPublishedMaxLength)]
        public int YearPublished { get; set; }

		[Required]
		[Range(BoaedgameCategoryMinLength, BoaedgameCategoryMaxLength)]
		public CategoryType CategoryType { get; set; }

		[Required]
		public string Mechanics { get; set; } = null!;

		[ForeignKey(nameof(Creator))]
        public int CreatorId { get; set; }
		public Creator Creator { get; set; } = null!;

        public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
			= new HashSet<BoardgameSeller>();

    }
}