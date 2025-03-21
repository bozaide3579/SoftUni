using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ExportDtos
{
	[XmlType("Property")]
	public class ExportPropertiesDto
	{
		[XmlElement("PropertyIdentifier")]
		public string PropertyIdentifier { get; set; } = null!;

		[XmlElement("Area")]
        public int Area { get; set; }

		[XmlElement("DateOfAcquisition")]
		public string DateOfAcquisition { get; set; } = null!;

		[XmlElement("Details")]
		public string Details { get; set; } = null!;

		[XmlAttribute("postal-code")]
		public string PostalCode { get; set; } = null!;
    }
}
