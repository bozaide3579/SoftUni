using Cadastre.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    using static Cadastre.Data.DataConstraints;

    [XmlType("District")]
    public class ImportDistrictDto
    {

        [Required]
        [XmlElement("Name")]
        [MinLength(DistrictNameMinLength)]
        [MaxLength(DistrictNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("PostalCode")]
        [StringLength(DistrictPostalCodeLength)]
        [RegularExpression(DistrictPostalCodeRegex)]
        public string PostalCode { get; set; } = null!;

        [Required]
        [XmlAttribute("Region")]
        public string Region { get; set; } = null!;

        [Required]
        [XmlArray("Properties")]
        public ImportPropertyDto[] Properties { get; set; } = null!;
    }
}
