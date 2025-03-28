﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
	using static DataConstraints;

	public class Seller
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(SellerNameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[MaxLength(SellerAddressMaxLength)]
		public string Address { get; set; } = null!;

		[Required]
		public string Country { get; set; } = null!;

		[Required]
		public string Website { get; set; } = null!;

        public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
			= new HashSet<BoardgameSeller>();
    }
}
