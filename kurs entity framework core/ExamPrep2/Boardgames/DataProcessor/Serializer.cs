namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
	using Boardgames.DataProcessor.ExportDto;
	using Boardgames.Utilities;
	using Castle.DynamicProxy.Generators;
	using Newtonsoft.Json;
	using System.Runtime.CompilerServices;

	public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();
            const string xmlRoot = "Creators";

			/*var creators = context.Creators
				.Where(c => c.Boardgames.Any())
				.Select(c => new ExportCreatorDto()
				{
					CreatorName = string.Join(" ", c.FirstName, c.LastName),
					BoardgamesCount = c.Boardgames.Count(),
					Boardgames = c.Boardgames
						.Select(bg => new ExportBoardgameDto()
						{
							BoardgameName = bg.Name,
							BoardgameYearPublished = bg.YearPublished
						})
						.OrderBy(bg => bg.BoardgameName)
						.ToArray()
				})
				.OrderByDescending(c => c.BoardgamesCount)
				.ThenBy(c => c.CreatorName)
				.ToArray();*/

			var creators = context.Creators
				.Where(c => c.Boardgames.Any())
				.Select(c => new
				{
					CreatorName = (c.FirstName + " " + c.LastName).Trim(),
					Boardgames = c.Boardgames
						.Select(bg => new ExportBoardgameDto()
						{
							BoardgameName = bg.Name,
							BoardgameYearPublished = bg.YearPublished
						})
						.OrderBy(bg => bg.BoardgameName)
						.ToList()
				})
				.ToList() // Materialize before ordering
				.Select(c => new ExportCreatorDto()
				{
					CreatorName = c.CreatorName,
					BoardgamesCount = c.Boardgames.Count,
					Boardgames = c.Boardgames.ToArray()
				})
				.OrderByDescending(c => c.BoardgamesCount)
				.ThenBy(c => c.CreatorName)
				.ToArray();

			return xmlHelper.Serialize(creators, xmlRoot);
		}

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers
                    .Any(bg => bg.Boardgame.YearPublished <=  year &&
                            bg.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    s.Name,
                    s.Website,
                    Boardgames = s.BoardgamesSellers
					    .Where(bg => bg.Boardgame.YearPublished >= year &&
                            bg.Boardgame.Rating <= rating)
                        .Select(bgs => new
                        {
                            Name = bgs.Boardgame.Name,
                            Rating = bgs.Boardgame.Rating,
                            Mechanics = bgs.Boardgame.Mechanics,
                            Category = bgs.Boardgame.CategoryType.ToString()
                        })
                        .OrderByDescending(bgs => bgs.Rating)   
                        .ThenBy(bgs => bgs.Name)
                        .ToList()
				})
                .OrderByDescending(s => s.Boardgames.Count)
                .ThenBy (s => s.Name) 
                .Take(5)
                .ToList();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }
    }
}