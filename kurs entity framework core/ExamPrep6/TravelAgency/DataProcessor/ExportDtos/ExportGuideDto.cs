﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TravelAgency.Data.Models;

namespace TravelAgency.DataProcessor.ExportDtos
{
	[XmlType("Guide")]
	public class ExportGuideDto
	{
		[Required]
		[XmlElement("FullName")]
		public string FullName { get; set; } = null!;

		[Required]
		[XmlArray("TourPackages")]
		public ExportTourPackageDto[] TourPackages { get; set; } = null!;
    }
}
