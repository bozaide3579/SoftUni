﻿using NetPay.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ExportDtos
{
	using static NetPay.Data.DataConstraints;

	[XmlType("Household")]
	public class ExportHouseholdDto
	{
		[XmlElement("ContactPerson")]
		public string ContactPerson { get; set; } = null!;

		[XmlElement("Email")]
		public string? Email { get; set; }

		[XmlElement("PhoneNumber")]
		public string PhoneNumber { get; set; } = null!;

		[XmlElement("Expenses")]
		public ExportExpenseDto[] Expenses { get; set; } = null!;
	}
}
