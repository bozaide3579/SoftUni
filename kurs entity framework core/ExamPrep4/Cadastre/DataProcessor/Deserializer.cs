namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
	using Cadastre.Data.Enumerations;
	using Cadastre.Data.Models;
	using Cadastre.DataProcessor.ImportDtos;
	using Cadastre.Utilities;
	using Newtonsoft.Json;
	using System.ComponentModel.DataAnnotations;
	using System.Globalization;
	using System.Text;

	public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();
            const string xmlRoot = "Districts";

            ICollection<District> districtsToImport = new List<District>();
            ImportDistrictDto[] deserializedDistricts = xmlHelper.Deserialize<ImportDistrictDto[]>(xmlDocument, xmlRoot);

            foreach (var districtDto in deserializedDistricts)
            {
                if (!IsValid(districtDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (dbContext.Districts.Any(d => d.Name == districtDto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                District district = new District()
                {
                    Name = districtDto.Name,
                    PostalCode = districtDto.PostalCode,
                    Region = (Region)Enum.Parse(typeof(Region), districtDto.Region)
                };

                foreach (var propertyDto in districtDto.Properties)
                {
                    if (!IsValid(propertyDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime dateOfAcquisition = DateTime
                        .ParseExact(propertyDto.DateOfAcquisition, "dd/MM/yyyy", CultureInfo
                        .InvariantCulture, DateTimeStyles.None);

                    if (dbContext.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier) ||
                        district.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
					if (dbContext.Properties.Any(p => p.Address == propertyDto.Address) ||
						district.Properties.Any(p => p.Address == propertyDto.Address))
					{
						sb.AppendLine(ErrorMessage);
						continue;
					}

                    Property property = new Property()
                    {
                        PropertyIdentifier = propertyDto.PropertyIdentifier,
                        Area = propertyDto.Area,
                        Details = propertyDto.Details,
                        Address = propertyDto.Address,
                        DateOfAcquisition = dateOfAcquisition
                    };

                    district.Properties.Add(property);
				}

                districtsToImport.Add(district);
                sb.AppendLine(string.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count));
            }

            dbContext.Districts.AddRange(districtsToImport);
            dbContext.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<Citizen> citizensToImport =  new List<Citizen>();
            ImportCitizenDto[] deserializedCitizens = JsonConvert.DeserializeObject<ImportCitizenDto[]>(jsonDocument)!;

            foreach (var citizenDto in deserializedCitizens)
            {
                if (!IsValid(citizenDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

				DateTime birthDate = DateTime
					   .ParseExact(citizenDto.BirthDate, "dd-MM-yyyy", CultureInfo
					   .InvariantCulture, DateTimeStyles.None);

                Citizen citizen = new Citizen()
                {
                    FirstName = citizenDto.FirstName,
                    LastName = citizenDto.LastName,
                    BirthDate = birthDate,
                    MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), citizenDto.MaritalStatus)
                };

                foreach (var propertyId in  citizenDto.Properties)
                {
                    PropertyCitizen propertyCitizen = new PropertyCitizen()
                    {
                        Citizen = citizen,
                        PropertyId = propertyId
                    };

                    citizen.PropertiesCitizens.Add(propertyCitizen);
                }

                citizensToImport.Add(citizen);
                sb.AppendLine(string.Format(SuccessfullyImportedCitizen, citizen.FirstName, citizen.LastName, citizen.PropertiesCitizens.Count));
			}

            dbContext.Citizens.AddRange(citizensToImport);
            dbContext.SaveChanges();

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
