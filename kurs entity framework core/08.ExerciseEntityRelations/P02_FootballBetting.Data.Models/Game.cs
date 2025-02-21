using P02_FootballBetting.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
	public class Game
	{
        public Game()
        {
            PlayerStatistics = new HashSet<PlayerStatistic>();
            Bets = new HashSet<Bet>();
        }

        [Key]
        public int GameId { get; set; }

        public int HomeTeamId { get; set; }
        [ForeignKey(nameof(HomeTeamId))]
        public virtual Team HomeTeam { get; set; }

		public int AwayTeamId { get; set; }
		[ForeignKey(nameof(AwayTeamId))]
		public virtual Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

		public DateTime DateTime { get; set; }

		public decimal HomeTeamBetRate { get; set; }

		public decimal AwayTeamBetRate { get; set; }

		public decimal DrawBetRate { get; set; }

		[MaxLength(ValidationConstants.GameResultLength)]
		public string Result { get; set; }

		public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
