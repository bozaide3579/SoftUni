using Cadastre.Data.Enumerations;
using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.Data.Models
{
	using static DataConstraints;

	public class Citizen
	{
		[System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(CitizenFirstNameMaxLength)]
		public string FirstName { get; set; } = null!;

		[Required]
		[MaxLength(CitizenLastNameMaxLength)]
		public string LastName { get; set; } = null!;

		[Required]
        public DateTime BirthDate { get; set; }

		[Required]
        public MaritalStatus MaritalStatus { get; set; }

        public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; }
		= new HashSet<PropertyCitizen>();	
    }
}
