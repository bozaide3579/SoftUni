using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TravelAgency.Data;
using TravelAgency.DataProcessor.ExportDtos;
using TravelAgency.Utilities;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();
            const string xmlRoot = "Guides";

            ExportGuideDto[] guidesToExport = context
                .Guides
                .Where(g => g.Language == Data.Models.Enums.Language.Spanish)
                .Include(g => g.TourPackagesGuides)
                .ThenInclude(tpg => tpg.TourPackage)
                .Select(g => new ExportGuideDto
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides
                        .Select(tpg => new ExportTourPackageDto
                        {
                            TourPackageName = tpg.TourPackage.PackageName,
                            Description = tpg.TourPackage.Description,
                            Price = tpg.TourPackage.Price
                        })
                        .OrderByDescending(tp => tp.Price)
                        .ToArray()
                })
                .OrderByDescending(g => g.TourPackages.Count())
                .ThenBy(g => g.FullName)
                .ToArray();

            return xmlHelper.Serialize(guidesToExport, xmlRoot);
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {

            var customersToExport = context
                .Customers
                .Include(c => c.Bookings)
                .ThenInclude(b => b.TourPackage)
                .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == "Horse Riding Tour"))
			   .OrderBy(c => c.FullName)
			   .ThenBy(c => c.Bookings.Count)
               .ToArray()
                .Select(c => new
                {
                    c.FullName,
                    c.PhoneNumber,
                    Bookings = c.Bookings
                        .Where(b => b.TourPackage.PackageName == "Horse Riding Tour")
                        .OrderBy(b => b.BookingDate)
                        .Select(b => new
                        {
                            TourPackageName = b.TourPackage.PackageName,
                            Date = b.BookingDate.ToString("yyyy-MM-dd")
                        })
                        .ToArray()
                })
			   .ToArray();

            return JsonConvert.SerializeObject(customersToExport, Formatting.Indented);
		}
    }
}
