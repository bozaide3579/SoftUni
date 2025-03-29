using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TravelAgency.Data.Models;

namespace TravelAgency.DataProcessor.ExportDtos
{
	[XmlType("TourPackage")]
	public class ExportTourPackageDto
	{
		[Required]
		[XmlElement("Name")]
		public string TourPackageName { get; set; } = null!;

		[XmlElement("Description")]
        public string? Description { get; set; }

		[Required]
		[XmlElement("Price")]
        public decimal Price { get; set; }
    }
}