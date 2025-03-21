namespace Boardgames.DataProcessor
{
	using System.ComponentModel.DataAnnotations;
	using System.Text;
	using System.Xml.Serialization;
	using Boardgames.Data;
	using Boardgames.Data.Models;
	using Boardgames.Data.Models.Enums;
	using Boardgames.DataProcessor.ImportDto;
	using Boardgames.Utilities;
	using Newtonsoft.Json;

	public class Deserializer
	{
		private const string ErrorMessage = "Invalid data!";

		private const string SuccessfullyImportedCreator
			= "Successfully imported creator – {0} {1} with {2} boardgames.";

		private const string SuccessfullyImportedSeller
			= "Successfully imported seller - {0} with {1} boardgames.";

		public static string ImportCreators(BoardgamesContext context, string xmlString)
		{
			StringBuilder sb = new StringBuilder();
			XmlHelper xmlHelper = new XmlHelper();
			string xmlRoot = "Creators";

			var creatorDtos = xmlHelper
				.Deserialize<ImportCreatorDto[]>(xmlString, xmlRoot);

			ICollection<Creator> creatorsToImport = new List<Creator>();

			foreach (ImportCreatorDto creatorDto in creatorDtos)
			{
				if (!IsValid(creatorDto))
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				Creator creator = new Creator()
				{
					FirstName = creatorDto.FirstName,
					LastName = creatorDto.LastName
				};

				foreach (var boardgameDto in creatorDto.Boardgames)
				{
					if (!IsValid(boardgameDto))
					{
						sb.AppendLine(ErrorMessage);
						continue;
					}

					creator.Boardgames.Add(new Boardgame()
					{
						Name = boardgameDto.Name,
						Rating = boardgameDto.Rating,
						YearPublished = boardgameDto.YearPublished,
						CategoryType = (CategoryType)boardgameDto.CategoryType,
						Mechanics = boardgameDto.Mechanics
					});
				}
				creatorsToImport.Add(creator);
				sb.AppendLine(string.Format(SuccessfullyImportedCreator,
					creator.FirstName,
					creator.LastName,
					creator.Boardgames.Count));
			}

			context.Creators.AddRange(creatorsToImport);
			context.SaveChanges();

			return sb.ToString().TrimEnd();

		}

		public static string ImportSellers(BoardgamesContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();
			ICollection<Seller> sellersToImport = new List<Seller>();

			var boardgamesIds = context.Boardgames
				.Select(x => x.Id)
				.ToArray();

			var sellersDtos = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);
			foreach (ImportSellerDto sellerDto in sellersDtos)
			{
				if (!IsValid(sellerDto))
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				Seller seller = new Seller()
				{
					Name = sellerDto.Name,
					Address = sellerDto.Address,
					Country = sellerDto.Country,
					Website = sellerDto.Website
				};

				foreach (var id in sellerDto.BoardgamesIds.Distinct())
				{
					if (!boardgamesIds.Contains(id))
					{
						sb.AppendLine(ErrorMessage);
						continue;
					}

					BoardgameSeller boardgameSeller = new BoardgameSeller()
					{
						Seller = seller,
						BoardgameId = id
					};

					seller.BoardgamesSellers.Add(boardgameSeller);
				}

				sellersToImport.Add(seller);
				sb.AppendLine(String.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count()));
			}

			context.Sellers.AddRange(sellersToImport);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}
