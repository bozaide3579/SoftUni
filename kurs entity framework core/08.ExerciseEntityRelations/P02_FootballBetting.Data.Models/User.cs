using P02_FootballBetting.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
	public class User
	{
        public User()
        {
            Bets = new HashSet<Bet>();
        }

        [Key]
        public int UserId { get; set; }

        [MaxLength(ValidationConstants.UsernameMaxLength)]
        [Required]
        public string Username { get; set; }

		[MaxLength(ValidationConstants.PasswordMaxLength)]
		[Required]
		public string Password { get; set; }

		[MaxLength(ValidationConstants.EmailMaxLength)]
		public string Email { get; set; }

		[MaxLength(ValidationConstants.UsersNameMaxLength)]
		[Required]
		public string Name { get; set; }

        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }

    }

}
