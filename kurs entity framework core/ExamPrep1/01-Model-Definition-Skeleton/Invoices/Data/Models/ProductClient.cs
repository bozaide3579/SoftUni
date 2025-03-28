﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.Data.Models
{
	public class ProductClient
	{
		[Required]
		[ForeignKey(nameof(Product))]
		public int ProductId { get; set; }

		[Required]
		public virtual Product Product { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Client))]
		public int ClientId { get; set; }

		[Required]
		public virtual Client Client { get; set; } = null!;
	}


}

