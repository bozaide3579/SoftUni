﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
	[XmlType("customer")]
	public class CustomerExportDto
	{
        [XmlAttribute("full-name")]
        public string FullName { get; set; }
		[XmlAttribute("bought-cars")]
		public int  CarsBought { get; set; }
		[XmlAttribute("spent-money")]
		public decimal MoneySpent { get; set; }
    }
}
